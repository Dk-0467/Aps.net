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
            if (Session["cart"] == null)
            {
                List<CartModel> cart = new List<CartModel>();
                cart.Add(new CartModel { Product = objWebsiteBanHangEntities.Products.Find(id), Quantity = quantity });
                Session["cart"] = cart;
                Session["count"] = 1;
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
            return Json(new { Message = "Thành công", TotalPrice = ViewBag.TotalPrice }, JsonRequestBehavior.AllowGet);
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
        public ActionResult Remove(int Id)
        {
            List<CartModel> li = (List<CartModel>)Session["cart"];
            li.RemoveAll(x => x.Product.Id == Id);
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;

            // Tính lại tổng tiền
            var total = CalculateTotal();
            return Json(new { Message = "Thành công", TotalPrice = total }, JsonRequestBehavior.AllowGet);
        }

        // Hàm tính tổng tiền của giỏ hàng
        private decimal CalculateTotal()
        {
            List<CartModel> cart = (List<CartModel>)Session["cart"];
            if (cart == null || !cart.Any())
                return 0;

            return (decimal)cart.Sum(item => item.Quantity * item.Product.Price);
        }
    }
}
