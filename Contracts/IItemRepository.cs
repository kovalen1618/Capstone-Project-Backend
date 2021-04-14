using playlist_app_backend.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace playlist_app_backend.Contracts
{
    public interface IItemRepository: IRepositoryBase<Item>
    {
       
        Item GetItemById(int itemId);
        void CreateItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(Item item);
    }
}
