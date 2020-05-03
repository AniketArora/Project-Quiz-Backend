using System;
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
    public class SubjectController : GenericController<Subject, SubjectResource, SubjectSaveResource, Guid> {
        public SubjectController(ISubjectRepo repo, IMapper mapper, ILogger<SubjectController> logger) : base(repo, mapper, logger) {
        }
    }
}