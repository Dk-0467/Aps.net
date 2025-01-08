using buiduckiem_aps.net.Context;
using PagedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using static buiduckiem_aps.net.Common;

namespace buiduckiem_aps.net.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();

        // GET: Admin/Product

        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstProduct = new List<Product>();
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
                lstProduct = objWebsiteBanHangEntities.Products.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                //lấy all sån phẩm trong bảng product
                lstProduct = objWebsiteBanHangEntities.Products.ToList();
            }

            ViewBag.CurrentFilter = SearchString;
            //số lượng item của 1 trang = 4
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            //sắp xếp theo id sản phẩm, sp mới đưa lên đầu
            lstProduct = lstProduct.OrderByDescending(n => n.Id).ToList();
            return View(lstProduct.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult Details(int Id)
        {
            var objProduct = objWebsiteBanHangEntities.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }

        [HttpGet]
        public ActionResult Create()
        {
            this.LoadData();
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Product objProduct)
        {
            this.LoadData();
            try
            {
                if (objProduct.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                    string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                    objProduct.Avatar = fileName;
                    objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                }
                objWebsiteBanHangEntities.Products.Add(objProduct);
                objWebsiteBanHangEntities.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objProduct = objWebsiteBanHangEntities.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Delete(Product objPro)
        {
            var objProduct = objWebsiteBanHangEntities.Products.Where(n => n.Id == objPro.Id).FirstOrDefault();
            objWebsiteBanHangEntities.Products.Remove(objProduct);
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            this.LoadData();
            var objProduct = objWebsiteBanHangEntities.Products.Where(p => p.Id == id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Edit(Product objProduct)
        {
            this.LoadData();

            if (objProduct.ImageUpload != null && !string.IsNullOrEmpty(objProduct.ImageUpload.FileName))
            {
                string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                fileName = fileName + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + extension;
                objProduct.Avatar = fileName;
                objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
            }

            // Kiểm tra xem thực thể đã được theo dõi chưa
            var existingProduct = objWebsiteBanHangEntities.Products.Find(objProduct.Id);
            if (existingProduct != null)
            {
                objWebsiteBanHangEntities.Entry(existingProduct).CurrentValues.SetValues(objProduct);
                objWebsiteBanHangEntities.Entry(existingProduct).State = EntityState.Modified;
            }
            else
            {
                objWebsiteBanHangEntities.Products.Add(objProduct);
            }

            objWebsiteBanHangEntities.SaveChanges();

            return RedirectToAction("Index");
        }

        void LoadData()
        {

            Common objCommon = new Common();
            //lấy dữ liệu danh mục dưới DB
            var lstCat = objWebsiteBanHangEntities.Categories.ToList();
            //Convert sang select list dang value, text
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dtCategory = converter.ToDataTable(lstCat);
            ViewBag.ListCategory = objCommon.ToSelectList(dtCategory, "Id", "Name");

            //lấy dữ liệu thương hiệu dưới DB
            var lstBrand = objWebsiteBanHangEntities.Brands.ToList();
            DataTable dtBrand = converter.ToDataTable(lstBrand);
            //Convert sang select list dang value, text
            ViewBag.ListBrand = objCommon.ToSelectList(dtBrand, "Id", "Name");

            //Loại sản phẩm
            List<ProductType> lstProductType = new List<ProductType>();
            ProductType objProductType = new ProductType();
            objProductType.Id = 01;
            objProductType.Name = "Giảm giá sốc";
            lstProductType.Add(objProductType);

            objProductType = new ProductType();
            objProductType.Id = 02;
            objProductType.Name = "Đề xuất";
            lstProductType.Add(objProductType);

            DataTable dtProductType = converter.ToDataTable(lstProductType);
            //Convert sang select list dang value, text
            ViewBag.ProductType = objCommon.ToSelectList(dtProductType, "Id", "Name");


        }

    }
}