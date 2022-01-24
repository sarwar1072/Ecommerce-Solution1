﻿using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Framework.Entity
{
    public class Category: IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<ProductCategory> Categories { get; set; }
    }
}
