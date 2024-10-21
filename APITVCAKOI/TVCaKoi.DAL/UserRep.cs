using TVcaKoi.Common.DAL;
using TVcaKoi.Common.Rsp;
using TVCaKoi.Common.Res;
using TVCaKoi.DAL.Models;

namespace QLBH.DAL
{
    public class UserRep : GenericRep<ApptvcakoiContext, QlUser>
    {
        public UserRep()
        {

        }
        public override QlUser Read(int id)
        {
            var res = All.FirstOrDefault(c => c.IdUser == id);
            return res;
        }

        public override QlUser Read(string key)
        {
            var res = All.FirstOrDefault(c => c.Username == key);
            return res;
        }

        public string Remove(string key)
        {
            // Tìm đối tượng cần xóa
            var userToDelete = base.All.FirstOrDefault(c => c.Username == key);

            // Kiểm tra nếu người dùng tồn tại
            if (userToDelete != null)
            {
                // Xóa người dùng
                userToDelete = base.Delete(userToDelete);
                base.Context.SaveChanges();
                return userToDelete.Username; // Trả về Username của người dùng đã xóa
            }
            else
            {
                throw new KeyNotFoundException("User not found!"); // Ném lỗi nếu không tìm thấy
            }
        }

        public SingleRsp RegisterUser(QlUser qluser)
        {
            var res = new SingleRsp();
            using (var context = new ApptvcakoiContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.QlUsers.Add(qluser);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }

        public SingleRsp UpdateAccessUser(QlUser qluser)
        {
            var res = new SingleRsp();
            using (var context = new ApptvcakoiContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        // Tìm người dùng hiện có dựa trên Username (hoặc ID nếu có)
                        var existingUser = context.QlUsers.FirstOrDefault(u => u.Username == qluser.Username);

                        if (existingUser != null)
                        {
                            // Cập nhật thông tin người dùng
      
                            existingUser.AccessUser = qluser.AccessUser;

                            context.SaveChanges();
                            tran.Commit();
                        }
                        else
                        {
                            res.SetError("User not found!");
                        }
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
    }

}
