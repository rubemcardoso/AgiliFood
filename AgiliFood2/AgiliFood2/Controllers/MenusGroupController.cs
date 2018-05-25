using AgiliFood2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgiliFood2.Controllers
{
    public class MenusGroupController : Controller
    {
        private AgiliFoodModel db = new AgiliFoodModel();

        // GET: MenusGroup
        public ActionResult Index()
        {
            var groupedMenus = from m in db.MenusGroup
                    group m by m.MenuName into m
                    select new Group<string, MenusGroup> { Key = m.Key, Values = m };

            return View(groupedMenus.ToList());
        }

        // GET: MenusGroup/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

    }
}
