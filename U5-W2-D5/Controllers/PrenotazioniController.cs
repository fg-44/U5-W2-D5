using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using U5_W2_D5.Models;

namespace U5_W2_D5.Controllers
{
    public class PrenotazioniController : Controller
    {
        // GET: Prenotazioni
        static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionDb"].ConnectionString.ToString());

        public ActionResult Index()
        {
            return View();
        }

        // ADD: PRENOTAZIONE

        public ActionResult Details(int id)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Prenotazioni WHERE PK_Prenotazioni = " + id, conn);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                    return View(new Prenotazioni()
                    {
                        PK_Prenotazioni = Int32.Parse(sqlDataReader["PK_Prenotazioni"].ToString()),
                        Cognome = sqlDataReader["Cognome"].ToString(),
                        Nome = sqlDataReader["Nome"].ToString(),
                        NumeroCamera = Int32.Parse(sqlDataReader["NumeroCamera"].ToString()),

                        DataPrenotazione = DateTime.Parse(sqlDataReader["DataPrenotazione"].ToString()),
                        InizioPrenotazione = DateTime.Parse(sqlDataReader["InizioPrenotazione"].ToString()),
                        FinePrenotazione = DateTime.Parse(sqlDataReader["FinePrenotazione"].ToString()),

                        MezzaPensione = Boolean.Parse(sqlDataReader["MezzaPensione"].ToString()),
                        PrimaColazione = Boolean.Parse(sqlDataReader["PrimaColazione"].ToString()),

                        Tariffa = Decimal.Parse(sqlDataReader["Tariffa"].ToString()),
                        Caparra = Decimal.Parse(sqlDataReader["Caparra"].ToString()),
                        TotaleStanza = Decimal.Parse(sqlDataReader["TotaleStanza"].ToString()), 
                    });
            }
            catch
            { }
            finally
            {
                conn.Close();
            }

            return View();
        }

        //CREATE: PRENOTAZIONE
        public ActionResult Create(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public ActionResult Create(AddPrenotazione prenotazione)
        {
            if (ModelState.IsValid)
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO [T_Prenotazioni] VALUES (@FkCliente, @FkCamera, @DataPrenotazione, @Dal, @Al, @Caparra, @Tariffa, @MezzaPensione, @PrimaColazione)", conn);
                    cmd.Parameters.AddWithValue("PK_Prenotazioni ", prenotazione.PK_Prenotazioni);
                    cmd.Parameters.AddWithValue("Cognome", prenotazione.Cognome);
                    cmd.Parameters.AddWithValue("Nome", prenotazione.Nome);
                    cmd.Parameters.AddWithValue("NumeroCamera", prenotazione.NumeroCamera);

                    cmd.Parameters.AddWithValue("DataPrenotazione", DateTime.Now);
                    cmd.Parameters.AddWithValue("InizioPrenotazione", prenotazione.InizioPrenotazione);
                    cmd.Parameters.AddWithValue("FinePrenotazione ", prenotazione.FinePrenotazione);

                    cmd.Parameters.AddWithValue("MezzaPensione", prenotazione.MezzaPensione);
                    cmd.Parameters.AddWithValue("PrimaColazione", prenotazione.PrimaColazione);

                    cmd.Parameters.AddWithValue("Caparra", prenotazione.Caparra);
                    cmd.Parameters.AddWithValue("Tariffa", prenotazione.Tariffa);

                    cmd.ExecuteNonQuery();

                    return RedirectToAction("Index");
                }
                catch
                {
                }
                finally
                {
                    conn.Close();
                }

            return View(prenotazione);
        }

        //EDIT : PRENOTAZIONE
        public ActionResult Edit(int id)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM V_Prenotazioni WHERE PkPrenotazione = " + id, conn);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                    return View(new AddPrenotazione()
                    {
                        PK_Prenotazioni = id,
                        Cognome = sqlDataReader["Cognome"].ToString(),
                        Nome = sqlDataReader["Nome"].ToString(),
                        NumeroCamera = Int32.Parse(sqlDataReader["NumeroCamera"].ToString()),

                        DataPrenotazione = DateTime.Parse(sqlDataReader["DataPrenotazione"].ToString()),
                        InizioPrenotazione = DateTime.Parse(sqlDataReader["InizioPrenotazione"].ToString()),
                        FinePrenotazione = DateTime.Parse(sqlDataReader["FinePrenotazione"].ToString()),

                        MezzaPensione = Boolean.Parse(sqlDataReader["MezzaPensione"].ToString()),
                        PrimaColazione = Boolean.Parse(sqlDataReader["PrimaColazione"].ToString()),

                        Tariffa = Decimal.Parse(sqlDataReader["Tariffa"].ToString()),
                        Caparra = Decimal.Parse(sqlDataReader["Caparra"].ToString()),

                    }); ;
            }
            catch
            { }
            finally
            {
                conn.Close();
            }

            return View();
        }

        [HttpPost]
        public ActionResult Edit(AddPrenotazione prenotazione)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(String.Concat("@NumeroCamera, @Cognome, @Nome, @NumeroCamera, @DataPrenotazione, @DataPrenotazione, @InizioPrenotazione, @FinePrenotazione, @MezzaPensione, @PrimaColazione, @Caparra, @Tariffa ", prenotazione.PK_Prenotazioni), conn);

                cmd.Parameters.AddWithValue("NumeroCamera", prenotazione.NumeroCamera);
                cmd.Parameters.AddWithValue("Cognome", prenotazione.Cognome);
                cmd.Parameters.AddWithValue("Nome", prenotazione.Nome);
                cmd.Parameters.AddWithValue("NumeroCamera", prenotazione.NumeroCamera);
                cmd.Parameters.AddWithValue("DataPrenotazione", prenotazione.DataPrenotazione);

                cmd.Parameters.AddWithValue("InizioPrenotazione", prenotazione.InizioPrenotazione);
                cmd.Parameters.AddWithValue("FinePrenotazione ", prenotazione.FinePrenotazione);

                cmd.Parameters.AddWithValue("MezzaPensione", prenotazione.MezzaPensione);
                cmd.Parameters.AddWithValue("PrimaColazione", prenotazione.PrimaColazione);

                cmd.Parameters.AddWithValue("Caparra", prenotazione.Caparra);
                cmd.Parameters.AddWithValue("Tariffa", prenotazione.Tariffa);

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

        // DELETE : PRENOTAZIONE
        public ActionResult Delete(int id)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [Prenotazioni] WHERE Pk_Prenotazioni = @PK_Prenotazioni", conn);
                cmd.Parameters.AddWithValue("PK_Prenotazioni", id);
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

        //CHECKOUT CLIENTE
        public ActionResult Checkout(int Id)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Prenotazioni WHERE PK_Prenotazione = " + Id, conn);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                    return View(new CheckoutFinale()
                    {
                        PK_Prenotazioni = Int32.Parse(sqlDataReader["PK_Prenotazione"].ToString()),
                        NumeroCamera = Int32.Parse(sqlDataReader["NumeroCamera"].ToString()),
                        Cognome = sqlDataReader["Cognome"].ToString(),
                        Nome = sqlDataReader["Nome"].ToString(),
                        PreiodoPernottamento = String.Concat(sqlDataReader["InizioPrenotazione"].ToString(), " - ", sqlDataReader["FinePrenotazione "].ToString()),
                        Tariffa = Decimal.Parse(sqlDataReader["Tariffa"].ToString()),
                        Caparra = Decimal.Parse(sqlDataReader["Caparra"].ToString()),
                        //TotaleStanza = Decimal.Parse(sqlDataReader["Tariffa"].ToString()) - Decimal.Parse(sqlDataReader["Caparra"].ToString()) + RichiesteController.GetTotale(Id) // RIATTIVA APPENA CONCLUDI RICHIESTE CONTROLLER
                    });
            }
            catch
            { }
            finally
            {
                conn.Close();
            }

            return View();
        }



        //[AllowAnonymous]
        // public JsonResult CheckStanza(int NumeroCamera) {}
        //INSERISCI DATI PER CALCOLO SE LA STANZA E LIBERA

    }
}