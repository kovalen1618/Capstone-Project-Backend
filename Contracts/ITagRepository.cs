using playlist_app_backend.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace playlist_app_backend.Contracts
{
    public interface ITagRepository : IRepositoryBase<Tag>
    {
        IEnumerable<Tag> GetAllTags();
        Tag GetTagById(int tagId);
        IEnumerable<Playlist> GetPlaylistsForTag(int tagId);
        bool Exists(int tagId);
        bool Exists(string name);

        void CreateTag(Tag tag);
        void UpdateTag(Tag tag);
        void DeleteTag(Tag tag);
    }
}
