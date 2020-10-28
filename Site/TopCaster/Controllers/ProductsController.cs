using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;
using ViewModels;

namespace TopCaster.Controllers
{
    public class ProductsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.ProductGroup).Where(p=>p.IsDeleted==false).OrderByDescending(p=>p.CreationDate);
            return View(products.ToList());
        }
         

        public ActionResult Create()
        {
            ViewBag.ProductGroupId = new SelectList(db.ProductGroups, "Id", "Title");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase fileupload)
        {
            if (ModelState.IsValid)
            {
                #region Upload and resize image if needed
                if (fileupload != null)
                {
                    string filename = Path.GetFileName(fileupload.FileName);
                    string newFilename = Guid.NewGuid().ToString().Replace("-", string.Empty)
                                         + Path.GetExtension(filename);

                    string newFilenameUrl = "/Uploads/product/" + newFilename;
                    string physicalFilename = Server.MapPath(newFilenameUrl);

                    fileupload.SaveAs(physicalFilename);

                    product.ImageUrl = newFilenameUrl;
                }
                #endregion

                product.Code = ReturnProductCode();
                product.IsDeleted=false;
				product.CreationDate= DateTime.Now; 
                product.Id = Guid.NewGuid();
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index"); 
            }

            ViewBag.ProductGroupId = new SelectList(db.ProductGroups, "Id", "Title", product.ProductGroupId);
            return View(product);
        }
        public int ReturnProductCode()
        {

            Product product = db.Products.OrderByDescending(current => current.Code).FirstOrDefault();
            if (product != null)
            {
                return product.Code + 1;
            }
            else
            {
                return 100;
            }
        }
   
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductGroupId = new SelectList(db.ProductGroups, "Id", "Title", product.ProductGroupId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product, HttpPostedFileBase fileupload)
        {
            if (ModelState.IsValid)
            {
                #region Upload and resize image if needed
                if (fileupload != null)
                {
                    string filename = Path.GetFileName(fileupload.FileName);
                    string newFilename = Guid.NewGuid().ToString().Replace("-", string.Empty)
                                         + Path.GetExtension(filename);

                    string newFilenameUrl = "/Uploads/product/" + newFilename;
                    string physicalFilename = Server.MapPath(newFilenameUrl);

                    fileupload.SaveAs(physicalFilename);

                    product.ImageUrl = newFilenameUrl;
                }
                #endregion
                product.IsDeleted = false;
				product.LastModifiedDate = DateTime.Now;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductGroupId = new SelectList(db.ProductGroups, "Id", "Title", product.ProductGroupId);
            return View(product);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Product product = db.Products.Find(id);
			product.IsDeleted=true;
			product.DeletionDate=DateTime.Now;
 
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


        [AllowAnonymous]
        [Route("category/{urlParam}")]
        public ActionResult List(string urlParam)
        {
            ProductGroup productGroup = db.ProductGroups.FirstOrDefault(c => c.UrlParam == urlParam);

            if (productGroup == null)
                return Redirect("/");

            ProductListViewModel productList = new ProductListViewModel()
            {
                ProductGroup = productGroup,
                Products = db.Products.Where(c => c.ProductGroupId == productGroup.Id && c.IsDeleted == false && c.IsActive).OrderByDescending(c => c.CreationDate).ToList(),
                SidebarLatestBlog = db.Blogs.Where(c => c.IsDeleted == false && c.IsActive).OrderByDescending(c => c.CreationDate).ToList(),
                SidebarProductGroups = db.ProductGroups.Where(c => c.IsDeleted == false && c.IsActive).OrderBy(c => c.Order).ToList(),
            };


            return View(productList);
        }

        [AllowAnonymous]
        [Route("product/{code:int}")]
        public ActionResult Details(int code)
        {
            Product product = db.Products.FirstOrDefault(c => c.Code == code && c.IsDeleted == false);

            if (product == null)
                return Redirect("/");

            ProductDetailViewModel productDetail = new ProductDetailViewModel()
            {
                Product = product,
                RelatedProducts = db.Products.Where(c => c.ProductGroupId == product.ProductGroupId && c.IsDeleted == false && c.IsActive).OrderByDescending(c => c.CreationDate).Take(4).ToList(),
                SidebarLatestBlog = db.Blogs.Where(c => c.IsDeleted == false && c.IsActive).OrderByDescending(c => c.CreationDate).ToList(),
                SidebarProductGroups = db.ProductGroups.Where(c => c.IsDeleted == false && c.IsActive).OrderBy(c => c.Order).ToList(),
                ProductComments = db.ProductComments.Where(c => c.ProductId == product.Id && c.IsActive && c.IsDeleted == false).OrderByDescending(c => c.CreationDate).ToList(),
                ProductFeatures = db.ProductFeatures.Where(c => c.ProductId == product.Id && c.IsActive && c.IsDeleted == false).ToList(),
            };


            return View(productDetail);
        }
    }
}
