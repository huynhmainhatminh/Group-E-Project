using TVcaKoi.Common.DAL;
using TVcaKoi.Common.Rsp;
using TVCaKoi.Common.Res;
using TVCaKoi.DAL.Models;

namespace TVCaKoi.DAL
{
    public class FengShuiRep: GenericRep<ApptvcakoiContext, QlParameter>
    {
        public FengShuiRep() { }

        public override QlParameter Read(int id)
        {
            var res = All.FirstOrDefault(c => c.IdqlParameter == id);
            return res;
        }

        public override QlParameter Read(string key)
        {
            var res = All.FirstOrDefault(c => c.NameDestiny == key);
            return res;
        }
    }
}
