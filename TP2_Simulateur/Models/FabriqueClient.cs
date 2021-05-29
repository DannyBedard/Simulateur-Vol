using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    class FabriqueClient
    {
        private static readonly Random random = new Random();
        private static readonly object locker = new object();
        public static void GenererClientAeroport(List<Aeroport> aeroports)
        {
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

        public static void GenererIncendies(List<Client> incendies)
        {
            Client client;
            int quantite;
            lock (locker) 
            {
                quantite = random.Next(1, 3);
            }
            
            for (int i = 0; i < quantite; i++)
            {
                client = new Incendie(PointCartographique.Random());
                incendies.Add(client);
            }
        }

        public static void GenererObservation(List<Client> observateurs)
        {
            Client client;
            client = new Observateur(PointCartographique.Random());
            observateurs.Add(client);
        }

        public static void GenererSecours(List<Client> secours)
        {
            Client client;
            int quantite;
            lock (locker) 
            {
                quantite = random.Next(1, 2);
            }
            
            for (int i = 0; i < quantite; i++)
            {
                client = new Secours(PointCartographique.Random());
                secours.Add(client);
            }
        }
    }
}
