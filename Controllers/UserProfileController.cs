using PortfolioApi.Data;
using PortfolioApi.Helper;
using PortfolioApi.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PortfolioApi.Controllers
{
    public class UserProfileController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(CreateUser createUser)
        {
            try
            {
                FormValid valid = new FormValid();
                if (valid.formIsValid(createUser, out string errorMessage, out int errorCode) != true)
                {
                    return BadRequest(errorMessage);
                }
                else
                {
                    using (PortfolioDBContext db = new PortfolioDBContext())
                    {
                        UserProfile userProfile = new UserProfile();
                        userProfile.FirstName = createUser.FirstName;
                        userProfile.LastName = createUser.LastName;
                        userProfile.Email = createUser.Email;
                        userProfile.Password = createUser.Password;
                        userProfile.CreateBy = 0;
                        userProfile.UpdateBy = 0;
                        userProfile.CreateDate = DateTime.Now;
                        userProfile.UpdateDate = DateTime.Now;
                        userProfile.Status = true;
                        db.UserProfile.Add(userProfile);
                        db.SaveChanges();
                        return Ok(errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //[HttpGet]
        //public IHttpActionResult Get()
        //{
        //    try
        //    {
        //        using (PortfolioDBContext db = new PortfolioDBContext())
        //        {
        //           string rootPath= HttpContext.Current.Server.MapPath("~");

        //            var userInfo = db.UserProfile.ToList();
        //            foreach (var user in userInfo)
        //            {
        //                if (user.ImageUrl!=null)
        //                {
        //                    user.ImageUrl = user.ImageUrl.Replace(user.ImageUrl, rootPath + "/" + user.ImageUrl);
        //                }
                      
        //            }



        //            return Ok(userInfo);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            using (PortfolioDBContext db = new PortfolioDBContext())
            {
                var dlet = db.UserProfile.SingleOrDefault(x => x.Id == id);
                if (dlet!=null)
                {
                    db.UserProfile.Remove(dlet);
                    db.SaveChanges();
                    return Ok(dlet);
                }
                else
                {
                    return BadRequest("User Not Exsites");     
                }
            }
        }



        [HttpGet]
        public IHttpActionResult Get(int page, int pageSize)
        {
            try
            {
                using (PortfolioDBContext db = new PortfolioDBContext())
                {
                   var listOfData= Paging.Page(db.UserProfile.ToList(), page, pageSize);
                    return Ok(listOfData);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






    }
    public class FormValid
    {
        public bool formIsValid(CreateUser createUser, out string errorMessage, out int errorCode)
        {

            if (string.IsNullOrEmpty(createUser.FirstName))
            {
                errorCode = 404;
                errorMessage = "FirstName Field Empty";
                return false;
            }
            if (string.IsNullOrEmpty(createUser.LastName))
            {
                errorCode = 404;
                errorMessage = "LastName Field Empty";
                return false;
            }
            if (string.IsNullOrEmpty(createUser.Email))
            {
                errorCode = 404;
                errorMessage = "Email Field Empty";
                return false;
            }
            if (string.IsNullOrEmpty(createUser.Password))
            {
                errorCode = 404;
                errorMessage = "Password Field Empty";
                return false;
            }
            errorCode = 200;
            errorMessage = "Successfully Created !";
            return true;
        }
    }
}
