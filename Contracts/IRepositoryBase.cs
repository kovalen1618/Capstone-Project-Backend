using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace playlist_app_backend.Contracts
{
    public interface IRepositoryBase<T> // The <T> is a standin for any of the playlist item types i.e. T is QuoteItem
                                        // or T is VideoItem
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
