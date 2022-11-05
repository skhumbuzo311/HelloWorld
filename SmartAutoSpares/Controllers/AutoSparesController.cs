using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SmartAutoSpares.Entities;
using SmartAutoSpares.Outcomes;
using SmartAutoSpares.Outcomes.Results;
using SmartAutoSpares.Services.Authentication;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using SmartAutoSpares.Models;

namespace SmartAutoSpares.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoSparesController : ControllerBase
    {
        private readonly IHandler _outcomeHandler;
        private readonly IAutoSparesService _autoSparesService;
        public AutoSparesController(IAutoSparesService autoSparesService, IHandler outcomeHandler)
        {
            _autoSparesService = autoSparesService;
            _outcomeHandler = outcomeHandler;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_autoSparesService.Get());
        }

        [HttpPost]
        public async Task<ActionResult<IOutcome<List<string>>>> Post(Models.AutoSpare autoSpare)
        {
            return _outcomeHandler.HandleOutcome(await _autoSparesService.Post(autoSpare));
        }

        [HttpPatch]
        public async Task<ActionResult<IOutcome>> Update(Models.AutoSpare autoSpare)
        {
            return _outcomeHandler.HandleOutcome(await _autoSparesService.Update(autoSpare));
        }

        [HttpPatch("like")]
        public async Task<ActionResult<IOutcome<Models.AutoSpareLike>>> Like(Models.AutoSpareLike autoSpareLike)
        {
            return _outcomeHandler.HandleOutcome(await _autoSparesService.Like(autoSpareLike));
        }

        [HttpPost("images-to-urls")]
        public async Task<ActionResult<IOutcome<List<string>>>> ImagesToUrls()
        {
            return _outcomeHandler.HandleOutcome(await _autoSparesService.ImagesToUrls(Request));
        }

        [HttpDelete("{id}/userId/{userId}")]
        public async Task<ActionResult<IOutcome>> Delete(int id, int userId)
        {
            return _outcomeHandler.HandleOutcome(await _autoSparesService.Delete(id, userId));
        }
    }
}
