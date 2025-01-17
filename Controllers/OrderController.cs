using System.Linq;
using System.Web.Mvc;
using buiduckiem_aps.net.Context;
using buiduckiem_aps.net.Models;

namespace buiduckiem_aps.net.Controllers
{
    public class OrderController : Controller
    {
        private WebsiteBanHangEntities db = new WebsiteBanHangEntities(); // Kết nối CSDL

        // Action: Danh sách đơn hàng của user
        public ActionResult UserOrders()
        {
            // Kiểm tra nếu user chưa đăng nhập
            if (Session["idUser"] == null)
            {
                return RedirectToAction("Login", "Home"); // Chuyển đến trang đăng nhập
            }

            // Lấy id user từ Session
            int userId = (int)Session["idUser"];

            // Lấy danh sách đơn hàng của user từ CSDL
            var orders = db.Orders
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.CreatedOnUtc) 
                .AsEnumerable();

            // Truyền danh sách đơn hàng sang view
            return View(orders);
        }

    }
}
