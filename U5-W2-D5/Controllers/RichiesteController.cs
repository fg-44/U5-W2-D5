using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace U5_W2_D5.Controllers
{
    public class RichiesteController : Controller
    {
        // GET: Richieste
        static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionDb"].ConnectionString.ToString());

        public ActionResult Index()
        {
            return View();
        }
    }
}