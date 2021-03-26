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

        void CreateTag(Tag tag);
    }
}
