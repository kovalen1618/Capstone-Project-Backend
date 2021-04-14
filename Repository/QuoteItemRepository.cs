using Microsoft.EntityFrameworkCore;
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
        private RepositoryContext _repoContext;

        public QuoteItemRepository(RepositoryContext repoContext)
            : base(repoContext)
        {
            _repoContext = repoContext;
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
                .OrderBy(qi => qi.Id)
                .ToList();
        }

        public IEnumerable<QuoteItem> GetQuoteItemsForPlaylist(int playlistId)
        {
            var playlist = _repoContext.Playlists.Include(pl => pl.QuoteItems)
                    .SingleOrDefault(pl => pl.Id == playlistId);
            return playlist?.QuoteItems.ToList();
        }

        public QuoteItem GetQuoteItemById(int itemId)
        {
            return FindByCondition(qi => qi.Id.Equals(itemId))
                .FirstOrDefault();
        }

        public void UpdateQuoteItem(QuoteItem quoteItem)
        {
            Update(quoteItem);
        }
    }
}
