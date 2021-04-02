using playlist_app_backend.Entities.Models;
using playlist_app_backend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace playlist_app_backend.Contracts
{
    public interface IPlaylistTagRepository : IRepositoryBase<PlaylistTag>
    {
        bool CanTagBeAdded(int playlistId, int tagId);
        bool CanTagBeRemoved(int playlistId, int tagId);
        void AddTagToPlaylist(int playlistId, int tagId);
        void RemoveTagFromPlaylist(int playlistId, int tagId);
    }
}
