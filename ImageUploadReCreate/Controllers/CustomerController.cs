using ImageUploadReCreate.Models;
using ImageUploadReCreate.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ImageUploadReCreate.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment WebHostEnvironment;

        public CustomerController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            WebHostEnvironment = webHostEnvironment;
        }



        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult CreateProduct()
        {
            var cat = _db.stdcategories.ToList();
            ViewBag.list = cat;
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductViewModel vm)
        {
            var cat = _db.stdcategories.ToList();
            ViewBag.list = cat;
            if (ModelState.IsValid)
            {
                string stringFileName = UploadFile(vm);
                var customer = new Customer
                {

                    Pname = vm.Pname,
                    Pdetail = vm.Pdetail,
                    Pprice = vm.Pprice,
                    Cid = vm.Cid,
                    ProfileImage = stringFileName
                };
                _db.customers.Add(customer);
                _db.SaveChanges();
                return RedirectToAction("ShowProduct");

            }
            else
            {
                return View();
            }
         
         
        }

        private string UploadFile(ProductViewModel vm)
        {
            string fileName = null;
            if (vm.ProfileImage != null)
            {
                string uploadDir = Path.Combine(WebHostEnvironment.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "-" + vm.ProfileImage.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    vm.ProfileImage.CopyTo(fileStream);

                }
            }
            return fileName;
        }


        public IActionResult ShowProduct()
        {
            List<Customer> custm = _db.customers.ToList();
            List<Stdcategory> std = _db.stdcategories.ToList();
            var join= from e1 in std
                      join e2 in custm on e1.Cid equals e2.Cid into tabel1
                      from e2 in tabel1.ToList()
                      select new Product_Category
                      {
                          std = e1,
                          custom = e2

                      };

            return View(join);
        }
        public IActionResult DeleteProduct(int id)
        {
            var delete = _db.customers.Find(id);
            if (delete == null)
            {
                return NotFound();
            }
            _db.customers.Remove(delete);
            _db.SaveChanges();
            return RedirectToAction("ShowProduct");
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            

            var Edit = _db.customers.Where(x => x.Pid == id).FirstOrDefault();
            ViewBag.list = new SelectList(GetCategories(), "Cid", "Cname");
            TempData["Image"] = Edit.ProfileImage;
            ViewBag.Image = TempData.Peek("Image");
            return View(Edit);
            
        }

        private ICollection GetCategories()
        {
            var res= _db.stdcategories.ToList();
            return res;
            
        }

        [HttpPost]
        public IActionResult EditProduct(ProductViewModel prd)
        {
            string file = null;
            if (prd.ProfileImage != null)
            {
                file = UploadFile(prd);
            }
            else if(prd.ProfileImage==null)
            {
                ViewBag.Image = TempData.Peek("Image");
                file = ViewBag.Image;

            }

            if (prd.Pname == null || prd.Pdetail == null || prd.Pprice == null || prd.Cid == null)
            {
                ViewBag.status = false;
                ViewBag.alertmesaage = "Product Updated Failed";

            }
            else
            {
                var product = new Customer()
                {
                    Pid = prd.Pid,
                    Pname = prd.Pname,
                    Pdetail = prd.Pdetail,
                    Pprice = prd.Pprice,
                    Cid=prd.Cid,
                    ProfileImage=file
                 };
                _db.customers.Update(product);
                _db.SaveChanges();
                return RedirectToAction("ShowProduct");
            }
            ViewBag.list = new SelectList(GetCategories(), "cat_id", "category_name");
            ViewBag.Image = TempData.Peek("Image");
            return View();
        }



    }
}
