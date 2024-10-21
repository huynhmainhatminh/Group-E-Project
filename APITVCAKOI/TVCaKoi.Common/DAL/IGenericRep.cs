using System.Linq.Expressions;

namespace TVcaKoi.Common.DAL
{
    public interface IGenericRep<T> where T : class
    {
        #region --Methods--
        void Create(T m);

        void Create(List<T> m);

        IQueryable<T> Read(Expression<Func<T, bool>> p);

        T Read(int id);

        T Read(string code);

        void Update(T m);

        void Update(List<T> l);
        #endregion

        #region --Properties--
        IQueryable<T> All { get; }
        #endregion
    }
}
