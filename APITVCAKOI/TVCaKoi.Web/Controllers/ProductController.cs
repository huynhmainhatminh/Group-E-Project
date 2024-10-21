using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TVcaKoi.BLL;
using TVcaKoi.Common.Rsp;
using TVCaKoi.BLL;

namespace TVCaKoi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductSvc productSvc;
        public ProductController()
        {
            productSvc = new ProductSvc();
        }
        [HttpGet("get-product-id")]
        public IActionResult GetProductByIDType([FromQuery] int Id)
        {
            var res = new SingleRsp();
            res = productSvc.Read(Id);
            return Ok(res);
        }

        [HttpGet("get-product")]
        public IActionResult GetProductPages([FromQuery] int Pages, int Id_Type)
        {
            var res = new SingleRsp();
            res = productSvc.PagingProduct(Pages, Id_Type);
            return Ok(res);
        }
        [HttpGet("get-count-product")]
        public IActionResult GetCountProduct([FromQuery] int Id_Type)
        {
            var res = new SingleRsp();
            res = productSvc.GetCountProduct(Id_Type);
            return Ok(res);
        }
    }
}
