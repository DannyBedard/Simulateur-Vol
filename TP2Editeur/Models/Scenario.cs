using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TP2Editeur
{
    [XmlInclude(typeof(AvionPassagers))]
    [XmlInclude(typeof(AvionCiterne))]
    [XmlInclude(typeof(AvionMarchandises))]
    [XmlInclude(typeof(AvionObservateur))]
    [XmlInclude(typeof(HelicoptereSecours))]
    public class Scenario
    {
        private List<Aeroport> lstAeroports = new List<Aeroport>();
        private PositionCartographique position;
        public List<Aeroport> Aeroports { get { return lstAeroports; } set {lstAeroports = value; } }
        public void AjouterAeroport(Aeroport aeroport) {
            Aeroports.Add(aeroport);
        }
        public void ModifierAeroport(string apName, string apPosition, int minPassager, int maxPassager, int minMarchandise, int maxMarchandise, int index)
        {
            lstAeroports[index].Nom = apName;
            lstAeroports[index].Position = apPosition;
            lstAeroports[index].MinPassagersHeure = minPassager;
            lstAeroports[index].MaxPassagersHeure = maxPassager;
            lstAeroports[index].MinMarchandisesHeure = minMarchandise;
            lstAeroports[index].MaxMarchandisesHeure = maxMarchandise;
        }
        public void SupprimerAeroport(int index)
        {
            lstAeroports.RemoveAt(index);
        }
        public void Serialize(string chemin) {
            if (chemin == "")
                return;
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
        public void AjouterAeronef(int apIndex, string aeronefType, string aeronefNom, int capacite, int vitesse, int tempsEmbarquement, int tempsDebarquement, int tempsEntretient)
        {
            Aeroport aeroport = Aeroports[apIndex];
            aeroport.ajouterAeronef(aeronefType, aeronefNom, capacite, vitesse, tempsEmbarquement, tempsDebarquement, tempsEntretient);
        }

        public void AjouterAeronef(int apIndex, string aeronefType, string aeronefNom, int vitesse, int tempsChargement, int tempsLargage, int tempsEntretient)
        {
            Aeroport aeroport = Aeroports[apIndex];
            aeroport.ajouterAeronef(aeronefType, aeronefNom, vitesse, tempsChargement, tempsLargage, tempsEntretient);
        }

        internal void AjouterAeronef(int apIndex, string aeronefType, string aeronefNom, int vitesse)
        {
            Aeroport aeroport = Aeroports[apIndex];
            aeroport.ajouterAeronef(aeronefType, aeronefNom, vitesse);
        }

        public void ModifierAeronef(int apIndex, string aeronefType, string aeronefNom, int capacite, int vitesse, int tempsEmbarquement, int tempsDebarquement, int tempsEntretient, int index)
        {
            Aeroport aeroport = Aeroports[apIndex];
            aeroport.ajouterAeronef(aeronefType, aeronefNom, capacite, vitesse, tempsEmbarquement, tempsDebarquement, tempsEntretient);
            aeroport.SupprimerAeronef(index);
        }

        public void ModifierAeronef(int apIndex, string aeronefType, string aeronefNom, int vitesse, int tempsChargement, int tempsLargage, int tempsEntretient, int index)
        {
            Aeroport aeroport = Aeroports[apIndex];
            aeroport.ajouterAeronef(aeronefType, aeronefNom, vitesse, tempsChargement, tempsLargage, tempsEntretient);
            aeroport.SupprimerAeronef(index);
        }

        internal void ModifierAeronef(int apIndex, string aeronefType, string aeronefNom, int vitesse, int index)
        {
            Aeroport aeroport = Aeroports[apIndex];
            aeroport.ajouterAeronef(aeronefType, aeronefNom, vitesse);
            aeroport.SupprimerAeronef(index);
        }

        public void SupprimerAeronef(int apIndex, int index)
        {
            Aeroport aeroport = Aeroports[apIndex];
            aeroport.SupprimerAeronef(index);
        }
    }
}
