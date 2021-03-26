using AutoMapper;
using playlist_app_backend.Entities.DataTransferObjects;
using playlist_app_backend.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace playlist_app_backend
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Playlist, PlaylistDto>(); // GET

            CreateMap<PlaylistForCreationDto, Playlist>(); // POST

            CreateMap<PlaylistForUpdateDto, Playlist>(); // PUT

            CreateMap<Tag, TagDto>();

            CreateMap<TagForCreationDto, Tag>();
        }
    }
}
