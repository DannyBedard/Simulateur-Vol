using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TP2_Simulateur.Models
{
    public class Aeroport
    { 
        public string Nom { get; set; }
        public List<Aeronef> Aeronefs;
        public int MaxPassagersHeure;
        public int MinPassagersHeure;
        public int MaxMarchandisesHeure;
        public int MinMarchandisesHeure;
        public PointCartographique Position { get; set; }
        public Aeroport() { }
        public Aeroport(string nom, string position) {
            Position = new PointCartographique(position);
            Nom = nom;
        }
        public Aeroport(string nom, PointCartographique position)
        {
            Position = position;
            Nom= nom;
        }
    }
}
