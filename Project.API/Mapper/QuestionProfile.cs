using AutoMapper;
using Project.API.Resources;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Mapper {
    public class QuestionProfile : Profile {
        public QuestionProfile() {
            CreateMap<QuizQuestion, QuizQuestionResource>();
            CreateMap<Question, QuestionResource>();

            CreateMap<QuestionSaveResource, Question>()
                .AfterMap((src, dest) => {
                    var removedQuestionAnswers = dest.QuestionAnswers.Where(s => !src.AnswerQuizSaveResource.Any(aq => aq.AnswerId == s.AnswerId));

                    foreach (var q in removedQuestionAnswers.ToList()) {
                        dest.QuestionAnswers.Remove(q);
                    }

                    var addedQuestionAnswers = src.AnswerQuizSaveResource.Where(aq => !dest.QuestionAnswers.Any(qa => qa.AnswerId == aq.AnswerId)).Select(id => new QuestionAnswer { AnswerId = id.AnswerId, IsCorrect = id.IsCorrect });

                    foreach (var q in addedQuestionAnswers.ToList()) {
                        dest.QuestionAnswers.Add(q);
                    }
                });
        }
    }
}
