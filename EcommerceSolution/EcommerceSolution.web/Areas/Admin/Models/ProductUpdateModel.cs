using Autofac;
using Ecommerce.Framework.BusinessObj;
using Ecommerce.Framework.Services;
using EcommerceSolution.web.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EI=Ecommerce.Framework.Entity;

namespace EcommerceSolution.web.Areas.Admin.Models
{
    public class ProductUpdateModel: BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }
        public IFormFile ImageFile { get; set; }


        private readonly IPurchaseService _purchaseService;
        private readonly IShopService _shopingService;

        public ProductUpdateModel()
        {
            _shopingService = Startup.AutofacContainer.Resolve<IShopService>();
            _purchaseService = Startup.AutofacContainer.Resolve<IPurchaseService>();
        }

         internal void UpdateProduct()
        {
            var product = ConvertToProduct();
            _shopingService.UpdateProduct(product);
        }


        private Product ConvertToProduct()
        {
            var product = new Product { 
                       Id=Id,
                       Name=Name,
                       Price=Price
            };
            if (ImageFile != null)
            {
                var imageInfo = StoreFile(ImageFile);
                product.Images = new List<Image>();
                product.Images.Add(new Image { 
                     Location=imageInfo.filePath,
                    AlternativeText =$"{product.Name} Image"
                });

            }
            return product;

        }
        public void CreateProduct()
        {
            var product = ConvertToProduct();
            _shopingService.CreateProduct(product);
        }

        public void addproduct()
        {
            var CProduct = new EI.Product()
            {
                Name = this.Name,
                Price = this.Price,
               
               
            };

            //productResult.Images = (from y in product.Images
            //                        select new Image
            //                        {
            //                            Id = y.Id,
            //                            Location = y.Url,
            //                            AlternativeText = y.AlternativeText
            //                        }).ToList();


            _purchaseService.AddProduct(CProduct);
            // Response = new ResponseModel("book creation success", ResponseType.Success);
        }


        internal void LoadData(int id)
        {
            var product = _shopingService.GetProduct(id);
            if (product != null)
            {
                Name = product.Name;
                Price = product.Price;
                Id = product.Id;
                    ImagePath = FormatImageUrl(product.Images?.FirstOrDefault()?.Location);
            }
        }

        internal void DeleteProduct()
        {
            _shopingService.DeleteProduct(Id);
        }
    }
}
