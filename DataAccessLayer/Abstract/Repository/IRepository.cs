using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        void Create(T entity);
        List<T> ReadAll();
        List<T> Read(Expression<Func<T,bool>> filter);
        void Update(T entity);
        void Delete(T entity);
        T Get (Expression<Func<T,bool>> filter);

    }
}
