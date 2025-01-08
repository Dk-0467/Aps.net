using buiduckiem_aps.net.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace buiduckiem_aps.net.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();

        // GET: Admin/Order
        public ActionResult Index()
        {
            var lstOrder = objWebsiteBanHangEntities.Orders.ToList();
            return View(lstOrder);
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            var objOrder = objWebsiteBanHangEntities.Orders.Where(n => n.Id == Id).FirstOrDefault();
            return View(objOrder);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var objOrder = objWebsiteBanHangEntities.Orders.Where(n => n.Id == Id).FirstOrDefault();
            return View(objOrder);
        }

        [HttpPost]
        public ActionResult Delete(Order objOr)
        {
            // Lấy đối tượng Order cần xóa
            var objOrder = objWebsiteBanHangEntities.Orders.FirstOrDefault(n => n.Id == objOr.Id);

            if (objOrder != null)
            {
                // Xóa các OrderDetail liên quan trước
                var orderDetails = objWebsiteBanHangEntities.OrderDetails.Where(od => od.OrderId == objOrder.Id).ToList();
                foreach (var detail in orderDetails)
                {
                    objWebsiteBanHangEntities.OrderDetails.Remove(detail);
                }

                // Sau khi xóa OrderDetail, xóa Order
                objWebsiteBanHangEntities.Orders.Remove(objOrder);
                objWebsiteBanHangEntities.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var objOrder = objWebsiteBanHangEntities.Orders.Where(n => n.Id == Id).FirstOrDefault();
            return View(objOrder);
        }

    }
}