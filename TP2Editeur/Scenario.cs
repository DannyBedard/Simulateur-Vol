using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TP2Editeur
{
    [XmlInclude(typeof(AvionPassagers))]
    [XmlInclude(typeof(AvionCiterne))]
    public class Scenario
    {
        private List<Aeroport> lstAeroports = new List<Aeroport>(); 
        public List<Aeroport> Aeroports { get { return lstAeroports; } set {lstAeroports = value; } }
        public void ajouterAeroport(Aeroport aeroport) {
            Aeroports.Add(aeroport);
        }
        public void serialize(string chemin) {
            XmlSerializer serializer = new XmlSerializer(typeof(Scenario));
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.Unicode;
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create(chemin, settings);
            serializer.Serialize(writer, this);
        }
        /// <summary>
        /// Ajoute un aeronef à l'aeroport situé à l'index reçu en paramêtre
        /// </summary>
        /// <param name="apIndex">Index de l'aéroport</param>
        /// <param name="aeronefNom">Nom de l'Aeronef</param>
        /// <param name="aeronefType">Type de l'aeronef</param>
        /// <param name="tempsEmbarquement">Temps d'embarquement</param>
        /// <param name="tempsDebarquement">Temps de debarquement</param>
        /// <param name="tempsEntretient">Temps d'entretient</param>
        /// <param name="vitesse">Vitesse</param>
        /// <param name="capacite">Capacité</param>
        public void ajouterAeronef(int apIndex, string aeronefType, string aeronefNom, int capacite, int vitesse, int tempsEmbarquement, int tempsDebarquement, int tempsEntretient)
        {
            Aeroport aeroport = Aeroports[apIndex];
            aeroport.ajouterAeronef(aeronefType, aeronefNom, capacite, vitesse, tempsEmbarquement, tempsDebarquement, tempsEntretient);
        }

        internal void ajouterAeronef(int apIndex, string aeronefType, string aeronefNom, int vitesse, int tempsChargement, int tempsLargage, int tempsEntretient)
        {
            Aeroport aeroport = Aeroports[apIndex];
            aeroport.ajouterAeronef(aeronefType, aeronefNom, vitesse, tempsChargement, tempsLargage, tempsEntretient);
        }
    }
}
