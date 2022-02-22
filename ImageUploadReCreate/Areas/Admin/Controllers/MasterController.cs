using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageUploadReCreate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MasterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
