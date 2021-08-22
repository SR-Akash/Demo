using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PortfolioApi.Controllers
{
    public class StoredProcedureController : ApiController
    {
        [HttpPost]
        public  IHttpActionResult Post(string firstName,string lastName,string email,string password,DateTime createDate,DateTime updateDate,int createBy,int updateBy,bool status)
        {

            using (SqlConnection conn = new SqlConnection("Server=(local);DataBase=PortfolioDB;Integrated Security=SSPI"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_createUserProfile", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FirstName", firstName));
                cmd.Parameters.Add(new SqlParameter("@LastName", lastName));
                cmd.Parameters.Add(new SqlParameter("@Email", email));
                cmd.Parameters.Add(new SqlParameter("@Password", password));
                cmd.Parameters.Add(new SqlParameter("@CreateDate", createDate));
                cmd.Parameters.Add(new SqlParameter("@UpdateDate", updateDate));
                cmd.Parameters.Add(new SqlParameter("@CreateBy", createBy));
                cmd.Parameters.Add(new SqlParameter("@UpdateBy", updateBy));
                cmd.Parameters.Add(new SqlParameter("@Status", status));
                var result= cmd.ExecuteNonQuery();
                conn.Close();
                return Ok(result);
            }
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            DataSet ds;
            SqlDataAdapter da;
            using (SqlConnection conn = new SqlConnection("Server=(local);DataBase=PortfolioDB;Integrated Security=SSPI"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_getUserProfile", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                return Ok(ds);
            }
        }

        [HttpPut]
        public IHttpActionResult Update(int Id, string firstName, string lastName, string email, string password, DateTime createDate, DateTime updateDate, int createBy, int updateBy, bool status)
        {
            using (SqlConnection conn = new SqlConnection("Server=(local);DataBase=PortfolioDB;Integrated Security=SSPI"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_updateUserProfile", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", Id));
                cmd.Parameters.Add(new SqlParameter("@FirstName", firstName));
                cmd.Parameters.Add(new SqlParameter("@LastName", lastName));
                cmd.Parameters.Add(new SqlParameter("@Email", email));
                cmd.Parameters.Add(new SqlParameter("@Password", password));
                cmd.Parameters.Add(new SqlParameter("@CreateDate", createDate));
                cmd.Parameters.Add(new SqlParameter("@UpdateDate", updateDate));
                cmd.Parameters.Add(new SqlParameter("@CreateBy", createBy));
                cmd.Parameters.Add(new SqlParameter("@UpdateBy", updateBy));
                cmd.Parameters.Add(new SqlParameter("@Status", status));
                var result = cmd.ExecuteNonQuery();
                conn.Close();
                return Ok(result);
            }
           
        }


        [HttpDelete]
        public IHttpActionResult Delete(int Id)
        {
            using (SqlConnection conn = new SqlConnection("Server=(local);DataBase=PortfolioDB;Integrated Security=SSPI"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_deleteUserProfile", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", Id));
                var result = cmd.ExecuteNonQuery();
                conn.Close();
                return Ok(result);
            }

        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            DataSet ds;
            SqlDataAdapter da;
            using (SqlConnection conn = new SqlConnection("Server=(local);DataBase=PortfolioDB;Integrated Security=SSPI"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_getByIdUserProfile", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                return Ok(ds);
            }
        }
    }
}
