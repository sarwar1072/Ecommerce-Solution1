using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Framework.Entity
{
   public class Product: IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public IList<ProductImage> Images { get; set; }
        public IList<ProductCategory> Categories { get; set; }
    }
}
