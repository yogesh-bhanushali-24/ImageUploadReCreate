using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImageUploadReCreate.Models
{
    public class Customer
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
        public string ProfileImage { get; set; }
    }
}
