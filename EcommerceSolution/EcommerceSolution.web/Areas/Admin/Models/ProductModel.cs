using Autofac;
using Ecommerce.Framework.Services;
using EcommerceSolution.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EcommerceSolution.web.Areas.Admin.Models
{
    public class ProductModel:BaseModel
    {
        private readonly IShopService _shopService;
        public ProductModel(IShopService shopService)
        {
            _shopService = shopService;
        }
        public ProductModel()
        {
            _shopService = Startup.AutofacContainer.Resolve<IShopService>();
        }
        internal object GetProducts(DataTablesAjaxRequestModel tableModel)
        {
            var data = _shopService.GetProductList(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Name", "Price" }));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Name,
                             record.Price.ToString(),
                             FormatImageUrl(record.Images?.FirstOrDefault()?.Location),
                           // record.Images?.FirstOrDefault()?.Location,
                           
                            record.Id.ToString()
                        }
                    ).ToArray()
            };
        }
    }
}
