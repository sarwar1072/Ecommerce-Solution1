using Ecommerce.Framework.BusinessObj;
using System;
using System.Collections.Generic;
using System.Text;
//using Ecommerce.Framework.Entity;
namespace Ecommerce.Framework.Services
{
  public  interface IShopService
    {
        void CreatCategory(string Name);
        void CreatCategory(CategoryInfo category);

        (int total, int totalDisplay, IList<Product> records) GetProductList(int pageIndex,
          int pageSize, string searchText, string orderBy);

        void CreateProduct(Product product);

        
        Product GetProduct(int id);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
