using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Models.Repo_s {
    public interface IQuizRepo:IGenericRepo<Quiz> {
        Task<IEnumerable<Quiz>> GetQuizByDifficulityAsync(Quiz.DifficultyLevel level);
        Task<IEnumerable<Quiz>> GetQuizbySubjectAsync(string subject);
    }
}