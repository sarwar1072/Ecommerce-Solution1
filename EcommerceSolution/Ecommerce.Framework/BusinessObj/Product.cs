using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EO= Ecommerce.Framework.Entity;
namespace Ecommerce.Framework.BusinessObj
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public IList<Image> Images { get; set; }

        public static Product ConvertToSelf(EO.Product product)
        {
            var productResult = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,

            };
            if (product.Images != null)
            {
                productResult.Images = (from y in product.Images
                                        select new Image
                                        {
                                            Id = y.Id,
                                            Location = y.Url,
                                            AlternativeText = y.AlternativeText
                                        }).ToList();
            }
            return productResult;
        }
        public static EO.Product ConvertToEntity(Product product)
        {
            var productResult = new EO.Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
            };

            productResult.Images = (from x in product.Images
                                    select new EO.ProductImage
                                    {
                                        AlternativeText = x.AlternativeText,
                                        Id = x.Id,
                                        Url = x.Location
                                    }).ToList();

            return productResult;
        }
    }
}
