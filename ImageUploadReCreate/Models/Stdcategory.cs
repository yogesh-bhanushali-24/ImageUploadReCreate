using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImageUploadReCreate.Models
{
    public class Stdcategory
    {
        [Key]
        public int Cid { get; set; }
        [Required]
        public string Cname { get; set; }
    }
}
