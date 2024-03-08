using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace U5_W2_D5.Models
{
    public class Utenti
    {

        //USERNAME
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Required field!")]
        [Editable(true)]
        public string Username { get; set; }

        //[Display(Name = "Role")]
        //[Required(ErrorMessage = "Required field!")]
        //[Editable(true)] 
        public string RoleUsername { get; set; } //SOLO SE AVANZA TEMPO

        //PASSWORD
        [Display(Name = ("Password"))]
        [Required(ErrorMessage = "Required field!")]
        [DataType(DataType.Password)]
        public string PasswordUsername { get; set; }
    }
}