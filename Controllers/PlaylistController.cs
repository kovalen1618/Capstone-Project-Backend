﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    [Route("api/playlist")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;
        private IMapper _mapper;
        private readonly ILoggerManager _logger;

        public PlaylistController(IRepositoryWrapper repoWrapper, IMapper mapper, ILoggerManager logger)
        {
            _repoWrapper = repoWrapper;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllPlaylists()
        {
            try
            {
                var playlists = _repoWrapper.Playlist.GetAllPlaylists();
                _logger.LogInfo($"Returned all Playlist form database.");

                var playlistsResult = _mapper.Map<IEnumerable<PlaylistDto>>(playlists);

                return Ok(playlistsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllPlaylist action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "PlaylistById")]
        public IActionResult GetPlaylistById(int id)
        {
            try
            {
                var playlist = _repoWrapper.Playlist.GetPlaylistById(id);


                if (playlist == null)
                {
                    _logger.LogError($"Playlist with id:{id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with id: {id}");
                    var playlistResult = _mapper.Map<PlaylistDto>(playlist);
                    return Ok(playlistResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetPlaylistById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost]
        public IActionResult CreatePlaylist([FromBody]PlaylistForCreationDto playlist)
        {
            try
            {
                if (playlist == null)
                {
                    _logger.LogError("Playlist object sent from the client is null.");
                    return BadRequest("Playist object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid playlist object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var playlistEntity = _mapper.Map<Playlist>(playlist);

                _repoWrapper.Playlist.CreatePlaylist(playlistEntity);
                _repoWrapper.Save();

                var createdPlaylist = _mapper.Map<PlaylistDto>(playlistEntity);

                return CreatedAtRoute("PlaylistById", new { id = createdPlaylist.Id }, createdPlaylist);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreatePlaylist action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
