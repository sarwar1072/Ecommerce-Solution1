using Ecommerce.Framework.BusinessObj;
using Ecommerce.Framework.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BO = Ecommerce.Framework.BusinessObj;
using EO = Ecommerce.Framework.Entity;

namespace Ecommerce.Framework.Services
{
    public class ShopService : IShopService
    {
        private IShoppingUnitOfWork _shoppingUnitOfWork;
        public ShopService(IShoppingUnitOfWork shoppingUnitOfWork)
        {
            _shoppingUnitOfWork = shoppingUnitOfWork;

        }

        public void CreatCategory(string Name)
        {
            CreatCategory(new CategoryInfo { Name = Name });
        }

        public void CreatCategory(CategoryInfo category)
        {
            if (category == null)
                throw new InvalidOperationException("Category is empty");

            if (!category.IsValid())
                throw new InvalidOperationException("name must be provided to create category");
            _shoppingUnitOfWork.CategoryRepository.Add(new EO.Category 
            { 
                Name=category.Name
            
            });
            _shoppingUnitOfWork.Save();
        }

        public void CreateProduct(BO.Product product)
        {
            var productEntity = new EO.Product() { 
                        Name=product.Name,
                        Price=product.Price,
                        Images=new List<EO.ProductImage>()
            
            };
            foreach (var image in product.Images)
            {
                productEntity.Images.Add(new EO.ProductImage{ 
                      Url=image.Location,
                      AlternativeText=image.AlternativeText
                });

            }
            _shoppingUnitOfWork.ProductRepository.Add(productEntity);
            _shoppingUnitOfWork.Save();
        }

        public BO.Product GetProduct(int id)
        {
            var productEntity = _shoppingUnitOfWork.ProductRepository.Get(x => x.Id == id, orderBy: null
                , "Images", true).FirstOrDefault();

            return BO.Product.ConvertToSelf(productEntity);
        }

      public (int total, int totalDisplay, IList<BO.Product> records) GetProductList(int pageIndex,
          int pageSize, string searchText, string orderBy)
        {

            (IList<EO.Product> data, int total, int totalDisplay) result = (null, 0, 0);

            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _shoppingUnitOfWork.ProductRepository.GetDynamic(null,
                   orderBy, "Categories,Images", pageIndex, pageSize, true);
            }
            else
            {
                result = _shoppingUnitOfWork.ProductRepository.GetDynamic(x => x.Name == searchText,
                   orderBy, "Categories,Images", pageIndex, pageSize, true);
            }

            var data = (from x in result.data
                        select new BO.Product
                        {
                            Id=x.Id,
                            Name = x.Name,
                            Price = x.Price,
                            Images=(from y in x.Images
                                    select new BO.Image
                                    {
                                        Id=y.Id,
                                        Location=y.Url,
                                        AlternativeText=y.AlternativeText
                                    }).ToList()
                        }).ToList();
            return (result.total,result.totalDisplay,data);
        }
        public void UpdateProduct(BO.Product product)
        {
            var producyEntity = _shoppingUnitOfWork.ProductRepository.Get(x => x.Id == product.Id, orderBy: null,
                "Images", true).FirstOrDefault();

            producyEntity.Name = product.Name;

            producyEntity.Price = product.Price;
            producyEntity.Images.Clear();
            producyEntity.Images = (from x in product.Images select new EO.ProductImage { 
                              AlternativeText=x.AlternativeText,
                              Url=x.Location,

            }).ToList();
            _shoppingUnitOfWork.Save();
        }

        public void DeleteProduct(int id)
        {
            var product = _shoppingUnitOfWork.ProductRepository.Get(x => x.Id == id, "Images").FirstOrDefault();
            _shoppingUnitOfWork.ProductRepository.Remove(product);
            _shoppingUnitOfWork.Save();
        }

    }
}
