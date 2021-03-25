using playlist_app_backend.Contracts;
using playlist_app_backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace playlist_app_backend.Repository
{
    
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IPlaylistRepository _playlist;
        public IPlaylistRepository Playlist
        {
            get
            {
                if (_playlist == null)
                {
                    _playlist = new PlaylistRepository(_repoContext);
                }
                return _playlist;
            }
        }
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public void Save()
        {
             _repoContext.SaveChanges();
        }
    }
}
