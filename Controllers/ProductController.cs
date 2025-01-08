using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using buiduckiem_aps.net.Context;
namespace buiduckiem_aps.net.Controllers
{
    public class ProductController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        // GET: Product
        public ActionResult Detail(int Id)
        {
            var objProduct = objWebsiteBanHangEntities.Products.Where(n=>n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
    }
}