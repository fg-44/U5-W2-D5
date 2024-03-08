using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI;
using U5_W2_D5.Models;

namespace U5_W2_D5.Controllers
{
    public class ClientiController : Controller
    {
        // GET: Stanze ------------------------------
        static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionDb"].ConnectionString.ToString());
        public ActionResult Index()
        {

            List<Clienti> clientiList = new List<Clienti>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Clienti", conn);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                    clientiList.Add(new Clienti()
                    {
                        Cognome = sqlDataReader["Cognome"].ToString(),
                        Nome = sqlDataReader["Nome"].ToString(),
                        Città = sqlDataReader["Citta"].ToString(),
                        Provincia = sqlDataReader["Provincia"].ToString(),
                        Cod_fisc = sqlDataReader["CF"].ToString(),
                        Email = sqlDataReader["email"].ToString(),
                        Telefono = sqlDataReader["Telefono"].ToString(),
                    });
            }
            catch
            { }
            finally
            {
                conn.Close();
            }

            return View(clientiList);
        }


        // DETTAGLI CLIENT* --------------------------   
        public ActionResult Dettagli(string Id)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM [Clienti] WHERE Cod_fisc = @Cod_fisc", conn);
                cmd.Parameters.AddWithValue("Cod_fisc", Id);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                    return View(new Clienti()
                    {
                        Cognome = sqlDataReader["Cognome"].ToString(),
                        Nome = sqlDataReader["Nome"].ToString(),
                        Città = sqlDataReader["Citta"].ToString(),
                        Provincia = sqlDataReader["Provincia"].ToString(),
                        Cod_fisc = sqlDataReader["Cod_fisc"].ToString(),
                        Email = sqlDataReader["Email"].ToString(),
                        Telefono = sqlDataReader["Telefono"].ToString(),
                    });
            }
            catch
            { }
            finally
            {
                conn.Close();
            }

            return RedirectToAction("Index");
        }


        // CREATE: CLIENT* ---------------------------

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Clienti cliente)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [Clienti] VALUES (@Cognome, @Nome, @Città, @Provincia, @Cod_fisc, @Email, @Telefono)", conn);
                cmd.Parameters.AddWithValue("Cognome", cliente.Cognome);
                cmd.Parameters.AddWithValue("Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("Citta", cliente.Città);
                cmd.Parameters.AddWithValue("Provincia", cliente.Provincia);
                cmd.Parameters.AddWithValue("Cod_fisc", cliente.Cod_fisc);
                cmd.Parameters.AddWithValue("Email", cliente.Email);
                cmd.Parameters.AddWithValue("Telefono", cliente.Telefono);
                cmd.ExecuteNonQuery();
            }
            catch
            { }
            finally
            {
                conn.Close();
            }

            return RedirectToAction("Index");
        }

        // EDIT: CLIENT* -----------------------------

        public ActionResult Edit(int Id)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("TOP 1 * FROM [Clienti] WHERE Cod_fisc = @Cod_fisc", conn);
                cmd.Parameters.AddWithValue("Cod_fisc", Id);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                    return View(new Clienti
                    {

                        Cognome = sqlDataReader["Cognome"].ToString(),
                        Nome = sqlDataReader["Nome"].ToString(),
                        Città = sqlDataReader["Citta"].ToString(),
                        Provincia = sqlDataReader["Provincia"].ToString(),
                        Cod_fisc = sqlDataReader["Cod_fisc"].ToString(),
                        Email = sqlDataReader["Email"].ToString(),
                        Telefono = sqlDataReader["Telefono"].ToString(),

                    });
            }
            catch
            { }
            finally
            {
                conn.Close();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Clienti cliente)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE [Clienti] SET (@Cognome, @Nome, @Città, @Provincia, @Cod_fisc, @Email, @Telefono)", conn);

                cmd.Parameters.AddWithValue("Cognome", cliente.Cognome);
                cmd.Parameters.AddWithValue("Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("Citta", cliente.Città);
                cmd.Parameters.AddWithValue("Provincia", cliente.Provincia);
                cmd.Parameters.AddWithValue("Cod_fisc", cliente.Cod_fisc);
                cmd.Parameters.AddWithValue("Email", cliente.Email);
                cmd.Parameters.AddWithValue("Telefono", cliente.Telefono);
                cmd.ExecuteNonQuery();
            }
            catch
            { }
            finally
            {
                conn.Close();
            }

            return RedirectToAction("Index");
        }

        // --------------------------------------------
    }
}
