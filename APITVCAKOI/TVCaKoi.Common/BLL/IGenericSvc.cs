using System.Linq.Expressions;
using TVcaKoi.Common.Rsp;

namespace TVcaKoi.Common.BLL
{
    public interface IGenericSvc<T> where T : class
    {
        #region --Methods--
        SingleRsp Create(T m);

        MultipleRsp Create(List<T> l);

        IQueryable<T> Read(Expression<Func<T, bool>> p);

        SingleRsp Read(int id);

        SingleRsp Read(string code);

        SingleRsp Update(T m);

        MultipleRsp Update(List<T> l);

        SingleRsp Delete(int id);

        SingleRsp Delete(string code);

        SingleRsp Restore(int id);
        SingleRsp Restore(string code);


        int Remove(int id);

        #endregion



        #region --Properties--
        IQueryable<T> All { get; }
        #endregion


    }
}
