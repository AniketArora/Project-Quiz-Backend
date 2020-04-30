using AutoMapper;
using Project.API.Resources;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Mapper {
    public class AnswerProfile : Profile {
        public AnswerProfile() {
            CreateMap<Answer, AnswerResource>();

            CreateMap<AnswerSaveResource, Answer>()
                .ForMember(dest => dest.QuestionAnswers, opt => opt.Ignore())
                .ForMember(dest => dest.QuizAwnsers, opt => opt.Ignore())
                .ForMember(dest => dest.UserQuizzes, opt => opt.Ignore());
        }
    }
}
