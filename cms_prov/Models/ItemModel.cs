using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cms_prov.Models
{
    public class ItemModel
    {
       
        public int Id { get; set; }

        public int IdImagen { get; set; }

        public string Description { get; set; }
        public string Nombre { get; set; }
        public byte[] Imagen { get; set; }
        public product SelectProduct { get; set; }

        public List<product> Productos { get; set; }

        public string Categorias { get; set; }

        public Category SelectCategories { get; set; }

    }
}