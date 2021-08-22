using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CAC_Management.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int Contact { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int TuitionFee { get; set; }
        public int PayAmount { get; set; }
        public int DueAmount { get; set; }
        public int DueAmount2 { get; set; }
        public int PaymentStatus { get; set; }
    }
}
