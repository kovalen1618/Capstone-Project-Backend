using playlist_app_backend.Contracts;
using playlist_app_backend.Entities;
using playlist_app_backend.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace playlist_app_backend.Repository
{
    public class PlaylistTagRepository : RepositoryBase<PlaylistTag>, IPlaylistTagRepository
    {
        private readonly RepositoryContext _repoContext;
        private readonly IPlaylistRepository _playlistRepository;
        private readonly ITagRepository _tagRepository;

        public PlaylistTagRepository(RepositoryContext repoContext, IPlaylistRepository playlistRepository, 
            ITagRepository tagRepository) : base(repoContext)
        {
            _repoContext = repoContext;
            _playlistRepository = playlistRepository;
            _tagRepository = tagRepository;
        }

        private bool PlaylistAndTagExist(int playlistId, int tagId)
        {
            return _playlistRepository.Exists(playlistId) && _tagRepository.Exists(tagId);
        }
        private bool PlaylistHasTag(int playlistId, int tagId)
        {
            var playlistTagCount = _repoContext.PlaylistTags.Count(plTag =>
                plTag.PlaylistId == playlistId && plTag.TagId == tagId);

            return playlistTagCount == 1;
        }

        public bool CanTagBeAdded(int playlistId, int tagId)
        {
            if (!PlaylistAndTagExist(playlistId, tagId))
            {
                return false;
            }

            return !PlaylistHasTag(playlistId, tagId);
        }
        public bool CanTagBeRemoved(int playlistId, int tagId)
        {
            return PlaylistAndTagExist(playlistId, tagId) &&
                   PlaylistHasTag(playlistId, tagId);
        }

        public void AddTagToPlaylist(int playlistId, int tagId)
        {
            // var playlist = _repoContext.Playlists.Find(playlistId);
            // var tag = _repoContext.Tags.Find(tagId);
            var playlistTag = new PlaylistTag { PlaylistId = playlistId, TagId = tagId };

            Create(playlistTag);
        }
        public void RemoveTagFromPlaylist(int playlistId, int tagId)
        {
            // var playlistTagProxy = new PlaylistTag { PlaylistId = playlistId, TagId = tagId };
            var playlistTag = FindByCondition(playlistTag => playlistTag.PlaylistId.Equals(playlistId)
                && playlistTag.TagId.Equals(tagId)).FirstOrDefault();

            Delete(playlistTag);
        }
    }
}
