using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pizza_Ukesoppgave.Models
{
    public class Kunde
    {
        public Kunde()
        {
        }
        public int Id { get; set; }
        [Display(Name = "Navn")]
       
        public string Navn { get; set; }
        [Display(Name = "Adresse")]
        public string Adresse { get; set; }
        [Display(Name = "Telefoner")]
        public string Telefoner { get; set; }
        public virtual List<Bestilling> Bestilling { get; set; }
        public Kunde(String navn, String adresse, String telefoner)
        {
            Navn = navn;
            Adresse = adresse;
            Telefoner = telefoner;
        }
       
    }
}