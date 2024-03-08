using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace U5_W2_D5.Models
{
    public class Stanze
    {
        //NUMERO CAMERA
        [Display(Name = "Numero Camera")]
        [Required]
        [Range(0,400)]
        public int PK_Camera { get; set; }

        //DESCRIZIONE
        [Display(Name = "Numero Camera")]
        [Required]
        public string Descrizione { get; set; }

        [Display(Name = "Classificazione ")]
        [Required]
        public string Classificazione { get; set; }

        [Display(Name = ("Stato della camera"))]
        public Boolean IsOccupata { get; set; }

    }
}