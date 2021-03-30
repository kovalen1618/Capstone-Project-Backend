using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace playlist_app_backend.Contracts
{
    public interface IRepositoryWrapper
    {
        IPlaylistRepository Playlist { get; }
        ITagRepository Tag { get; }

        void Save();
    }
}
