using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cms_prov.Models;

namespace cms_prov.Controllers
{
    public class HomeController : Controller
    {
        cms_pyEntities entidad = new cms_pyEntities();
        public ActionResult Index()
        {
            var modelo = from p in entidad.ImgProducts
                         join c in entidad.products on p.IdProduct equals c.Id
                         //join d in entidad.Categories on c.IdCategory equals d.Id
                         //join e in entidad.Marcas on c.IdMarca equals e.Id
                         //join i in entidad.Monedas on c.IdMoneda equals i.Id
                         //where c.IdCategory == categoryID
                         //Where(c => !SelectedCategory.HasValue || c.Id == categoryID)
                         select new ItemModel
                         {
                             Id = c.Id,
                             Description = c.Description,
                             //Categorias = d.Description,
                             Imagen = p.Image
                            // Marcas = e.Description,
                            // Monedas = i.Description,
                            // Precio = c.PrecioVenta
                         };
            return View(modelo);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}