using System;
using System.Collections.Generic;
using System.Text;

namespace TP2Editeur
{
    static class FabriqueAeronef
    {
        public static Aeronef fabriquerAeronef(string type, string aeronefNom, int capacite, int vitesse, int tempsEmbarquement, int tempsDebarquement, int tempsEntretient)
        {
            // TODO: Permetre la création des autres types d'aéronef
            switch (type)
            {
                case "Passagers":
                    return new AvionPassagers(aeronefNom, capacite, vitesse, tempsEmbarquement, tempsDebarquement, tempsEntretient);
                case "Marchandises":
                // return new AvionMarchandises();
                case "Citerne":
                  //  return
                default:
                    return null;
            }
        }
        public static Aeronef fabriquerAeronef(string type, string aeronefNom, int capacite, int vitesse, int Entretient)
        {
            // TODO: Permetre la création des autres types d'aéronef
            switch (type)
            {
                case "Observateur":
                 //   return new AvionPassagers(aeronefNom, capacite, vitesse, tempsEmbarquement);
                case "Hélicoptère de secours":
                // return new AvionMarchandises();
                default:
                    return null;
            }
        }
    }
}
