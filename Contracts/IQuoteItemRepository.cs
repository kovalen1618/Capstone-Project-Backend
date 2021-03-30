using playlist_app_backend.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace playlist_app_backend.Contracts
{
    public interface IQuoteItemRepository: IRepositoryBase<QuoteItem>
    {
        IEnumerable<QuoteItem> GetAllQuoteItems();
        QuoteItem GetQuoteItemById(int itemId);
        void CreateQuoteItem(QuoteItem quoteItem);
        void UpdateQuoteItem(QuoteItem quoteItem);
        void DeleteQuoteItem(QuoteItem quoteItem);
    }
}
