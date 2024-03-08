using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace U5_W2_D5.Models
{
    public class Clienti

    {
        // COGNOME CLIENTE
        [Display(Name = "Cognome")]
        [Required(ErrorMessage = "Required field!")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "The Surname must have a minimum of 1 character")]
        public string Cognome { get; set; }

        // NOME CLIENTE
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Required field!")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "The FirstName must have a minimum of 1 character")]    
        public string Nome { get; set; }


        // ADDRESS CLIENT
        [Display(Name = "Indirizzo")]
        [Required(ErrorMessage = "Required field!")]
        [Editable(true)]
        public string Indirizzo { get; set; }

        // CITTA CLIENTE
        [Display(Name = "Città")]
        [Required(ErrorMessage = "Required field!")]
        [Editable(true)]
        public string Città { get; set; }

        // PROVINCIA
        [Display(Name = "Città")]
        [Required(ErrorMessage = "Required field!")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Questo campo prevede solo 2 caratteri!")]
        [Editable(true)]
        public string Provincia { get; set; }

        // CODICE FISCALE
        [Display(Name = "CodiceFiscale")]
        [Required(ErrorMessage = "Required field!")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Il codice fiscale deve avere un minimo di 16 caratteri")]
        [Remote("CheckExistingPartitaIva", "Home", ErrorMessage = "Questo codice fiscale esiste già!")]
        public string Cod_fisc { get; set; }

        // EMAIL
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Required field!")]
        [DataType(DataType.EmailAddress)]
        [Remote("CheckExistingEmail", "Clienti", ErrorMessage = "l'Email esiste già nel database.")]  // REMOTE Serve per controllare se  la TAX CODE è E GIA ESISTENTE
        public string Email { get; set; }


        // TELEPHONE NUMBER
        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "Required field!")]
        [StringLength(11, MinimumLength = 9, ErrorMessage = "Questo campo deve avere un minimo di 1 carattere")]    
        [Remote("IsAlreadySigned", "Clienti", HttpMethod = "POST", ErrorMessage = "Il numero di telefono esiste già nel database.")]
        [Editable(true)]
        public string Telefono { get; set; }



    }
}
