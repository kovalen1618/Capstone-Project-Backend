using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using playlist_app_backend.Contracts;
using playlist_app_backend.Entities.DataTransferObjects;
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
    }
}
