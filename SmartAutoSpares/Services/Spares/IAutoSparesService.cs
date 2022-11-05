using System.Collections.Generic;
using System.Threading.Tasks;
using SmartAutoSpares.Outcomes.Results;

namespace SmartAutoSpares.Services.Authentication
{
    public interface IAutoSparesService
    {
        IEnumerable<Models.AutoSpare> Get();
        Task<IOutcome> Delete(int autoSpareId, int userId);
        Task<IOutcome<List<string>>> Post(Models.AutoSpare autoSpare);
        Task<IOutcome> Update(Models.AutoSpare autoSpare);
        Task<IOutcome<Models.AutoSpareLike>> Like(Models.AutoSpareLike autoSpareLike);
        Task<IOutcome<List<string>>> ImagesToUrls(Microsoft.AspNetCore.Http.HttpRequest httpRequest);
    }
}
