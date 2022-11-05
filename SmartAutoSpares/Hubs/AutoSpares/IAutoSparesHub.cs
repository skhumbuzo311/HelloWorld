using System.Threading.Tasks;
using SmartAutoSpares.Models;

namespace SmartAutoSpares.Hubs.Feeds
{
    public interface IAutoSparesHub
    {
        Task Add(AutoSpare autoSpare);
        Task Update(AutoSpare autoSpare);
        Task Delete(int id);
        Task Like(AutoSpareLike autoSpareLike);
        Task PostComment(Entities.PostComment comment);
    }
}
