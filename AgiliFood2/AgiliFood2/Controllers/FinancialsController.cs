using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgiliFood2.Models;

namespace AgiliFood2.Controllers
{
    public class FinancialsController : Controller
    {
        private AgiliFoodModel db = new AgiliFoodModel();

        // GET: Financials
        public ActionResult Index(DateTime? startDate, DateTime? endDate)
        {
            var bills = from f in db.Financial select f;

            if (startDate != null && endDate != null)
            {
                bills = bills.Where(f => f.Order_Date >= startDate && f.Order_Date <= endDate);
            }
            else
            {
                startDate = startDate != null ? startDate : DateTime.Now.AddYears(-2);
                endDate = endDate != null ? endDate : DateTime.Now;
                bills = bills.Where(f => f.Order_Date >= startDate && f.Order_Date <= endDate);
            }
            return View(bills.ToList());
        }

        // GET: Financials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Financial financial = db.Financial.Find(id);
            if (financial == null)
            {
                return HttpNotFound();
            }
            return View(financial);
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
