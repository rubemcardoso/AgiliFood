using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgiliFood2.Models;

namespace AgiliFood2.Controllers
{
    public class OrderItemsController : Controller
    {
        private AgiliFoodModel db = new AgiliFoodModel();

        // GET: OrderItems
        public ActionResult Index()
        {
            var orderItems = db.OrderItems.Include(o => o.Orders).Include(o => o.Products);
            return View(orderItems.ToList());
        }

        // GET: OrderItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderItems orderItems = db.OrderItems.Find(id);
            if (orderItems == null)
            {
                return HttpNotFound();
            }
            return View(orderItems);
        }

        // GET: OrderItems/Create
        public ActionResult Create()
        {
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name");
            return View();
        }

        // POST: OrderItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderItemsID,OrderID,ProductID,Quantity")] OrderItems orderItems)
        {
            if (ModelState.IsValid)
            {
                db.OrderItems.Add(orderItems);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID", orderItems.OrderID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", orderItems.ProductID);
            return View(orderItems);
        }

        // GET: OrderItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderItems orderItems = db.OrderItems.Find(id);
            if (orderItems == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID", orderItems.OrderID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", orderItems.ProductID);
            return View(orderItems);
        }

        // POST: OrderItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderItemsID,OrderID,ProductID,Quantity")] OrderItems orderItems)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderItems).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID", orderItems.OrderID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", orderItems.ProductID);
            return View(orderItems);
        }

        // GET: OrderItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderItems orderItems = db.OrderItems.Find(id);
            if (orderItems == null)
            {
                return HttpNotFound();
            }
            return View(orderItems);
        }

        // POST: OrderItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderItems orderItems = db.OrderItems.Find(id);
            db.OrderItems.Remove(orderItems);
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
