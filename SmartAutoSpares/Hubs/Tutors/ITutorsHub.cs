using System.Threading.Tasks;
using SmartAutoSpares.Entities;

namespace SmartAutoSpares.Hubs.Tutors
{
    public interface ITutorsHub
    {
        Task Like(TutorLike tutorLike);
        Task UpdateTutorAttribute(TutorAttribute tutorAttribute);
    }
}
