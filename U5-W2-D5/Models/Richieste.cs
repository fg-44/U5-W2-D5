using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace U5_W2_D5.Models
{
    public class Richieste
    {
            
        //RICHIESTA 
        [Display(Name = "Numero Richiesta")]
        [Required(ErrorMessage = "Required field!")]
        public int PK_Richiesta { get; set; }

        //PRENOTAZIONE SERVIZIO
        [Display(Name = "Prenotazione Servizio")]
        [Required(ErrorMessage = "Required field!")]
        public int FK_PrenotazioneServizio { get; set; }

        //NUMERO TIPOLOGIA

        [Display(Name = "Tipo di Servizio")]
        [Required(ErrorMessage = "Required field!")]
        public int FK_Tipologia { get; set; }

        //RICHIESTA TIPO
        [Display(Name = "Richiesta")]
        [Required(ErrorMessage = "Required field!")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Elabora correttamente la tua richiesta!")]
        [RegularExpression("([a-zA-z9-0 '-])", ErrorMessage = "Enter Only Alphabets of FirstName ")]                  //REGULAREXPRESSION Serve a restringere il campo dei caratteri ammessi
        public string Richiesta { get; set; }

        //PREZZO
        [Display(Name = "Prezzo")]
        [Required(ErrorMessage = "Required field!")]
        public decimal Prezzo { get; set; }

        //DATE RICHIESTA
        [Display(Name = "Data Richiesta (dd/MM/yyyy)")]
        [Required(ErrorMessage = "Required field!")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]       // REGOLAMENTA la modalità di visualizazione Della data
        public string DataRichiesta { get; set; }



    }
}