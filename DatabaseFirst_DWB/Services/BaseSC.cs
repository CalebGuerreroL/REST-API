using DatabaseFirst_DWB.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst_DWB.Services
{
    public class BaseSC
    {
        protected NorthwindContext dataContext = new();
    }

    public interface IActions<T, U, V> 
        where T : class
        where U : class
        where V : notnull
    {
        IQueryable<T> GetAll();
        T Get(V id);
        void Add(U obj);
        void Update(V id, U obj);
        void Delete(V id);
    }

    public abstract class FilterController<T> where T : class
    {
        public abstract IQueryable<T> FilterBy(FilterSpecification<T> filter);
    }

    public abstract class FilterSpecification<T> where T : class
    {
        public IQueryable<T> Filter(IQueryable<T> list)
        {
            return ApplyFilter(list);
        }

        protected abstract IQueryable<T> ApplyFilter(IQueryable<T> list);
    }
}
