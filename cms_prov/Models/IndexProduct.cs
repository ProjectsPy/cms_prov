using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cms_prov.Models
{
    public class IndexProduct
    {
        public IEnumerable<product> Products { get; set; }
        public IEnumerable<ImgProduct> Images { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}