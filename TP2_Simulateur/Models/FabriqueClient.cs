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
            bool existant = false;
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
                foreach(Passager passager in ap1.passagerEnAttente)
                {
                    if (passager.Destination == client.Destination)
                    {
                        passager.Quantite += quantite;
                        existant = true;
                        break;
                    }

                }
                if(!existant)
                    ap1.passagerEnAttente.Add(client);
                //Marchandise
                existant = false;
                quantite = random.Next(ap1.MinMarchandisesHeure, ap1.MaxMarchandisesHeure);
                Marchandise marchandise = new Marchandise(aeroportsCopi[random.Next(0, aeroportsCopi.Count)], quantite);
                foreach (Marchandise marchand in ap1.marchandiseEnAttente)
                {
                    if (marchand.Destination == client.Destination)
                    {
                        marchand.Tonne += quantite;
                        existant = true;
                        break;
                    }

                }
                if (!existant)
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
