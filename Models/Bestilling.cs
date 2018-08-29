using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pizza_Ukesoppgave.Models
{
    public class Bestilling
    {
        public int Id { get; set; }
        [Display(Name = "PizzaType")]
        public string PizzaType { get; set; }
        [Display(Name = "Tykkelse")]
        public string  Tykkelse { get; set; }
        [Display(Name = "Antall")]
        public int Antall { get; set; }
        public int KundeId { get; set; }
        public virtual Kunde Kunde { get; set; }
     

    }
}