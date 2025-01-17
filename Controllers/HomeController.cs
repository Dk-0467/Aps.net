using buiduckiem_aps.net.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using buiduckiem_aps.net.Models;
using System.Data.Entity.Infrastructure;
using System.Security.Cryptography;
using System.Text;


namespace buiduckiem_aps.net.Controllers
{
    public class HomeController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        public ActionResult Index()
        {
            HomeModel objHomeModel = new HomeModel();

            objHomeModel.ListCategory = objWebsiteBanHangEntities.Categories.ToList();
            objHomeModel.ListProduct = objWebsiteBanHangEntities.Products.ToList();

            return View(objHomeModel);
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User _user)
        {
            if (ModelState.IsValid)
            {
                // Loại bỏ khoảng trắng và chuyển email thành chữ thường để kiểm tra chính xác
                var emailToCheck = _user.Email.Trim().ToLower();

                // Kiểm tra sự tồn tại của email trong cơ sở dữ liệu
                var check = objWebsiteBanHangEntities.Users
                    .FirstOrDefault(s => s.Email.Trim().ToLower() == emailToCheck);

                if (check == null)
                {
                    // Mã hóa mật khẩu
                    _user.Password = GetMD5(_user.Password);

                    // Tắt ValidateOnSaveEnabled để bỏ qua kiểm tra tự động của Entity Framework
                    objWebsiteBanHangEntities.Configuration.ValidateOnSaveEnabled = false;

                    // Thêm người dùng mới
                    objWebsiteBanHangEntities.Users.Add(_user);
                    objWebsiteBanHangEntities.SaveChanges();

                    // Chuyển hướng về trang Index sau khi đăng ký thành công
                    return RedirectToAction("Index");
                }
                else
                {
                    // Hiển thị thông báo lỗi nếu email đã tồn tại
                    ViewBag.error = "Email đã tồn tại. Vui lòng sử dụng email khác.";
                    return View(_user);
                }
            }

            // Trả lại view nếu dữ liệu không hợp lệ
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
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {


                var f_password = GetMD5(password);
                var data = objWebsiteBanHangEntities.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["idUser"] = data.FirstOrDefault().Id;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Search(string query, string category_name)
        {
            HomeModel objHomeModel = new HomeModel();

            // Lấy danh sách các danh mục
            objHomeModel.ListCategory = objWebsiteBanHangEntities.Categories.ToList();

            // Lọc sản phẩm theo từ khóa và loại sản phẩm
            var products = objWebsiteBanHangEntities.Products.AsEnumerable();

            if (!string.IsNullOrEmpty(query))
            {
                products = products.Where(p => p.Name.Contains(query) || p.FullDescription.Contains(query));
            }

            if (!string.IsNullOrEmpty(category_name))
            {
                products = products.Where(p => p.Category.Name == category_name);
            }

            objHomeModel.ListProduct = products.ToList();

            return View(objHomeModel);
        }

    }

}
