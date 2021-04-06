using playlist_app_backend.Contracts;
using playlist_app_backend.Entities;
using playlist_app_backend.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace playlist_app_backend.Repository
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        private RepositoryContext _repoContext;
        public ItemRepository(RepositoryContext repoContext) :base(repoContext)
        {
            _repoContext = repoContext;
        } 
        public void CreateItem(Item item)
        {
            Create(item);
        }

        public void DeleteItem(Item item)
        {
            Delete(item);
        }

        public Item GetItemById(int itemId)
        {
            return FindByCondition(item => item.Id.Equals(itemId))
                .FirstOrDefault();
        }

        public IEnumerable<Item> GetItemsForPlaylist(int playlistId)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            Update(item);
        }
    }
}
