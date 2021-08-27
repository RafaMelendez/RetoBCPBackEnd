using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace CalCambApi.Infraestructure.UnitOfWork.Repository.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        T Get(Guid id);
        IList<T> List();
        IList<T> List(Expression<Func<T, bool>> expression);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
