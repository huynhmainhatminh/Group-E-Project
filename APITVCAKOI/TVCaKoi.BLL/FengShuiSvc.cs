using QLBH.DAL;
using TVcaKoi.Common.BLL;
using TVcaKoi.Common.Rsp;
using TVCaKoi.Common.Res;
using TVCaKoi.DAL;
using TVCaKoi.DAL.Models;

namespace TVCaKoi.BLL
{
    public class FengShuiSvc: GenericSvc<FengShuiRep, QlParameter>
    {
        private FengShuiRep fengshuiRep;
        public FengShuiSvc()
        {
            fengshuiRep = new FengShuiRep();
        }
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }

        public override SingleRsp Read(string key)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(key);
            return res;
        }
    }
}
