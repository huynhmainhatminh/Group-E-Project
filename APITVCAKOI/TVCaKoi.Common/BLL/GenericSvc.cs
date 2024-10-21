using System.Linq.Expressions;


namespace TVcaKoi.Common.BLL
{
    using DAL;
    using Rsp;

    public class GenericSvc<D, T> : IGenericSvc<T> where T : class where D : IGenericRep<T>, new()
    {
        #region --Implements--
        public virtual SingleRsp Create(T m)
        {
            var res = new SingleRsp();
            try
            {
                var now = DateTime.Now;
                _rep.Create(m);
            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }
            return res;
        }

        public virtual MultipleRsp Create(List<T> l)
        {
            var res = new MultipleRsp();
            try
            {
                _rep.Create(l);
            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }
            return res;
        }
        public IQueryable<T> Read(Expression<Func<T, bool>> p)
        {
            return _rep.Read(p);
        }

        public virtual SingleRsp Read(int id)
        {
            return null;
        }


        public virtual SingleRsp Read(string code)
        {
            return null;
        }

        public virtual SingleRsp Update(T m)
        {
            var res = new SingleRsp();
            try
            {
                _rep.Update(m);
            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }
            return res;
        }

        public virtual MultipleRsp Update(List<T> l)
        {
            var res = new MultipleRsp();
            try
            {
                _rep.Update(l);
            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }
            return res;
        }
        public virtual SingleRsp Delete(int id)
        {
            return null;
        }
        public virtual SingleRsp Delete(string code)
        {
            return null;
        }
        public virtual SingleRsp Restore(int id)
        {
            return null;
        }
        public virtual SingleRsp Restore(string code)
        {
            return null;
        }
        public virtual int Remove(int id)
        {
            return 0;
        }

        public IQueryable<T> All
        {
            get
            {
                return _rep.All;
            }
        }
        #endregion

        #region --Methods--
        public GenericSvc()
        {
            _rep = new D();
        }
        #endregion

        #region --Fields--
        protected D _rep;
        #endregion
    }
}
