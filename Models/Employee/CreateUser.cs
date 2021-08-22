using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortfolioApi.Models.Employee
{
    public class CreateUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string Password { get; set; }
        public string VerificationCode { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public int CreateBy { get; set; }
        public int UpdateBy { get; set; }
        public bool Status { get; set; }
    }
}