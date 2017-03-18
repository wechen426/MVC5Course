using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using PagedList;


namespace MVC5Course.Controllers
{
   // [Authorize]
    public class ProductsController :BaseController
    {
        //private FabricsEntities db = new FabricsEntities();
        
        // GET: Products
        public ActionResult Index(string sortBy,string keyword,int pageNO = 1)
        {
            searchIndexdata(sortBy, keyword, pageNO);
            //return View(db.Product.Take(20).ToList());
            //return View(data.ToPagedList(pageNO,20));
            return View();
        }

        private void searchIndexdata(string sortBy, string keyword, int pageNO)
        {
            var data = repo.All().AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.Where(p => p.ProductName.Contains(keyword));
            }

            if (sortBy == "+Price")
            {
                data = data.OrderBy(p => p.Price);
            }
            else
            {
                data = data.OrderByDescending(p => p.Price);
            }
            ViewBag.sortBy = sortBy;
            ViewBag.keyword = keyword;

            ViewData.Model = data.ToPagedList(pageNO, 10);
        }

        [HttpPost]
        public ActionResult Index(Product[] dataforEdit, string sortBy, string keyword, int pageNO = 1)
        {
            //接收View傳回的Form資料
            if (ModelState.IsValid == true)
            {
                foreach (var item in dataforEdit)
                {
                    var prod = repo.Find(item.ProductId);
                    prod.ProductName = item.ProductName;
                    prod.Price = item.Price;
                    prod.Stock = item.Stock;
                    prod.Active = item.Active;
                    
                }
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.keyword = keyword;
            //在 Index View中重新顯示更新的值
            searchIndexdata(sortBy, keyword, pageNO);
            return View();
        }
        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repo.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                repo.Add(product);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repo.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        //修改 ProductsController 的 Edit() 動作，改用 TryUpdateModel 來執行模型繫結
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection form)
        {
            
                var product = repo.Find(id);
            if (TryUpdateModel(product, new string[] { "ProductName", "Stock" }))
            {
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repo.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = repo.Find(id);
            repo.Delete(product);
            repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
