using PortfolioApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PortfolioApi.Controllers
{
    public class LeftMenuController : ApiController
    {
        public IHttpActionResult Get()
        {
            using (PortfolioDBContext db = new PortfolioDBContext())
            {
                var menus = db.LeftMenu.ToList();
                return Ok(menus);
            }
        }

    }
}
