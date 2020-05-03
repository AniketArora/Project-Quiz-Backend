using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Models.Repo_s {
    public interface IQuestionRepo:IGenericRepo<Question> {
        Task<IEnumerable<Question>> GetAllAsync();
    }
}