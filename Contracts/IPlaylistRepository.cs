using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using playlist_app_backend.Entities.Models;

namespace playlist_app_backend.Contracts
{
    public interface IPlaylistRepository : IRepositoryBase<Playlist>
    {
        IEnumerable<Playlist> GetAllPlaylists();
        Playlist GetPlaylistById(int playlistId);
        IEnumerable<Tag> GetTagsForPlaylist(int playlistId);
        bool Exists(int playlistId);

        void CreatePlaylist(Playlist playlist);
        void UpdatePlaylist(Playlist playlist);
        void DeletePlaylist(Playlist playlist);
    }
}
