﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Models.Repo_s;

namespace Project.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<TEntity, TEntityResource, TEntitySaveResources> : ControllerBase
        where TEntity : class
        where TEntityResource : class
        where TEntitySaveResources : class {

        private IGenericRepo<TEntity> _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<GenericController<TEntity, TEntityResource, TEntitySaveResources>> _logger;

        public GenericController(IGenericRepo<TEntity> repo, IMapper mapper, ILogger<GenericController<TEntity, TEntityResource, TEntitySaveResources>> logger) {
            _repo = repo;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpPost]
        public virtual async Task<IActionResult> Post(TEntitySaveResources saveResource) {

            try {
                var entity = _mapper.Map<TEntity>(saveResource);

                _repo.Create(entity);
                await _repo.SaveChangesAsync();

                var resoure = _mapper.Map<TEntityResource>(entity);

                return CreatedAtAction(nameof(GetAll), resoure);


            } catch (Exception ex) {

                _logger.LogError(ex.Message);
                return BadRequest();
            }

        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll() {
            try {
                var objList = await _repo.GetAllAsync();

                var resoureList = _mapper.Map<IEnumerable<TEntityResource>>(objList);

                return Ok(resoureList);

            } catch (Exception ex) {

                _logger.LogError(ex.Message);
                return BadRequest();
            }

        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(Guid id) {

            try {
                var obj = await _repo.GetAsync(id);

                if (obj == null) {
                    return NotFound();
                }

                var resoure = _mapper.Map<TEntityResource>(obj);

                return Ok(resoure);

            } catch (Exception ex) {

                _logger.LogError(ex.Message);
                return BadRequest();
            }

        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(Guid id, TEntitySaveResources SaveResoure) {

            try {

                var obj = await _repo.GetAsync(id);

                if (obj == null) {
                    return NotFound();
                }

                _mapper.Map(SaveResoure, obj);

                await _repo.SaveChangesAsync();

                return NoContent();

            } catch (Exception ex) {

                _logger.LogError(ex.Message);
                return BadRequest();
            }

        }


        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(Guid id) {

            try {

                var obj = await _repo.GetAsync(id);

                if (obj == null) {
                    return NotFound();
                }

                _repo.Delete(obj);

                await _repo.SaveChangesAsync();

                return NoContent();

            } catch (Exception ex) {

                _logger.LogError(ex.Message);
                return BadRequest();
            }

        }

    }
}