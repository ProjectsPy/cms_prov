using cms_prov.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Data.Entity.Infrastructure;


namespace cms_prov.Controllers
{
    public class productxImgController : Controller
    {
        // GET: productxImg
        cms_pyEntities entidad = new cms_pyEntities();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SelectedCategory"></param>
        /// <returns></returns>
        //FILTRO
        //public ActionResult Index( int? SelectedCategory)
        //{
        //    var category = entidad.Categories.OrderBy(q => q.Description).ToList();

        //    ViewBag.SelectedCategory = new SelectList(category, "Id", "Description", SelectedCategory);
        //    int categoryID = SelectedCategory.GetValueOrDefault();

        //    IQueryable<product> products = entidad.products
        //        .Where(c => !SelectedCategory.HasValue || c.Id == categoryID )
        //        .OrderBy(d => d.Id)
        //        .Include(d => d.Category)
        //        .Include(d => d.ImgProducts);
          
        //    var sql = products.ToString();
        //    return View(products.ToList());
           
        //}


        


        //BUSQUEDA Y ORDENAMIENTO
        public ActionResult Sort(string sortOrder, string currentFilter, string searchString, int? page, int? SelectedCategory)
        {
            //var modelo1 = "";
            if (SelectedCategory !=null)
            {
                var category = entidad.Categories.OrderBy(q => q.Description).ToList();
                ViewBag.SelectedCategory = new SelectList(category, "Id", "Description", SelectedCategory);
                int categoryID = SelectedCategory.GetValueOrDefault();
                /* **********************         */

                ViewBag.CurrentSort = sortOrder;
                ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Description_desc" : "";
                //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";


                if (searchString != null)
                {
                    page = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                ViewBag.CurrentFilter = searchString;

                var modelo = from p in entidad.ImgProducts
                             join c in entidad.products on p.IdProduct equals c.Id
                             join d in entidad.Categories on c.IdCategory equals d.Id
                             join e in entidad.Marcas on c.IdMarca equals e.Id
                             join i in entidad.Monedas on c.IdMoneda equals i.Id
                             where c.IdCategory == categoryID
                             //Where(c => !SelectedCategory.HasValue || c.Id == categoryID)
                             select new ItemModel
                             {
                                 Id = c.Id,
                                 Description = c.Description,
                                 Categorias = d.Description,
                                 Imagen = p.Image,
                                 Marcas = e.Description,
                                 Monedas = i.Description,
                                 Precio = c.PrecioVenta
                             };

                if (!String.IsNullOrEmpty(searchString))
                {
                    modelo = modelo.Where(c => c.Description.Contains(searchString));
                }


                switch (sortOrder)
                {
                    case "Description_desc":
                        modelo = modelo.OrderByDescending(c => c.Description);
                        break;

                    default:
                        modelo = modelo.OrderBy(c => c.Description);
                        break;
                }


                int pageSize = 6;
                int pageNumber = (page ?? 1);
                return View(modelo.ToPagedList(pageNumber, pageSize));
               
            }
            else
            {
                var category = entidad.Categories.OrderBy(q => q.Description).ToList();
                ViewBag.SelectedCategory = new SelectList(category, "Id", "Description", SelectedCategory);
                int categoryID = SelectedCategory.GetValueOrDefault();
                /* **********************         */

                ViewBag.CurrentSort = sortOrder;
                ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Description_desc" : "";
                //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";


                if (searchString != null)
                {
                    page = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                ViewBag.CurrentFilter = searchString;

                var modelo = from p in entidad.ImgProducts
                             join c in entidad.products on p.IdProduct equals c.Id
                             join d in entidad.Categories on c.IdCategory equals d.Id
                             join e in entidad.Marcas on c.IdMarca equals e.Id
                             join i in entidad.Monedas on c.IdMoneda equals i.Id
                             //where c.IdCategory == categoryID
                             //Where(c => !SelectedCategory.HasValue || c.Id == categoryID)
                             select new ItemModel
                             {
                                 Id = c.Id,
                                 Description = c.Description,
                                 Categorias = d.Description,
                                 Imagen = p.Image,
                                 Marcas = e.Description,
                                 Monedas = i.Description,
                                 Precio = c.PrecioVenta
                             };

                if (!String.IsNullOrEmpty(searchString))
                {
                    modelo = modelo.Where(c => c.Description.Contains(searchString));
                }


                switch (sortOrder)
                {
                    case "Description_desc":
                        modelo = modelo.OrderByDescending(c => c.Description);
                        break;

                    default:
                        modelo = modelo.OrderBy(c => c.Description);
                        break;
                }

                
                int pageSize = 6;
                int pageNumber = (page ?? 1);
                return View(modelo.ToPagedList(pageNumber, pageSize));
            }
            /*****************************/
            

            //return View(modelo.ToList());
        }
        private cms_pyEntities db = new cms_pyEntities();
        // GET: productxImg/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //product product = db.products.Find(id);

            var modelo = from p in db.ImgProducts
                         join c in db.products on p.IdProduct equals c.Id
                         join d in db.Categories on c.IdCategory equals d.Id
                         where c.Id == id
                         select new ItemModel
                         {
                             Id = c.Id,
                             Description = c.Description,
                             Categorias = d.Description,
                             Imagen = p.Image,
                             Precio = c.PrecioVenta
                         };

            if (modelo == null)
            {
                return HttpNotFound();
            }
            return View(modelo);
        }


      
       



    }
}