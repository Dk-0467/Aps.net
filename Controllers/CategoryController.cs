using buiduckiem_aps.net.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using buiduckiem_aps.net.Context;

namespace buiduckiem_aps.net.Controllers
{
    public class CategoryController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();

        // GET: Category
        public ActionResult AllCategory()
        {
            var lstCategory = objWebsiteBanHangEntities.Categories.ToList();
            return View(lstCategory);
        }
        public ActionResult ProductCategory(int Id)
        {
            var lstProduct = objWebsiteBanHangEntities.Products.Where(n=>n.CategoryId == Id).ToList();
            return View(lstProduct);
        }
    }
}