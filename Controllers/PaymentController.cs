using buiduckiem_aps.net.Context;
using buiduckiem_aps.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace buiduckiem_aps.net.Controllers
{
    public class PaymentController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();

        // GET: Payment
        public ActionResult Index()
        {
            if (Session["idUser"] == null)
            {

                return RedirectToAction("Login", "Home");

            }


            else
            {
                var lstCart = (List<CartModel>)Session["Cart"];
                Order obj = new Order();
                obj.Name = "DonHang" + DateTime.Now.ToString("yyyyMMddHHmmss");
                obj.UserId = int.Parse(Session["idUser"].ToString());
                obj.CreatedOnUtc = DateTime.Now;
                obj.Status = 1;
                objWebsiteBanHangEntities.Orders.Add(obj);
                objWebsiteBanHangEntities.SaveChanges();
                int intOrderId = obj.Id;
                List<OrderDetail> orderDetails = new List<OrderDetail>();
                foreach (var cart in lstCart)
                {
                    OrderDetail objOrderDetail = new OrderDetail();
                    objOrderDetail.Quantity = cart.Quantity;
                    objOrderDetail.OrderId = intOrderId;
                    objOrderDetail.ProductId = cart.Product.Id;
                    orderDetails.Add(objOrderDetail);
                }
                objWebsiteBanHangEntities.OrderDetails.AddRange(orderDetails);

                @Session["cart"] = null;
                @Session["count"] = 0;
                objWebsiteBanHangEntities.SaveChanges();
            }
            return View();
        }
    }
}