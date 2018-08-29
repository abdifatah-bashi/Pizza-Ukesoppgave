using Pizza_Ukesoppgave.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pizza_Ukesoppgave.ModelView
{
    public class BestillingView
    {
        public Bestilling Bestilling { get; set; }
        public List<String> PizzaTypes { get; set; }

        public BestillingView(Bestilling bestilling, List<String> pizzaTypes)
        {
            Bestilling = bestilling;
            PizzaTypes = pizzaTypes;

        }

        public BestillingView() { }
    }
}