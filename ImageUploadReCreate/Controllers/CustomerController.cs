using ImageUploadReCreate.Models;
using ImageUploadReCreate.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
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
            string stringFileName = UploadFile(vm);
            var customer = new Customer
            {
                
                Pname = vm.Pname,
                Pdetail=vm.Pdetail,
                Pprice=vm.Pprice,
                Cid=vm.Cid,
                ProfileImage = stringFileName
            };
            _db.customers.Add(customer);
            _db.SaveChanges();
            return RedirectToAction("ShowProduct");
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


        public IActionResult ShowProduct()
        {
            var viewProduct = _db.customers.ToList();
            return View(viewProduct);
        }



    }
}
