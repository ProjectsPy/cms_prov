using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cms_prov;
using cms_prov.Models;
namespace cms_prov.Controllers
{
    public class productsController : Controller
    {
        private cms_pyEntities db = new cms_pyEntities();

        // GET: products
        public ActionResult Index()
        {
            return View(db.products.ToList());
        }

        // GET: products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //product product = db.products.Find(id);

            var  modelo = from p in db.ImgProducts
                             join c in db.products on p.IdProduct equals c.Id
                             join d in db.Categories on c.IdCategory equals d.Id
                          where c.Id == id
                                select new ItemModel
                                {
                                    Id = c.Id,
                                    Description = c.Description,
                                    Categorias = d.Description,
                                    Imagen = p.Image
                                };

            if (modelo == null)
            {
                return HttpNotFound();
            }
            return View(modelo);
        }

        // GET: products/Create
        public ActionResult Create()
        {
            ViewBag.IdCategory = new SelectList(db.Categories, "Id", "Description");
            ViewBag.IdMarca = new SelectList(db.Marcas, "Id", "Description");
            ViewBag.IdMoneda = new SelectList(db.Monedas, "Id", "Description");
            return View();
        }

        // POST: products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Codigo,IdCategory,IdMarca,IdMoneda")] product product, List<HttpPostedFileBase> fileUpload)
        {
            if (ModelState.IsValid)
            {
                db.products.Add(product);
                db.SaveChanges();
                int id = product.Id;

                for (int i = 0; i < fileUpload.Count; i++)
                {
                    ImgProduct image = new ImgProduct
                    {
                        Name = System.IO.Path.GetFileName(fileUpload[i].FileName),
                        Id = id
                    };
                    using (var reader = new System.IO.BinaryReader(fileUpload[i].InputStream))
                    {
                        image.Image = reader.ReadBytes(fileUpload[i].ContentLength);
                        image.IdProduct = product.Id;
                        db.ImgProducts.Add(image);
                        db.SaveChanges();
                    }  
                }

                ViewBag.IdCategory = new SelectList(db.Categories, "Id", "Description");
                ViewBag.IdMarca = new SelectList(db.Marcas, "Id", "Description", product.IdMarca);
                ViewBag.IdMoneda = new SelectList(db.Monedas, "Id", "Description", product.IdMoneda);
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Codigo")] product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            product product = db.products.Find(id);
            db.products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
