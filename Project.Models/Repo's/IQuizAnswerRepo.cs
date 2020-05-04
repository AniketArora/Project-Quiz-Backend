using System.Collections.Generic;

namespace Project.Models.Repo_s {
    public interface IQuizAnswerRepo : IGenericRepo<QuizAnswer> {
       void SaveBulk(IEnumerable<QuizAnswer> quizAnswers);
    }
}