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
            CreateMap<Question, QuestionResource>()
                .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.QuestionAnswers.Select(s => new AnswerResource {
                    Id = s.AnswerId,
                    Answertext = s.Answer.Answertext
                })));

            CreateMap<QuestionSaveResource, Question>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .AfterMap((src, dest) => {
                    var removedQuestionAnswers = dest.QuestionAnswers.Where(s => !src.AnswerQuizSaveResource.Any(aq => aq.AnswerId == s.AnswerId));

                    foreach (var q in removedQuestionAnswers.ToList()) {
                        dest.QuestionAnswers.Remove(q);
                    }

                    var addedQuestionAnswers = src.AnswerQuizSaveResource.Where(aq => !dest.QuestionAnswers.Any(qa => qa.AnswerId == aq.AnswerId)).Select(id => new QuestionAnswer { AnswerId = id.AnswerId, IsCorrect = id.IsCorrect });

                    foreach (var qa in addedQuestionAnswers.ToList()) {
                        dest.QuestionAnswers.Add(qa);
                    }
                });
        }
    }
}
