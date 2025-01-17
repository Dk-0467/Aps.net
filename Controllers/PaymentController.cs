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
            // Kiểm tra nếu người dùng chưa đăng nhập
            if (Session["idUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            // Lấy giỏ hàng từ Session
            var lstCart = (List<CartModel>)Session["Cart"];

            // Kiểm tra nếu giỏ hàng trống
            if (lstCart == null || !lstCart.Any())
            {
                TempData["ErrorMessage"] = "Giỏ hàng của bạn đang trống. Vui lòng thêm sản phẩm trước khi thanh toán.";
                return RedirectToAction("Index", "Home"); // Chuyển hướng về trang giỏ hàng
            }

            // Tạo đơn hàng
            Context.Order obj = new Context.Order
            {
                Name = "DonHang" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                UserId = int.Parse(Session["idUser"].ToString()),
                CreatedOnUtc = DateTime.Now,
                Status = 1
            };
            objWebsiteBanHangEntities.Orders.Add(obj);
            objWebsiteBanHangEntities.SaveChanges();

            // Lấy ID của đơn hàng vừa tạo
            int intOrderId = obj.Id;

            // Thêm chi tiết đơn hàng
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach (var cart in lstCart)
            {
                OrderDetail objOrderDetail = new OrderDetail
                {
                    Quantity = cart.Quantity,
                    OrderId = intOrderId,
                    ProductId = cart.Product.Id
                };
                orderDetails.Add(objOrderDetail);
            }
            objWebsiteBanHangEntities.OrderDetails.AddRange(orderDetails);

            // Xóa giỏ hàng sau khi thanh toán thành công
            Session["Cart"] = null;
            Session["count"] = 0;
            objWebsiteBanHangEntities.SaveChanges();

            TempData["SuccessMessage"] = "Đơn hàng của bạn đã được tạo thành công!";
            return View();
        }
    }
}