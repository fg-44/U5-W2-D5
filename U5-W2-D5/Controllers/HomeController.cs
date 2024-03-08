using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using U5_W2_D5.Models;

namespace U5_W2_D5.Controllers
{
    public class HomeController : Controller
    {
        static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionDb"].ConnectionString.ToString());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        // LOGIN UTENTE --------------------------------------------

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Utenti utente)
        {
            if (ModelState.IsValid)
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT Username, Password FROM [Utenti] " +
                                                    "WHERE @Username = Username AND @Password = Password", conn);
                    cmd.Parameters.AddWithValue("Username", utente.Username);
                    cmd.Parameters.AddWithValue("Password", utente.PasswordUsername);
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        FormsAuthentication.SetAuthCookie(utente.Username, false);
                        return RedirectToAction("Index", "Home");
                    }
                }
                catch
                {
                    return View();
                }
                finally
                {
                    conn.Close();
                }

            return View();
        }


        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}
