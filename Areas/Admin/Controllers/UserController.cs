using buiduckiem_aps.net.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace buiduckiem_aps.net.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();

        // GET: Admin/User
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstUser = new List<User>();
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                //lấy ds sản phẩm theo từ khóa tìm kiếm
                lstUser = objWebsiteBanHangEntities.Users.Where(n => n.LastName.Contains(SearchString)).ToList();
            }
            else
            {
                //lấy all sån phẩm trong bảng product
                lstUser = objWebsiteBanHangEntities.Users.ToList();
            }

            ViewBag.CurrentFilter = SearchString;
            //số lượng item của 1 trang = 4
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            //sắp xếp theo id sản phẩm, sp mới đưa lên đầu
            lstUser = lstUser.OrderByDescending(n => n.Id).ToList();
            return View(lstUser.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            var lstUser = objWebsiteBanHangEntities.Users.Where(n => n.Id == Id).FirstOrDefault();
            return View(lstUser);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var lstUser = objWebsiteBanHangEntities.Users.Where(n => n.Id == Id).FirstOrDefault();
            return View(lstUser);
        }

        [HttpPost]
        public ActionResult Delete(User objUser)
        {
            // Lấy thông tin người dùng cần xóa
            var lstUser = objWebsiteBanHangEntities.Users.Where(n => n.Id == objUser.Id).FirstOrDefault();

            // Kiểm tra nếu người dùng đã liên kết với đơn hàng
            var linkedOrders = objWebsiteBanHangEntities.Orders.Any(o => o.UserId == lstUser.Id);
            if (linkedOrders)
            {
                // Trả thông báo lỗi nếu không thể xóa
                ViewBag.ErrorMessage = "Không thể xóa người dùng này vì đã liên kết với các đơn hàng.";
                return View(lstUser);
            }

            // Xóa người dùng nếu không có liên kết
            objWebsiteBanHangEntities.Users.Remove(lstUser);
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User _user)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem email có tồn tại trong cơ sở dữ liệu hay không
                var check = objWebsiteBanHangEntities.Users.FirstOrDefault(s => s.Email.Trim().ToLower() == _user.Email.Trim().ToLower());
                if (check == null)
                {
                    // Mã hóa mật khẩu trước khi lưu
                    _user.Password = GetMD5(_user.Password);

                    // Tắt ValidateOnSaveEnabled để tránh lỗi validation tự động của EF
                    objWebsiteBanHangEntities.Configuration.ValidateOnSaveEnabled = false;

                    // Thêm người dùng vào cơ sở dữ liệu
                    objWebsiteBanHangEntities.Users.Add(_user);
                    objWebsiteBanHangEntities.SaveChanges();

                    // Chuyển hướng đến trang danh sách người dùng
                    return RedirectToAction("Index");
                }
                else
                {
                    // Hiển thị lỗi khi email đã tồn tại
                    ViewBag.error = "Email đã tồn tại, vui lòng sử dụng email khác.";
                    return View(_user);
                }
            }
            // Nếu ModelState không hợp lệ, trả lại view
            return View(_user);
        }
        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var lstUser = objWebsiteBanHangEntities.Users.Where(p => p.Id == id).FirstOrDefault();
            if (lstUser == null)
            {
                return HttpNotFound();
            }
            return View(lstUser);
        }

        [HttpPost]
        public ActionResult Edit(User _user)
        {
            if (ModelState.IsValid)
            {
                // Lấy thông tin người dùng hiện tại theo ID
                var existingUser = objWebsiteBanHangEntities.Users.FirstOrDefault(s => s.Id == _user.Id);

                if (existingUser != null)
                {
                    // Kiểm tra xem email đã tồn tại trong cơ sở dữ liệu nhưng không phải của người dùng này
                    var duplicateEmailUser = objWebsiteBanHangEntities.Users
                        .FirstOrDefault(s => s.Email.Trim().ToLower() == _user.Email.Trim().ToLower() && s.Id != _user.Id);

                    if (duplicateEmailUser != null)
                    {
                        ViewBag.error = "Email đã tồn tại. Vui lòng sử dụng email khác.";
                        return View(_user);
                    }

                    // Cập nhật thông tin người dùng
                    existingUser.FirstName = _user.FirstName;
                    existingUser.LastName = _user.LastName;
                    existingUser.Email = _user.Email;

                    // Chỉ cập nhật mật khẩu nếu được cung cấp
                    if (!string.IsNullOrEmpty(_user.Password))
                    {
                        existingUser.Password = GetMD5(_user.Password);
                    }

                    existingUser.IsAdmin = _user.IsAdmin;

                    // Lưu thay đổi
                    objWebsiteBanHangEntities.SaveChanges();

                    // Chuyển hướng về danh sách
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Người dùng không tồn tại.";
                }
            }

            // Trả lại view với thông báo lỗi nếu có
            return View(_user);
        }


    }
}