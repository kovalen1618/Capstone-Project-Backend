using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using playlist_app_backend.Contracts;
using playlist_app_backend.Entities;
using playlist_app_backend.Entities.Models;

namespace playlist_app_backend.Repository
{
    public class PlaylistRepository : RepositoryBase<Playlist>, IPlaylistRepository 
    {
        public PlaylistRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }
    }
}
