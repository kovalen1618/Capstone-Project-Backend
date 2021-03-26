using playlist_app_backend.Contracts;
using playlist_app_backend.Entities;
using playlist_app_backend.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace playlist_app_backend.Repository
{
    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Tag> GetAllTags()
        {
            return FindAll()
                .OrderBy(tg => tg.Name)
                .ToList();
        }

        public Tag GetTagById(int tagId)
        {
            return FindByCondition(tag => tag.Id.Equals(tagId))
                .FirstOrDefault();
        }

        public void CreateTag(Tag tag)
        {
            Create(tag);
        }
    }
}
