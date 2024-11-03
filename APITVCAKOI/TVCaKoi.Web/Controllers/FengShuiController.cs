using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TVcaKoi.BLL;
using TVcaKoi.Common.Rsp;
using TVCaKoi.BLL;

namespace TVCaKoi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FengShuiController : ControllerBase
    {
        private FengShuiSvc fengshuiSvc;

        public FengShuiController()
        {
            fengshuiSvc = new FengShuiSvc();
        }

        [HttpGet("get-phongthuy-id")]
        public IActionResult GetPhongThuyByIDType([FromQuery] int Id)
        {
            var res = new SingleRsp();
            res = fengshuiSvc.Read(Id);
            return Ok(res);
        }

        [HttpGet("get-phongthuy-name")]
        public IActionResult GetPhongThuyByNameType([FromQuery] string Keyword)
        {
            var res = new SingleRsp();
            res = fengshuiSvc.Read(Keyword);
            return Ok(res);
        }
    }
}
