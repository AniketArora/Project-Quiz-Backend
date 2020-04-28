using AutoMapper;
using Project.API.Resources;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Mapper {
    public class QuestionProfile: Profile {
        public QuestionProfile() {
            CreateMap<Question, QuestionResource>();
        }
    }
}
