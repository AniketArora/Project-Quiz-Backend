﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.API.Resources;
using Project.Models;
using Project.Models.Repo_s;

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : GenericController<Quiz,QuizResource,QuizSaveResource, Guid>
    {
        public QuizController(IQuizRepo repo,IMapper mapper,ILogger<QuizController> logger):base(repo,mapper,logger) {

        }
    }
}