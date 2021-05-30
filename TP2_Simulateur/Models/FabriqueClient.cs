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
            foreach (Aeroport ap1 in aeroports)
            {
                List<Aeroport> aeroportsCopi = new List<Aeroport>();
                foreach (Aeroport ap2 in aeroports)
                {
                    if (ap2 != ap1)
                    {
                        aeroportsCopi.Add(ap2);
                    }
                }
                
                //Passager
                quantite = random.Next(ap1.MinPassagersHeure, ap1.MaxPassagersHeure);
                Passager client = new Passager(aeroportsCopi[random.Next(0, aeroportsCopi.Count)], quantite);
                ap1.passagerEnAttente.Add(client);
                //Marchandise
                quantite = random.Next(ap1.MinPassagersHeure, ap1.MaxPassagersHeure);
                Marchandise marchandise = new Marchandise(aeroportsCopi[random.Next(0, aeroportsCopi.Count)], quantite);
                ap1.marchandiseEnAttente.Add(marchandise);
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

        public static void GenererObservateurs(List<Client> observateurs)
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
