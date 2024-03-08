using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using U5_W2_D5.Models;

namespace U5_W2_D5.Controllers
{
    public class StanzeController : Controller
    {
        static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionDb"].ConnectionString.ToString());

        // GET: Stanze
        public ActionResult Index()
        {
            List<Stanze> stanzeList = new List<Stanze>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Stanze", conn);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                    stanzeList.Add(new Stanze()
                    {
                        PK_Camera = Int32.Parse(sqlDataReader["PkCamera"].ToString()),
                        Descrizione = sqlDataReader["Descrizione"].ToString(),
                        Classificazione = sqlDataReader["Classificazione"].ToString(),
                        IsOccupata = Boolean.Parse(sqlDataReader["Occupata"].ToString()),
                    });
            }
            catch
            { }
            finally
            {
                conn.Close();
            }

            return View(stanzeList);
        }
    }
}
