using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace U5_W2_D5.Models
{
    public class Prenotazioni
    {

        //PK_CLIENT
        [Display(Name = "Numero Prenotazione")]
        public int PK_Prenotazioni { get; set; }

        // COGNOME CLIENTE
        [Display(Name = "Cognome")]
        [Required(ErrorMessage = "Required field!")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "The Surname must have a minimum of 1 character")]
        [RegularExpression("([a-zA-z9-0 '-])", ErrorMessage = "Enter Only Alphabets of Surname")]                  //REGULAREXPRESSION Serve a restringere il campo dei caratteri ammessi
        public string Cognome { get; set; }

        // NOME CLIENTE
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Required field!")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "The FirstName must have a minimum of 1 character")]
        [RegularExpression("([a-zA-z9-0 '-])", ErrorMessage = "Enter Only Alphabets of FirstName ")]                  //REGULAREXPRESSION Serve a restringere il campo dei caratteri ammessi
        public string Nome { get; set; }

        //NUMERO CAMERA

        [Display(Name = "Numero Camera")]
        [Required(ErrorMessage = "Required field!")]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "La camera deve avere un numero riconoscimento di almeno un carattere!")]
        public int NumeroCamera { get; set; }


        //DATE SULLA PRENOTAZIONE -----------------------------

        //DATE Prenotazione
        [Display(Name = "Data Prenotazione (dd/MM/yyyy)")]
        [Required(ErrorMessage = "Required field!")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]       // REGOLAMENTA la modalità di visualizazione Della data
        public DateTime DataPrenotazione { get; set; }


        //DATE ARRIVO -----------------------------------

        [Display(Name = "Data arrivo (dd/MM/yyyy)")]
        [Required(ErrorMessage = "Required field!")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]       // REGOLAMENTA la modalità di visualizazione Della data
        public DateTime InizioPrenotazione { get; set; }

        //DATE PARTENZA
        [Display(Name = "Data Partenza (dd/MM/yyyy)")]
        [Required(ErrorMessage = "Required field!")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]       // REGOLAMENTA la modalità di visualizazione Della data
        public DateTime FinePrenotazione { get; set; }


        // DETTAGLI PRENOTAZIONE ------------------------

        [Display(Name = ("Mezza penzione"))]
        public Boolean MezzaPensione { get; set; }

        [Display(Name = ("Prima Colazione"))]
        public Boolean PrimaColazione { get; set; }

        //PREZZO STANZA ---------------------------

        //CAPARRA
        [Display(Name = "Caparra")]
        [Required(ErrorMessage = "Required field!")]
        public decimal Caparra { get; set; }

        //TARIFFA
        [Display(Name = "Tariffa")]
        [Required(ErrorMessage = "Required field!")]
        public decimal Tariffa { get; set; }

        //TOTALE STANZA
        [Display(Name = "Totale Stanza")]
        [Required(ErrorMessage = "Required field!")]
        public decimal TotaleStanza { get; set; }

    }

    public class AddPrenotazione
    {
        //PK_CLIENT della prenotazione
        [Display(Name = "Numero Prenotazione")]
        public int PK_Prenotazioni { get; set; }

        // COGNOME CLIENTE
        [Display(Name = "Cognome")]
        [Required(ErrorMessage = "Required field!")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Questo campo non è completo!")] 
        public string Cognome { get; set; }

        // NOME CLIENTE
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Required field!")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Questo campo non è completo!")]
        public string Nome { get; set; }

        //NUMERO CAMERA

        [Display(Name = "Numero Camera")]
        [Required(ErrorMessage = "Required field!")]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "La camera deve avere un numero riconoscimento di almeno un carattere!")]
        public int NumeroCamera { get; set; }

        //DATE SULLA PRENOTAZIONE -----------------------------

        //DATE Prenotazione
        [Display(Name = "Data Prenotazione (dd/MM/yyyy)")]
        [Required(ErrorMessage = "Required field!")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]       // REGOLAMENTA la modalità di visualizazione Della data
        public DateTime DataPrenotazione { get; set; }

        // DATA ARRIVO
        [Display(Name = "Data arrivo (dd/MM/yyyy)")]
        [Required(ErrorMessage = "Required field!")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]       // REGOLAMENTA la modalità di visualizazione Della data
        public DateTime InizioPrenotazione { get; set; }

        // DATA PARTENZA
        [Display(Name = "Data Partenza (dd/MM/yyyy)")]
        [Required(ErrorMessage = "Required field!")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]       // REGOLAMENTA la modalità di visualizazione Della data
        public DateTime FinePrenotazione { get; set; }

        // DETTAGLI PRENOTAZIONE ------------------------

        [Display(Name = ("Mezza penzione"))]
        public Boolean MezzaPensione { get; set; }

        [Display(Name = ("Prima Colazione"))]
        public Boolean PrimaColazione { get; set; }

        //PREZZO STANZA ---------------------------

        //CAPARRA
        [Display(Name = "Caparra")]
        [Required(ErrorMessage = "Required field!")]
        public decimal Caparra { get; set; }

        //TARIFFA
        [Display(Name = "Tariffa")]
        [Required(ErrorMessage = "Required field!")]
        public decimal Tariffa { get; set; }

    }

    public class CheckoutFinale
    {
        // FK_CLIENTE DELLA PRENOTAZIONE
        [Display(Name = "Numero Prenotazione")]
        public int PK_Prenotazioni { get; set; }

        // COGNOME CLIENTE
        [Display(Name = "Cognome")]
        [Required(ErrorMessage = "Required field!")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Questo campo non è completo!")]
        public string Cognome { get; set; }

        // NOME CLIENTE
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Required field!")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Questo campo non è completo!")]
        public string Nome { get; set; }

        //NUMERO CAMERA
        [Display(Name = "Numero Camera")]
        [Required(ErrorMessage = "Required field!")]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "La camera deve avere un numero riconoscimento di almeno un carattere!")]
        public int NumeroCamera { get; set; }


        [Display(Name = "Periodo pernottamento")]
        [Required(ErrorMessage = "Required field!")]
        public string PreiodoPernottamento { get; set; }

        //PREZZO STANZA ---------------------------

        //CAPARRA
        [Display(Name = "Caparra")]
        [Required(ErrorMessage = "Required field!")]
        public decimal Caparra { get; set; }

        //TARIFFA
        [Display(Name = "Tariffa")]
        [Required(ErrorMessage = "Required field!")]
        public decimal Tariffa { get; set; }

        //TOTALE STANZA
        [Display(Name = "Totale")]
        [Required(ErrorMessage = "Required field!")]
        public decimal TotaleStanza { get; set; }
    }
}