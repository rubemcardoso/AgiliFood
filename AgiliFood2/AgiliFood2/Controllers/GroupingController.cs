using AgiliFood2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgiliFood2.Controllers
{
    public class GroupingController : Controller
    {
        private AgiliFoodModel db = new AgiliFoodModel();

        // GET: Grouping
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

            var groupedBills = from f in bills
                               group f by f.Employee into f
                               select new Group<string, Financial> { Key = f.Key, Values = f };

            return View(groupedBills.ToList());
        }

        // GET: Grouping/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

    }
}
