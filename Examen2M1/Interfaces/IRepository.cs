using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Examen2M1.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Create(T t);
        bool Update(T t);
        bool Delete(T t);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> where);
    }
}
