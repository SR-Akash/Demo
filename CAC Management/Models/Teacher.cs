using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CAC_Management.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
    
        public string TeacherName { get; set; }
        public int Contact { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Salary { get; set; }
        public int PaidAmount { get; set; }
        public int Payment_Status { get; set; }
    }
}
