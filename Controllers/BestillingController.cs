using Pizza_Ukesoppgave.Models;
using Pizza_Ukesoppgave.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pizza_Ukesoppgave.Controllers
{
    public class BestillingController : Controller
    {
        // init database
        DB db;

        public BestillingController()
        {
          db  = new DB();

        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
        // GET: Bestilling
        public ActionResult Liste()
        {
            var alleBestillinger = db.Bestillinger.ToList();
   
            return View(alleBestillinger);
        }

        public ActionResult Register()
        {
            var bestilling = new Bestilling();
            List<String> pizzaTypes = new List<string>
            { "Margherita (kr 100)", "Primavera (kr 150)", "IndiaVolata (kr 200)"};
            BestillingView bestillingViewModel = new BestillingView(bestilling, pizzaTypes);
            
            return View(bestillingViewModel);
        }

        [HttpPost]
        public ActionResult Lagre(BestillingView bestillingModel)
        {
            // Sjekk hvis kunden eksisterer 
          
            var dbKunde = db.Kunder.SingleOrDefault(k => k.Navn == bestillingModel.Bestilling.Kunde.Navn);

            if (dbKunde == null)
            {
                //Opprett kunde objekt
                Kunde kunde = bestillingModel.Bestilling.Kunde;
                
                    db.Kunder.Add(kunde);
                    db.SaveChanges();
                    db.Bestillinger.Add(bestillingModel.Bestilling);
                   db.SaveChanges();
                  return RedirectToAction("Liste");

            } else
            {
                int kundeId = dbKunde.Id;
                var bestilling = new Bestilling
                {
                    PizzaType = bestillingModel.Bestilling.PizzaType,
                    Tykkelse = bestillingModel.Bestilling.Tykkelse,
                    Antall = bestillingModel.Bestilling.Antall,
                    KundeId = kundeId

                };


                db.Bestillinger.Add(bestilling);
                db.SaveChanges();
                return RedirectToAction("Liste");
            }

        }

        // Slett bestilling
        public ActionResult Slett(int id)
        {
            var bestilling = db.Bestillinger.SingleOrDefault(b => b.Id == id);
            db.Bestillinger.Remove(bestilling);
            db.SaveChanges();
            return RedirectToAction("Liste");
        }
       

    }
}