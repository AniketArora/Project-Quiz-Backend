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
    public class QuestionController : GenericController<Question, QuestionResource, QuestionSaveResource, Guid> {
        private readonly IQuestionRepo _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<QuestionController> _logger;

        public QuestionController(IQuestionRepo repo, IMapper mapper, ILogger<QuestionController> logger) : base(repo, mapper, logger) {
            this._repo = repo;
            this._mapper = mapper;
            this._logger = logger;
        }

        [HttpPost]
        public override async Task<IActionResult> Post(QuestionSaveResource saveResource) {
            try {
                var entity = _mapper.Map<Question>(saveResource);

                _repo.Create(entity);
                await _repo.SaveChangesAsync();

                entity = await _repo.GetAsync(entity.Id);

                var resoure = _mapper.Map<QuestionResource>(entity);

                return CreatedAtAction(nameof(GetAll), resoure);


            } catch (Exception ex) {

                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }
    }
}