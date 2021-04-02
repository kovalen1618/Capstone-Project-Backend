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
        private RepositoryContext _repoContext;
        public TagRepository(RepositoryContext repoContext)
            : base(repoContext)
        {
            _repoContext = repoContext;
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

        public bool Exists(int entityId)
        {
            var tagCount = _repoContext.Tags.Count(pl => pl.Id == entityId);

            return tagCount == 1;
        }

        public bool Exists(string name)
        {
            var tagCount = _repoContext.Tags.Count(pl => pl.Name == name);

            return tagCount == 1;
        }

        public void CreateTag(Tag tag)
        {
            Create(tag);
        }

        public void UpdateTag(Tag tag)
        {
            Update(tag);
        }

        public void DeleteTag(Tag tag)
        {
            Delete(tag);
        }
    }
}
