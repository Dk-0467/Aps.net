using buiduckiem_aps.net.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using buiduckiem_aps.net.Context;
using PagedList;

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
        // GET: ProductCategory
        public ActionResult ProductCategory(int id, int page = 1)
        {
            int pageSize = 4; // Số lượng sản phẩm mỗi trang
            var lstProduct = objWebsiteBanHangEntities.Products
                .Where(n => n.CategoryId == id)
                .OrderBy(p => p.Name) // Hoặc sắp xếp theo cách bạn muốn
                .ToPagedList(page, pageSize); // Chuyển đổi thành IPagedList

            ViewBag.CategoryId = id; // Lưu ID danh mục vào ViewBag để sử dụng trong phân trang

            return View(lstProduct);
        }
    }
}