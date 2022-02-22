using ImageUploadReCreate.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageUploadReCreate.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateCategory(Stdcategory obj)
        {
            if (ModelState.IsValid)
            {
                _db.stdcategories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("ViewCategory");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult ViewCategory(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var sortingcategory = from c in _db.stdcategories select c;

            switch (sortOrder)
            {
                case "name_desc":
                    sortingcategory = sortingcategory.OrderByDescending(c => c.Cname);
                    break;

                default:
                    sortingcategory = sortingcategory.OrderBy(c => c.Cname);
                    break;
            }

            return View(sortingcategory);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var CDelete = _db.stdcategories.Find(id);
            if (CDelete == null)
            {
                return NotFound();
            }
            _db.stdcategories.Remove(CDelete);
            _db.SaveChanges();
            return RedirectToAction("ViewCategory");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var CEdit = _db.stdcategories.Where(x => x.Cid == id).FirstOrDefault();
            return View(CEdit);
        }

        [HttpPost]
        public IActionResult Edit(Stdcategory CEdit)
        {
            _db.stdcategories.Update(CEdit);
            _db.SaveChanges();
            return RedirectToAction("ViewCategory");
        }

        [HttpGet]
        public IActionResult CategoryDown()
        {
            var CD = _db.stdcategories.ToList();
            ViewBag.list = CD;
            return View();
        }

        public IActionResult CategoryTemp()
        {
            TempData["name"] = "Bill";

            return View();
        }
    

    }
}
