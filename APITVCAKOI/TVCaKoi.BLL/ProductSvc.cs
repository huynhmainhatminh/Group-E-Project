using QLBH.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVcaKoi.Common.BLL;
using TVcaKoi.Common.Rsp;
using TVCaKoi.Common.Res;
using TVCaKoi.DAL;
using TVCaKoi.DAL.Models;

namespace TVCaKoi.BLL
{
    public class ProductSvc : GenericSvc<ProductRep, Product>
    {
        private ProductRep productRep;

        public ProductSvc() {
            productRep = new ProductRep();
        }

        public override SingleRsp Read(int id_type_product)
        {
            var res = new SingleRsp();
            res.Data = _rep.SearchALLProduct(id_type_product);
            if (id_type_product == 1) {
                res.SetSuccess("200", "Hồ cá");
            }else if (id_type_product == 2)
            {
                res.SetSuccess("200", "Cá koi");
            }
            else if (id_type_product == 3)
            {
                res.SetSuccess("200", "Sản phẩm chăm sóc cá");
            }
            else if(id_type_product == 4)
            {
                res.SetSuccess("200", "Sản phẩm trang trí");
            }
            else if( id_type_product == 5)
            {
                res.SetSuccess("200", "Thiết bị");
            }
            else if ( id_type_product == 6)
            {
                res.SetSuccess("200", "Phụ kiện");
            }
            else
            {
                res.SetSuccess("200", "Khác");
            }
            return res;
        }

        public SingleRsp PagingProduct(int pages, int id_type_product)
        {
            int size = 8;
            var res = new SingleRsp();
            var search_all_product = productRep.SearchALLProduct(id_type_product);
            int pCount, totalPages, offset;

            offset = size * (pages - 1);
            pCount = search_all_product.Count;

            totalPages = (pCount % size) == 0 ? pCount / size : 1 + (pCount / size);
            var p = new
            {
                Data = search_all_product.Skip(offset).Take(size).ToList(),
                Page = pages,
                Size = size
            };
            res.Data = p;
            return res;

        }

        public SingleRsp GetCountProduct(int id_type_product)
        {
            var res = new SingleRsp();
            res.Data = _rep.GetCountProduct(id_type_product);
            if (id_type_product == 1)
            {
                res.SetSuccess("200", "Hồ cá");
            }
            else if (id_type_product == 2)
            {
                res.SetSuccess("200", "Cá koi");
            }
            else if (id_type_product == 3)
            {
                res.SetSuccess("200", "Sản phẩm chăm sóc cá");
            }
            else if (id_type_product == 4)
            {
                res.SetSuccess("200", "Sản phẩm trang trí");
            }
            else if (id_type_product == 5)
            {
                res.SetSuccess("200", "Thiết bị");
            }
            else if (id_type_product == 6)
            {
                res.SetSuccess("200", "Phụ kiện");
            }
            else
            {
                res.SetSuccess("200", "Khác");
            }
            return res;
        }

    }
}
