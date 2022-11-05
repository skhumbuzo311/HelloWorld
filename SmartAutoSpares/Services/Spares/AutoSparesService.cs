using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartAutoSpares.Context;
using SmartAutoSpares.Entities;
using SmartAutoSpares.Outcomes.Results;
using Microsoft.EntityFrameworkCore;
using SmartAutoSpares.Services.Converters;
using SmartAutoSpares.Hubs.Feeds;
using Microsoft.AspNetCore.SignalR;
using SmartAutoSpares.Services.Utils;
using ServiceLayer;
using Microsoft.Extensions.Configuration;

namespace SmartAutoSpares.Services.Authentication
{
    public class AutoSparesService : IAutoSparesService
    {
        private readonly SmartAutoSparesDbContext _smartAutoSparesDbContext;
        private readonly IHubContext<AutoSparesHub, IAutoSparesHub> _autoSparesHub;
        private readonly IConfiguration _configuration;

        public AutoSparesService(SmartAutoSparesDbContext smartAutoSpares, IHubContext<AutoSparesHub, IAutoSparesHub> feedsHub, IConfiguration configuration)
        {
            _smartAutoSparesDbContext = smartAutoSpares;
            _autoSparesHub = feedsHub;
            _configuration = configuration;
        }

        public IEnumerable<Models.AutoSpare> Get()
        {
            try
            {
                return _smartAutoSparesDbContext.AutoSpares
                        .Include(s => s.CreatedByUser)
                        .Include(s => s.Likes)
                        .Include(s => s.Images)
                        .OrderByDescending(s => s.CreatedAt)
                        .Select(s => AutoSparesConverter.ConvertAutoSpareToModel(s));
            }
            catch (Exception ex)
            {
                _smartAutoSparesDbContext.Logs.Add(new Log()
                {
                    Message = ex.Message,
                    CreatedAt = DateTime.Now
                });

                return Enumerable.Empty<Models.AutoSpare>();
            }
        }

        public Models.AutoSpare Get(int id)
        {
            var autoSpare = _smartAutoSparesDbContext.AutoSpares
                    .Include(s => s.CreatedByUser)
                    .Include(s => s.Likes)
                    .Include(s => s.Images)
                    .Single(s => s.Id == id);

            return AutoSparesConverter.ConvertAutoSpareToModel(autoSpare);
        }

        public async Task<IOutcome<List<string>>> ImagesToUrls(Microsoft.AspNetCore.Http.HttpRequest httpRequest)
        {
            var urls = new List<string>();
            var objBlobService = new BlobStorageService(_configuration);

            foreach(var file in httpRequest.Form.Files)
            {
                urls.Add(objBlobService.UploadFileToBlob(
                    file.Name,
                    await FormFileExtensions.GetBytes(file),
                    file.ContentType
                ));
            }

            return new Success<List<string>>(urls);
        }

        public async Task<IOutcome<List<string>>> Post(Models.AutoSpare autoSpare)
        {
            try
            {
                var newAutoSpare = new AutoSpare()
                {
                    CreatedByUserId = autoSpare.UserId,
                    Name = autoSpare.Name,
                    Make = autoSpare.Make,
                    Number = autoSpare.Number,
                    YearModel = autoSpare.YearModel,
                    Price = autoSpare.Price,
                    CreatedAt = DateTime.Now
                };

                _smartAutoSparesDbContext.AutoSpares.Add(newAutoSpare);
                _smartAutoSparesDbContext.SaveChanges();

                foreach (string imageUrl in autoSpare.imagesUrls)
                {
                    _smartAutoSparesDbContext.AutoSpareImages.Add(new AutoSpareImage()
                    {
                        AutoSpareId = newAutoSpare.Id,
                        URL = imageUrl,
                        CreatedAt = DateTime.Now
                    });
                }

                _smartAutoSparesDbContext.SaveChanges();

                await _autoSparesHub.Clients.All.Add(Get(newAutoSpare.Id));

                var expoPushTokens = _smartAutoSparesDbContext
                    .Users
                    .Select(u => u.ExpoPushToken)
                    .ToList();

                return new Success<List<string>>(expoPushTokens);
            }
            catch (Exception ex)
            {
                return new Failure<List<string>>(new List<string>());
            }
        }

        public async Task<IOutcome> Update(Models.AutoSpare autoSpare)
        {
            var dbAutoSpare = _smartAutoSparesDbContext.AutoSpares.SingleOrDefault(a => a.Id == autoSpare.Id);

            if (dbAutoSpare != null)
            {
                dbAutoSpare.Name = autoSpare.Name;
                dbAutoSpare.Number = autoSpare.Number;
                dbAutoSpare.Price = autoSpare.Price;
                dbAutoSpare.YearModel = autoSpare.YearModel;
                dbAutoSpare.Make = autoSpare.Make;

                _smartAutoSparesDbContext.SaveChanges();

                await _autoSparesHub.Clients.All.Update(Get(dbAutoSpare.Id));
            }

            return new Success();
        }

        public async Task<IOutcome> Delete(int id, int userId)
        {

            var dbAutoSpares = _smartAutoSparesDbContext.AutoSpares.Single(p => p.Id == id);

            dbAutoSpares.IsDeleted = true;

            _smartAutoSparesDbContext.SaveChanges();

            await _autoSparesHub.Clients.All.Delete(id);

            return new Success();
        }

        public async Task<IOutcome<Models.AutoSpareLike>> Like(Models.AutoSpareLike autoSpareLike)
        {
            var dbAutoSpareLike = _smartAutoSparesDbContext
                .AutoSpareLikes
                .SingleOrDefault(pl => pl.CreatedByUserId == autoSpareLike.CreatedByUserId && pl.AutoSpareId == autoSpareLike.AutoSpareId);

            var dbPost = _smartAutoSparesDbContext
                .AutoSpares
                .Include(a => a.Likes)
                .SingleOrDefault(p => p.Id == autoSpareLike.AutoSpareId);

            if (dbAutoSpareLike == null)
            {
                dbAutoSpareLike = new AutoSpareLike()
                {
                    CreatedByUserId = autoSpareLike.CreatedByUserId,
                    AutoSpareId = autoSpareLike.AutoSpareId,
                    CreatedAt = DateTime.Now
                };

                _smartAutoSparesDbContext.AutoSpareLikes.Add(dbAutoSpareLike);
            }

            else _smartAutoSparesDbContext.AutoSpareLikes.Remove(dbAutoSpareLike);

            await _autoSparesHub.Clients.All.Like(autoSpareLike);

            _smartAutoSparesDbContext.SaveChanges();

            return new Success<Models.AutoSpareLike>(autoSpareLike);
        }
    }
}
