using AutoMapper;
using Project.API.Resources;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Mapper {
    public class QuizProfile:Profile {
        public QuizProfile() {
            // domain class --> resource
            CreateMap<Quiz, QuizResource>()
                .ForMember(dest => dest.Subjects, opt => opt.MapFrom(src => src.QuizSubjects.Select(s => s.Subject.SubjectName)));

            // resource =-> domain class
            CreateMap<QuizSaveResource, Quiz>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember( dest => dest.QuizSubjects, opt => opt.Ignore())
                .AfterMap( (src,dest) => {
                    var removedQuizSubjects = dest.QuizSubjects.Where(s => !src.QuizSubjectsId.Contains(s.SubjectId));

                    foreach (var s in removedQuizSubjects.ToList()) {
                        dest.QuizSubjects.Remove(s);
                    }

                    var addQuizSubjects = src.QuizSubjectsId.Where(id => !dest.QuizSubjects.Any(s => s.SubjectId == id)).Select(id => new QuizSubject { SubjectId = id });

                    foreach (var s in addQuizSubjects.ToList()) {
                        dest.QuizSubjects.Add(s);
                    }
                })
                ;

        }
    }
}
