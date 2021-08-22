using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CAC_Management.Models
{
    public class st_routine
    {
        public int ID { get; set; }
        [Required]
        [Display(Name ="Day")]
        public string day { get; set; }
        [Display(Name = "Time")]
        [Required]
        public string time { get; set; }
        [Display(Name = "Subject")]
        [Required]
        public string sub { get; set; }
        [Display(Name = "Instructor")]
        [Required]
        public string instructor { get; set; }
    }
}
