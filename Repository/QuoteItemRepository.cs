using playlist_app_backend.Contracts;
using playlist_app_backend.Entities;
using playlist_app_backend.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace playlist_app_backend.Repository
{
    public class QuoteItemRepository : RepositoryBase<QuoteItem>, IQuoteItemRepository
    {
        public QuoteItemRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateQuoteItem(QuoteItem quoteItem)
        {
            Create(quoteItem);
        }

        public void DeleteQuoteItem(QuoteItem quoteItem)
        {
            Delete(quoteItem);
        }

        public IEnumerable<QuoteItem> GetAllQuoteItems()
        {
            return FindAll()
                .OrderBy(pl => pl.Id)
                .ToList();
        }

        public QuoteItem GetQuoteItemById(int playlistId)
        {
            return FindByCondition(playlist => playlist.Id.Equals(playlistId))
                .FirstOrDefault();
        }

        public void UpdateQuoteItem(QuoteItem quoteItem)
        {
            Update(quoteItem);
        }
    }
}
