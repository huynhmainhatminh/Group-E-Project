using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TVcaKoi.Common.DAL
{
    public class GenericRep<C, T> : IGenericRep<T> where T : class where C : DbContext, new()
    {
        #region -- Implements --
        public void Create(T m)
        {
            _context.Set<T>().Add(m);
            _context.SaveChanges();
        }

        public void Create(List<T> l)
        {
            _context.Set<T>().AddRange(l);
            _context.SaveChanges();
        }

        public IQueryable<T> Read(Expression<Func<T, bool>> p)
        {
            return _context.Set<T>().Where(p);
        }
        public virtual T Read(int id)
        {
            return null;
        }

        public virtual T Read(string code)
        {
            return null;
        }

        public void Update(T m)
        {
            _context.Set<T>().Update(m);
            _context.SaveChanges();
        }

        public void Update(List<T> l)
        {
            _context.Set<T>().UpdateRange(l);
            _context.SaveChanges();
        }

        public IQueryable<T> All
        {
            get
            {
                return _context.Set<T>();
            }
        }
        #endregion

        #region --Methods--
        public GenericRep()
        {
            _context = new C();
        }

        protected object Update(T old, T @new)
        {
            _context.Entry(old).State = EntityState.Modified;
            var res = _context.Set<T>().Add(@new);
            return res;
        }

        protected T Delete(T m)
        {
            var t = _context.Set<T>().Remove(m);
            return t.Entity;
        }
        #endregion

        #region --Properties--
        public C Context
        {
            get { return _context; }
            set { _context = value; }
        }
        #endregion

        #region --Fields--
        private C _context;
        #endregion
    }
}
