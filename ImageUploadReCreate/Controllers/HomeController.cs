using ImageUploadReCreate.Models;
using ImageUploadReCreate.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ImageUploadReCreate.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext Context;
        private readonly IWebHostEnvironment WebHostEnvironment;

        public HomeController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            Context = context;
            WebHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index(string sortOrder,int pg = 1, string SearchText = "")
        {
            // var items = Context.Students.ToList();
            List<Student> stdstudentss;

          




            //Search
            if (SearchText != "" && SearchText != null)
            {
                stdstudentss = Context.Students.Where(p => p.Name.Contains(SearchText)).ToList();
            }
            else
            {
                stdstudentss = Context.Students.ToList();

                //pagination
                const int pageSize = 8;
                if (pg < 1)
                    pg = 1;

                int recsCount = stdstudentss.Count();
                var pager = new Pager(recsCount, pg, pageSize);
                int recSkip = (pg - 1) * pageSize;
                var data = stdstudentss.Skip(recSkip).Take(pager.PageSize).ToList();
                this.ViewBag.Pager = pager;
                //paginathion 
                return View(data);
            }
            //Search


            //sortig 
           /* ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            stdstudentss = (List<Student>)(from s in Context.Students select s);

            switch (sortOrder)
            {
                case "name_desc":
                    stdstudentss = (List<Student>)stdstudentss.OrderByDescending(c => c.Name);
                    break;

                default:
                    stdstudentss = (List<Student>)stdstudentss.OrderBy(c => c.Name);
                    break;
            }*/
            //sorting








            return View(stdstudentss);
        }


        public IActionResult SortName(string sortOrder)
        {
            //sortig 
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var stdstudentss = from s in Context.Students select s;

            switch (sortOrder)
            {
                case "name_desc":
                    stdstudentss = stdstudentss.OrderByDescending(c => c.Name);
                    break;

                default:
                    stdstudentss = stdstudentss.OrderBy(c => c.Name);
                    break;
            }
            //sorting

            return RedirectToAction("Index",stdstudentss);
        }



        public IActionResult ShowProduct(int pg = 1, string SearchText = "")
        { // var items = Context.Students.ToList();
            List<Student> stdstudentss;

            //Search
            if (SearchText != "" && SearchText != null)
            {
                stdstudentss = Context.Students.Where(p => p.Name.Contains(SearchText)).ToList();
            }
            else
            {
                stdstudentss = Context.Students.ToList();

                //pagination
                const int pageSize = 8;
                if (pg < 1)
                    pg = 1;

                int recsCount = stdstudentss.Count();
                var pager = new Pager(recsCount, pg, pageSize);
                int recSkip = (pg - 1) * pageSize;
                var data = stdstudentss.Skip(recSkip).Take(pager.PageSize).ToList();
                this.ViewBag.Pager = pager;
                //paginathion 
                return View(data);
            }
            //Search

            return View(stdstudentss);

        }

        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(StudentViewModel vm)
        {
            string stringFileName = UploadFile(vm);
            var student = new Student
            {
                Name = vm.Name,
                ProfileImage = stringFileName
            };
            Context.Students.Add(student);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        private string UploadFile(StudentViewModel vm)
        {
            string fileName = null;
            if (vm.ProfileImage!=null)
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

        public IActionResult Delete(int id)
        {
            var ImageD = Context.Students.Find(id);
            if (ImageD == null)
            {
                return NotFound();
            }
            Context.Students.Remove(ImageD);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ImageE = Context.Students.Where(x => x.Id == id).FirstOrDefault();
            return View(ImageE);
        }

        [HttpPost]
        public IActionResult Edit(Student obj)
        {
            Context.Students.Update(obj);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            var detail = Context.Students.Where(x => x.Id == id).FirstOrDefault();
            return View(detail);
        }



        public IActionResult UpdateImage()
        {
            return View();
        }

      
    }
}
