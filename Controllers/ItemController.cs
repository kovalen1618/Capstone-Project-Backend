using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using playlist_app_backend.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace playlist_app_backend.Controllers
{
    [Route("playlist/{playlistId}/items")]
    [ApiController]
    public class ItemController
    {
        private IRepositoryWrapper _repoWrapper;
        private IMapper _mapper;
        private ILoggerManager _logger;

        public ItemController(IRepositoryWrapper repoWrapper, IMapper mapper, ILoggerManager logger)
        {
            _repoWrapper = repoWrapper;
            _mapper = mapper;
            _logger = logger;
        }
        
    }
}
