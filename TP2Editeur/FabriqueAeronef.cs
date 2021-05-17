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
                    return new AvionMarchandises(aeronefNom, capacite, vitesse, tempsEmbarquement, tempsDebarquement, tempsEntretient);
                default:
                    return null;
            }
        }

        public static Aeronef fabriquerAeronef(string aeronefType, string aeronefNom, int vitesse, int tempsChargement, int tempsLargage, int tempsEntretient)
        {
            if (aeronefType == "Citerne")
            {
                return new AvionCiterne(aeronefNom, vitesse, tempsChargement, tempsLargage, tempsEntretient);
            }
            return null;
        }

        internal static Aeronef fabriquerAeronef(string aeronefType, string aeronefNom, int vitesse)
        {
            switch (aeronefType) {
                case "Observateur":
                    return new AvionObservateur(aeronefNom, vitesse);
                case "Hélicoptère de secours":
                    return new HelicoptereSecours(aeronefNom, vitesse);
            }
            return null;
        }
    }
}
