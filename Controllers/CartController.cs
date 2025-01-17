using buiduckiem_aps.net.Context;
using buiduckiem_aps.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace buiduckiem_aps.net.Controllers
{
    public class CartController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();

        // GET: Cart
        public ActionResult Index()
        {
            ViewBag.TotalPrice = CalculateTotal();
            return View((List<CartModel>)Session["cart"]);
        }

        public ActionResult AddToCart(int id, int quantity)
        {
            if (Session["idUser"] == null)
            {
                // Trả về trạng thái yêu cầu đăng nhập
                return Json(new { Status = "NotLoggedIn" }, JsonRequestBehavior.AllowGet);
            }

            // Nếu giỏ hàng chưa tồn tại, khởi tạo giỏ hàng mới
            if (Session["cart"] == null)
            {
                List<CartModel> cart = new List<CartModel>();
                cart.Add(new CartModel { Product = objWebsiteBanHangEntities.Products.Find(id), Quantity = quantity });
                Session["cart"] = cart;
                Session["count"] = 1;  // Khởi tạo số lượng sản phẩm trong giỏ hàng
            }
            else
            {
                List<CartModel> cart = (List<CartModel>)Session["cart"];
                // Kiểm tra sản phẩm có tồn tại trong giỏ hàng chưa
                int index = isExist(id);
                if (index != -1)
                {
                    // Nếu sản phẩm tồn tại trong giỏ hàng thì cộng thêm số lượng
                    cart[index].Quantity += quantity;
                }
                else
                {
                    // Nếu không tồn tại thì thêm sản phẩm vào giỏ hàng
                    cart.Add(new CartModel { Product = objWebsiteBanHangEntities.Products.Find(id), Quantity = quantity });
                    // Tính lại số sản phẩm trong giỏ hàng
                    Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                }
                Session["cart"] = cart;
            }

            // Tính lại tổng tiền
            ViewBag.TotalPrice = CalculateTotal();

            // Trả về kết quả dưới dạng JSON
            return Json(new { success = true, message = "Sản phẩm đã được thêm vào giỏ hàng.", totalPrice = ViewBag.TotalPrice }, JsonRequestBehavior.AllowGet);
        }

        private int isExist(int id)
        {
            List<CartModel> cart = (List<CartModel>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.Id.Equals(id))
                    return i;
            return -1;
        }

        // Xóa sản phẩm khỏi giỏ hàng theo id
        [HttpPost]
        public JsonResult Remove(int Id)
        {
            try
            {
                // Xóa sản phẩm theo Id trong giỏ hàng
                var cart = Session["Cart"] as List<CartModel>;
                var itemToRemove = cart?.FirstOrDefault(x => x.Product.Id == Id);

                if (itemToRemove != null)
                {
                    cart.Remove(itemToRemove);
                    Session["Cart"] = cart;

                    // Cập nhật tổng tiền và số lượng
                    var totalPrice = cart.Sum(x => x.Quantity * x.Product.Price);
                    var count = cart.Count;

                    return Json(new
                    {
                        success = true,
                        TotalPrice = totalPrice,
                        Count = count
                    });
                }

                return Json(new { success = false, message = "Sản phẩm không tồn tại trong giỏ hàng!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


        // Hàm tính tổng tiền của giỏ hàng
        private decimal CalculateTotal()
        {
            List<CartModel> cart = (List<CartModel>)Session["cart"];
            if (cart == null || !cart.Any())
                return 0;

            return (decimal)cart.Sum(item => item.Quantity * item.Product.Price);
        }

        public ActionResult UpdateQuantity(int id, int quantity)
        {
            try
            {
                if (Session["cart"] == null)
                    return Json(new { success = false, message = "Giỏ hàng hiện tại trống!" }, JsonRequestBehavior.AllowGet);

                List<CartModel> cart = (List<CartModel>)Session["cart"];
                var product = cart.FirstOrDefault(x => x.Product.Id == id);

                if (product == null)
                    return Json(new { success = false, message = "Sản phẩm không tồn tại trong giỏ hàng!" }, JsonRequestBehavior.AllowGet);

                if (quantity <= 0)
                    return Json(new { success = false, message = "Số lượng phải lớn hơn 0!" }, JsonRequestBehavior.AllowGet);

                // Cập nhật số lượng
                product.Quantity = quantity;

                // Lưu giỏ hàng vào session
                Session["cart"] = cart;

                // Tính lại tổng tiền
                var totalPrice = CalculateTotal();

                return Json(new
                {
                    success = true,
                    totalPrice = totalPrice,
                    totalPriceFormatted = $"{totalPrice:N0} VND"
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Có lỗi xảy ra: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
