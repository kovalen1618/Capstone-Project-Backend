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
    [Route("api/tags")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;
        private IMapper _mapper;
        private ILoggerManager _logger;

        public TagController(IRepositoryWrapper repoWrapper, IMapper mapper, ILoggerManager logger)
        {
            _repoWrapper = repoWrapper;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllTags()
        {
            try
            {
                var tags = _repoWrapper.Tag.GetAllTags();
                _logger.LogInfo($"Returned all tags from the database.");

                var tagsResult = _mapper.Map<IEnumerable<TagDto>>(tags);

                return Ok(tagsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllTags action:" +
                    $" {ex.Message}");
                return StatusCode(500, "Interal server error");
            }
            
        }

        [HttpGet("{id}", Name = "TagById")]
        public IActionResult GetTagById(int id)
        {
            try
            {
                var tag = _repoWrapper.Tag.GetTagById(id);

                if (tag == null)
                {
                    _logger.LogError($"Tag with id: {id}, has not been found in the" +
                        $" database.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned tag with id: {id}");
                    var tagResult = _mapper.Map<TagDto>(tag);
                    return Ok(tagResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the GetTagById" +
                    $" actions: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
            
        }

        [HttpPost]
        public IActionResult CreateTag([FromBody]TagForCreationDto tag)
        {
            try
            {
                if (tag == null)
                {
                    _logger.LogError("Tag objuect sent from the client is null.");
                    return BadRequest("Tag object is null");
                }
                
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid tag object sent from the client");
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
                _logger.LogError($"Something went wrong inside the CreateTag action:" +
                    $" {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTag(int id, [FromBody] TagForUpdateDto tag)
        {
            try
            {
                if (tag == null)
                {
                    _logger.LogError("Tag object sent from the client is null.");
                    return BadRequest("Tag object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid tag object sent from the client.");
                    return BadRequest("Invalid model object");
                }

                var tagEntity = _repoWrapper.Tag.GetTagById(id);

                if (tagEntity == null)
                {
                    _logger.LogError($"Tag with id: {id}, has not been found in" +
                        $" the database.");
                    return NotFound();
                }

                _mapper.Map(tag, tagEntity);
                _repoWrapper.Tag.UpdateTag(tagEntity);
                _repoWrapper.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the UpdateTag actions:" +
                    $" {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTag(int id)
        {
            try
            {
                var tag = _repoWrapper.Tag.GetTagById(id);

                if (tag == null)
                {
                    _logger.LogError($"Tag with id: {id}, has not been found in" +
                        $" the database.");
                    return NotFound();
                }

                _repoWrapper.Tag.DeleteTag(tag);
                _repoWrapper.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the DeleteTag action:" +
                    $" {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("{tagId}/playlists")]
        public IActionResult GetPlaylistsForTag(int tagId)
        {
            IEnumerable<PlaylistDto> playlists;

            IEnumerable<Playlist> playlistEntities = _repoWrapper.Tag.GetPlaylistsForTag(tagId);
            playlists = _mapper.Map<IEnumerable<PlaylistDto>>(playlistEntities);

            return Ok(playlists);
        }
    }
}
