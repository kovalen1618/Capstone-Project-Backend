using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using playlist_app_backend.Contracts;
using playlist_app_backend.Entities.DataTransferObjects;
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

        public PlaylistController(IRepositoryWrapper repoWrapper, IMapper mapper)
        {
            _repoWrapper = repoWrapper;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllPlaylists()
        {
            var playlists = _repoWrapper.Playlist.GetAllPlaylists();

            var playlistsResult = _mapper.Map<IEnumerable<PlaylistDto>>(playlists);
            
            return Ok(playlistsResult);
        }

        [HttpGet("{id}")]
        public IActionResult GetPlaylistById(int id)
        {
            var playlist = _repoWrapper.Playlist.GetPlaylistById(id);

            if (playlist == null)
            {
                return NotFound();
            }
            else
            {
                var playlistResult = _mapper.Map<PlaylistDto>(playlist);
                return Ok(playlistResult);
            }
        }

    }
}
