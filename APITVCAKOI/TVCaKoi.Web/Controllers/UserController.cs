using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TVcaKoi.BLL;
using TVcaKoi.Common.Res;
using TVcaKoi.Common.Rsp;
using TVCaKoi.Common.Res;

namespace TVCaKoi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserSvc userSvc;
        public UserController()
        {
            userSvc = new UserSvc();

        }
        [HttpPost("get-by-id-user")]
        public IActionResult GetUserByID([FromQuery] int Id)
        {
            var res = new SingleRsp();
            res = userSvc.Read(Id);
            return Ok(res);
        }

        [HttpPost("get-by-name-user")]
        public IActionResult GetUserByName([FromQuery] string Keyword)
        {
            var res = new SingleRsp();
            res = userSvc.Read(Keyword);
            return Ok(res);
        }

        [HttpPost("register-user")]
        public IActionResult RegisterUser([FromBody] UserReq userReq)
        {
            var res = new SingleRsp();
            res = userSvc.RegisterUser(userReq);
            return Ok(res);
        }

        [HttpPost("update-access-user")]
        public IActionResult UpdateAccessUser([FromBody] AccessUserReq accessuserReq)
        {
            var res = new SingleRsp();
            res = userSvc.UpdateAccessUser(accessuserReq);
            return Ok(res);
        }

        [HttpDelete("remove-user")]
        public IActionResult RemoveUser([FromQuery] string keyword)
        {
            var res = new SingleRsp();
            res = userSvc.Remove(keyword);
            return Ok(res);
        }

    }
}
