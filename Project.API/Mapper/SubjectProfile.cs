using AutoMapper;
using Project.API.Resources;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Mapper {
    public class SubjectProfile: Profile {
        public SubjectProfile() {
            CreateMap<Subject, SubjectResource>();

            CreateMap<SubjectSaveResource, Subject>()
             .ForMember(dest => dest.QuizSubjects, opt => opt.Ignore());
        } 
    }
}
