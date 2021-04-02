using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using playlist_app_backend.Contracts;
using playlist_app_backend.Entities;
using playlist_app_backend.Entities.Models;

namespace playlist_app_backend.Repository
{
    public class PlaylistRepository : RepositoryBase<Playlist>, IPlaylistRepository 
    {
        private RepositoryContext _repoContext;
        public PlaylistRepository(RepositoryContext repoContext) 
            : base(repoContext)
        {
            _repoContext = repoContext;
        }

        public IEnumerable<Playlist> GetAllPlaylists()
        {
            return FindAll()
                .OrderBy(pl => pl.Name)
                .ToList();
        }

        public Playlist GetPlaylistById(int playlistId)
        {
            return FindByCondition(playlist => playlist.Id.Equals(playlistId))
                .FirstOrDefault();
        }

        public IEnumerable<Tag> GetTagsForPlaylist(int playlistId)
        {
            var playlist = _repoContext.Playlists.Include(pl => pl.PlaylistTags)
                .ThenInclude(plTag => plTag.Tag)
                .SingleOrDefault(pl => pl.Id == playlistId);

            return playlist?.PlaylistTags.Select(plTag => plTag.Tag).ToList();
        }

        public bool Exists(int id)
        {
            var playlistCount = _repoContext.Playlists.Count(pl => pl.Id == id);

            return playlistCount == 1;
        }

        public void UpdatePlaylist(Playlist playlist)
        {
            Update(playlist);
        }

        public void CreatePlaylist(Playlist playlist)
        {
            Create(playlist);
        }
        public void DeletePlaylist(Playlist playlist)
        {
            Delete(playlist);
        }

    }
}
