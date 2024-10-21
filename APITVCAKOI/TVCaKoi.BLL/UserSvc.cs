using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVcaKoi.Common.BLL;
using TVcaKoi.Common.Rsp;
using QLBH.DAL;
using TVcaKoi.Common.BLL;
using TVcaKoi.Common.Rsp;
using TVCaKoi.DAL.Models;
using TVCaKoi.Common.Res;

namespace TVcaKoi.BLL
{
    public class UserSvc : GenericSvc<UserRep, QlUser>
    {
        private UserRep userRep;
        public UserSvc()
        {
            userRep = new UserRep();
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

        public SingleRsp Remove(string key)
        {
            var res = new SingleRsp();
            try
            {
                // Gọi phương thức Remove để xóa người dùng
                var username = _rep.Remove(key);

                // Gán kết quả vào Data của SingleRsp
                res.Data = username;
                res.SetSuccess("200", "User removed successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                res.SetError(ex.Message);
            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }

            return res;
        }
        public SingleRsp UpdateAccessUser(AccessUserReq accessuserReq)
        {
            var res = new SingleRsp();
            QlUser qluser = new QlUser();
            qluser.Username = accessuserReq.Username;
            qluser.AccessUser = accessuserReq.AccessUser;
            res = userRep.UpdateAccessUser(qluser);
            return res;
        }

        public SingleRsp RegisterUser(UserReq userReq)
        {
            var res = new SingleRsp();
            QlUser qluser = new QlUser();
            qluser.NameUser = userReq.NameUser;
            qluser.Username = userReq.Username;
            qluser.PassUser = userReq.PassUser;
            res = userRep.RegisterUser(qluser);
            return res;
        }


    }
}
