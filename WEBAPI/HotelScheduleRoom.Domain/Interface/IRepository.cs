using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelScheduleRoom.Domain.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<int> Insert(TEntity entity);
        Task<int> Update(TEntity entity);

        Task<int> Delete(int id);
        Task<List<TEntity>> GetAll();
        Task<TEntity> Get(Expression<Func<TEntity,bool>> predicate = null);

    }
}
