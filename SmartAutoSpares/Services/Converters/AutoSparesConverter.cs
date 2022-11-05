using System.Linq;
using SmartAutoSpares.Entities;

namespace SmartAutoSpares.Services.Converters
{
    public static class AutoSparesConverter
    {
        public static Models.AutoSpare ConvertAutoSpareToModel(AutoSpare autoSpare)
        {
            return new Models.AutoSpare()
            {
                Id = autoSpare.Id,
                Name = autoSpare.Name,
                Make = autoSpare.Make,
                Number = autoSpare.Number,
                Price = autoSpare.Price,
                YearModel = autoSpare.YearModel,
                Likes = autoSpare.Likes,
                imagesUrls = autoSpare.Images.Select(i => i.URL).ToList(),
            };
        }
    }
}
