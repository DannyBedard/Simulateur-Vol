using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    class FabriqueClient
    {
        public void GenererClient(List<Client> clients, List<Aeroport> aeroports)
        {
            Client client;
            Random random = new Random();
            int quantite;
            //Client Secours
            quantite = random.Next(1, 2);
            for (int i=0; i<quantite; i++)
            {
                client = new Secours(PositionAleatoire());
                clients.Add(client);
            }
            //Client Incendie
            quantite = random.Next(1, 3);
            for (int i = 0; i < quantite; i++)
            {
                client = new Incendie(PositionAleatoire());
                clients.Add(client);
            }
            //Client Observateur
            client = new Observateur(PositionAleatoire());
            clients.Add(client);
        }

        private void ClientAeroport(List<Aeroport> aeroports)
        {
            Random random = new Random();
            int quantite;
            foreach (Aeroport ap in aeroports)
            {
                //Passager
                quantite = random.Next(ap.MinPassagersHeure, ap.MaxPassagersHeure);
                for(int i=0; i<quantite; i++)
                {
                    Passager client = new Passager(aeroports[random.Next(0, aeroports.Count)]);
                    ap.passagerEnAttente.Add(client);
                }
                //Marchandise
                quantite = random.Next(ap.MinPassagersHeure, ap.MaxPassagersHeure);
                for (int i = 0; i < quantite; i++)
                {
                    Marchandise client = new Marchandise(aeroports[random.Next(0, aeroports.Count)]);
                    ap.marchandiseEnAttente.Add(client);
                }
            }
        }

        private PointCartographique PositionAleatoire()
        {
            PointCartographique point;
            Random random = new Random();
            int lat = random.Next(0, 180);
            int latMin = random.Next(0, 99);
            int longi = random.Next(0, 360);
            int longiMin = random.Next(0, 99);
            string ns = random.Next(1, 2) == 1 ? "N" : "S";
            string eo = random.Next(1, 2) == 1 ? "E" : "O";

            point = new PointCartographique(lat.ToString() + "° " + latMin.ToString() + "' " + ns + ", " + longi.ToString() + "° " + longiMin.ToString() + "' " + eo);
            return point;
            //Format : 3° 18' N, 51° 6' O
        }
    }
}
