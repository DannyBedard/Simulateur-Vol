using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    public class Scenario
    {
        List<Aeroport> Aeroports;
        List<Aeronef> listeAeronefEnVol;
        List<Client> listeClient;

        public List<Aeroport> ListAeroport
        {
            get { return Aeroports; } 
        }
    }
}
