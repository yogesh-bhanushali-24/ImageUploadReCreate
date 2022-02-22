using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImageUploadReCreate.ViewModel
{
    public class ProductViewModel
    {
        [Key]
        public int Pid { get; set; }
        [Required]
        public string Pname { get; set; }
        [Required]
        public string Pdetail { get; set; }
        [Required]
        public int Pprice { get; set; }
        public int Cid { get; set; }
        public IFormFile ProfileImage { get; set; }
    }
}
