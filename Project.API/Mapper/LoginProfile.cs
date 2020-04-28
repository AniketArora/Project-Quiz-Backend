using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Project.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Mapper {
    public class LoginProfile: Profile {
        public LoginProfile() {
            CreateMap<IdentityUser, LoginResource>();
        }
    }
}
