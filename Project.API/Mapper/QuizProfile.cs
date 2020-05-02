using AutoMapper;
using Project.API.Resources;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Mapper {
    public class QuizProfile : Profile {
        public QuizProfile() {
            // domain class --> resource
            CreateMap<Quiz, QuizResource>()
                .ForMember(dest => dest.Subjects, opt => opt.MapFrom(src => src.QuizSubjects.Select(s => s.Subject.SubjectName)))
                .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.QuizQuestions.Select(s => new QuestionResource {
                    Id = s.QuestionId,
                    Score = s.Question.Score,
                    Questiontext = s.Question.Questiontext,
                    Answers = s.Question.QuestionAnswers.Select(s => new AnswerResource {
                        Id = s.AnswerId,
                        Answertext = s.Answer.Answertext
                    })
                })));

            // resource =-> domain class
            CreateMap<QuizSaveResource, Quiz>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.QuizSubjects, opt => opt.Ignore())
                .ForMember(dest => dest.QuizQuestions, opt => opt.Ignore())
                .AfterMap((src, dest) => {
                    var removedQuizSubjects = dest.QuizSubjects.Where(s => !src.SubjectIds.Contains(s.SubjectId));

                    foreach (var s in removedQuizSubjects.ToList()) {
                        dest.QuizSubjects.Remove(s);
                    }

                    var addQuizSubjects = src.SubjectIds.Where(id => !dest.QuizSubjects.Any(s => s.SubjectId == id)).Select(id => new QuizSubject { SubjectId = id });

                    foreach (var s in addQuizSubjects.ToList()) {
                        dest.QuizSubjects.Add(s);
                    }

                    var removedQuizQuestions = dest.QuizQuestions.Where(s => !src.QuestionIds.Contains(s.QuestionId));

                    foreach (var item in removedQuizQuestions) {
                        dest.QuizQuestions.Remove(item);
                    }

                    var addQuizQuestions = src.QuestionIds.Where(id => !dest.QuizQuestions.Any(s => s.QuestionId == id)).Select(id => new QuizQuestion { QuestionId = id });

                    foreach (var s in addQuizQuestions.ToList()) {
                        dest.QuizQuestions.Add(s);
                    }
                });
        }
    }
}
