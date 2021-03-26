using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using playlist_app_backend.Contracts;
using playlist_app_backend.Entities.DataTransferObjects;
using playlist_app_backend.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace playlist_app_backend.Controllers
{
    [Route("api/tag")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;
        private IMapper _mapper;

        public TagController(IRepositoryWrapper repoWrapper, IMapper mapper)
        {
            _repoWrapper = repoWrapper;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllTags()
        {
            var tags = _repoWrapper.Tag.GetAllTags();

            var tagsResult = _mapper.Map<IEnumerable<TagDto>>(tags);

            return Ok(tagsResult);
        }

        [HttpGet("{id}", Name = "TagById")]
        public IActionResult GetTagById(int id)
        {
            var tag = _repoWrapper.Tag.GetTagById(id);

            if (tag == null)
            {
                return NotFound();
            }
            else
            {
                var tagResult = _mapper.Map<TagDto>(tag);
                return Ok(tagResult);
            }
        }

        [HttpPost]
        public IActionResult CreateTag([FromBody]TagForCreationDto tag)
        {
            try
            {
                if (tag == null)
                {
                    return BadRequest("Tag object is null");
                }
                
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var tagEntity = _mapper.Map<Tag>(tag);

                _repoWrapper.Tag.CreateTag(tagEntity);
                _repoWrapper.Save();

                var createdTag = _mapper.Map<TagDto>(tagEntity);

                return CreatedAtRoute("TagById", new { id = createdTag.Id }, createdTag);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
