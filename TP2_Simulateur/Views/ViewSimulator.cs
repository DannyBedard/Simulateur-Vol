using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Windows.Forms;
using TP2_Simulateur.Models;

namespace TP2_Simulateur
{
    public partial class ViewSimulator : Form
    {
        private static readonly object lockObject = new object();
        COTAI controleur;
        /// <summary>
        /// Liste des points Aeroports
        /// </summary>
        private List<PointF> airportPoints = new List<PointF>();
        /// <summary>
        /// Liste des points aeronef
        /// </summary>
        private List<PointF> AeronefPoints = new List<PointF>();
        /// <summary>
        /// Liste des trajectoires et leur couleur
        /// </summary>
        private List<Tuple<PointF[], Color>> trajectoires = new List<Tuple<PointF[], Color>>();
        /// <summary>
        /// Liste des points de secours
        /// </summary>
        private List<PointF> secoursPoints = new List<PointF>();
        /// <summary>
        /// Liste des points d'incendie
        /// </summary>
        private List<PointF> incendiePoints = new List<PointF>();
        /// <summary>
        /// Liste des points d'observation
        /// </summary>
        private List<PointF> observateurPoints = new List<PointF>();
        /// <summary>
        /// Temps inital
        /// </summary>
        private string temps = "00:00:00";
        /// <summary>
        /// Image sur laquelle dessiner
        /// </summary>
        private Bitmap image;
        /// <summary>
        /// Taille de l'image
        /// </summary>
        private SizeF tailleImage;
        public ViewSimulator(COTAI controleur)
        {
            this.controleur = controleur;
            InitializeComponent();
        }
        /// <summary>
        /// Charge la carte du monde à afficher 
        /// </summary>
        /// <param name="p_map">Carte du monde</param>
        internal void LoadMap(Bitmap p_map)
        {

            picMap.BackgroundImage = p_map;
            tailleImage = picMap.BackgroundImage.Size;
            image = new Bitmap((int)tailleImage.Width, (int)tailleImage.Height);
        }
        /// <summary>
        /// Définit le temps à afficher
        /// </summary>
        /// <param name="p_temps">Temps à afficher</param>
        public void AfficherTemps(string p_temps)
        {
            temps = p_temps;
        }

        /// <summary>
        /// Dessine les avions aux points dans la liste AeronefPoints
        /// </summary>
        private void DessinerAvion()
        {
            Graphics g = Graphics.FromImage(image);
            Image avionImg = new Bitmap("Ressources/avion.png");
            lock (lockObject)
            {
                foreach (PointF point in AeronefPoints)
                {
                    g.DrawImage(avionImg, new RectangleF(point, new SizeF(40, 40)));
                }
                AeronefPoints.Clear();
            }

            avionImg.Dispose();
            g.Dispose();
        }
        /// <summary>
        /// Dessine les trajectoires contenues dans la liste trajectoires
        /// </summary>
        private void DessinerTrajectoires()
        {
            Graphics g = Graphics.FromImage(image);

            foreach (Tuple<PointF[], Color> trajet in trajectoires)
            {

                PointF depart = trajet.Item1[0];
                PointF actuel = trajet.Item1[1];
                Pen pLigne = new Pen(trajet.Item2, 5);
                g.DrawLine(pLigne, depart, actuel);
                pLigne.Dispose();
            }

            g.Dispose();
            trajectoires.Clear();
        }
        /// <summary>
        /// Dessine un aéroport aux points dans la liste airportPoints
        /// </summary>
        private void DessinerAeroports()
        {
            Graphics g = Graphics.FromImage(image);
            Image aeroportImg = new Bitmap("Ressources/aeroport.png");
            lock (lockObject)
            {
                foreach (PointF point in airportPoints)
                {
                    g.DrawImage(aeroportImg, new RectangleF(new PointF(point.X - 15, point.Y - 15), new Size(30, 30)));
                }
            }

            aeroportImg.Dispose();
            g.Dispose();

        }
        /// <summary>
        /// Dessine le temps sur la vue
        /// </summary>
        private void DessinerTemps()
        {
            RectangleF rectf = new RectangleF(image.Width - 600, image.Height - 100, 535, 90);
            Graphics g = Graphics.FromImage(image);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            g.DrawString(temps, new System.Drawing.Font("Tahoma", 32, FontStyle.Bold), Brushes.Red, rectf, sf);
            g.Dispose();
            sf.Dispose();
        }
        /// <summary>
        /// Dessine les incendies aux points dans la liste incendiePoints
        /// </summary>
        private void DessinerIncendies()
        {
            Graphics g = Graphics.FromImage(image);
            Image feuImg = new Bitmap("Ressources/incendie.png");
            lock (lockObject)
            {
                foreach (PointF point in incendiePoints)
                {
                    g.DrawImage(feuImg, new RectangleF(point, new Size(30, 30)));

                }
            }

            feuImg.Dispose();
            g.Dispose();
        }
        /// <summary>
        /// Dessine les secours aux points dans la liste secoursPoints
        /// </summary>
        private void DessinerSecours()
        {
            Graphics g = Graphics.FromImage(image);
            Image secoursImg = new Bitmap("Ressources/secours.png");
            lock (lockObject)
            {
                foreach (PointF point in secoursPoints)
                {
                    g.DrawImage(secoursImg, new Rectangle(Point.Round(point), new Size(30, 30)));
                }
            }

            secoursImg.Dispose();
            g.Dispose();
        }
        /// <summary>
        /// Vide les listes de points
        /// </summary>
        internal void ViderListesDePoint()
        {
            secoursPoints.Clear();
            incendiePoints.Clear();
            observateurPoints.Clear();
            trajectoires.Clear();
        }
        /// <summary>
        /// Vide la liste view des clients (incendies/feux/secours)
        /// </summary>
        public void ViderClientListView()
        {
            try
            {
                Invoke((MethodInvoker)delegate ()
                {
                    lstClients.Items.Clear();
                    AjoutClients();
                });
            }
            catch { }

        }
        /// <summary>
        /// Met à jour l'affichage
        /// </summary>
        /// <param name="vitesse"></param>
        public void UpdateSim(double vitesse)
        {
            DessinerTemps();
            DessinerAeroports();
            DessinerIncendies();
            DessinerSecours();
            DessinerObservateurs();
            DessinerTrajectoires();
            DessinerAvion();
            try
            {
                Invoke((MethodInvoker)delegate ()
                {
                    if (picMap.Image != null)
                    {
                        picMap.Image.Dispose();
                    }
                    picMap.Image = image;
                    image = new Bitmap((int)tailleImage.Width, (int)tailleImage.Height);
                });
            }
            catch { }
        }
        /// <summary>
        /// Dessine les lieux d'observation aux point dans la liste observateurPoints
        /// </summary>
        private void DessinerObservateurs()
        {
            Graphics g = Graphics.FromImage(image);
            Image observateurImg = new Bitmap("Ressources/observateurs.png");
            lock (lockObject)
            {
                foreach (PointF point in observateurPoints)
                {
                    g.DrawImage(observateurImg, new Rectangle(Point.Round(point), new Size(30, 30)));
                }
            }

            observateurImg.Dispose();
            g.Dispose();
        }
        /// <summary>
        /// Charge les noms des aéroports
        /// </summary>
        /// <param name="aeroportsNom">Liste des nom</param>
        internal void ChargerAeroportsNom(List<string> aeroportsNom)
        {
            foreach (string apString in aeroportsNom)
            {
                lstAeroports.Items.Add(apString);
            }
        }

        /// <summary>
        /// Ajoute les trajectoires à la liste des trajectoires
        /// </summary>
        /// <param name="p_trajectoires">Nouvelle liste de trajectoires</param>
        public void AjouterPointsTrajectoire(List<Tuple<PointF[], Color>> p_trajectoires)
        {

            foreach (Tuple<PointF[], Color> trajectoire in p_trajectoires)
            {
                this.trajectoires = p_trajectoires;
                AjouterPointAeronef(trajectoire.Item1[1]);
            }
        }
        /// <summary>
        /// Ajoute un point dans la liste aeroportPoints
        /// </summary>
        /// <param name="point"></param>
        public void AjouterPointAeroport(PointF point)
        {
            airportPoints.Add(point);
        }
        /// <summary>
        /// Ajoute un point de secours dans la liste secoursPoints
        /// </summary>
        /// <param name="point"></param>
        public void AjouterPointSecours(PointF point)
        {
            lock (lockObject)
            {
                secoursPoints.Add(point);
            }
        }
        /// <summary>
        /// Ajoute un point d'incendie dans la liste incendiePoints
        /// </summary>
        /// <param name="point"></param>
        public void AjouterPointIncendie(PointF point)
        {
            lock (lockObject)
            {
                incendiePoints.Add(point);
            }
        }
        /// <summary>
        /// Ajoute un point d'observbation dans la liste observateurPoints
        /// </summary>
        /// <param name="point"></param>
        public void AjouterPointObservateur(PointF point)
        {
            lock (lockObject)
            {
                observateurPoints.Add(point);
            }
        }
        /// <summary>
        /// Ajoute un point d'aeronef dans la liste AeronefPoints
        /// </summary>
        /// <param name="point"></param>
        public void AjouterPointAeronef(PointF point)
        {
            lock (lockObject)
            {
                AeronefPoints.Add(point);
            }
        }
        /// <summary>
        /// Retourne la taille de la carte
        /// </summary>
        /// <returns></returns>
        public SizeF GetImageSize()
        {
            return tailleImage;
        }
        /// <summary>
        /// Ouvre la fenêtre permettant d'importer un scénario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScenario_Click(object sender, EventArgs e)
        {
            emplacementScenarioDialog = new OpenFileDialog();
            emplacementScenarioDialog.ShowDialog();
            bool valide = controleur.TelechargerScenario(emplacementScenarioDialog.FileName);
            if (valide)
            {
                btnScenario.Dispose();
                lstAeroports.Visible = true;
                lstClientsAeroport.Visible = true;
                lstAvions.Visible = true;
                lstClients.Visible = true;
                lblVitesse.Visible = true;
                sliderVitesse.Visible = true;
                lblInfo.Visible = true;
            }
            else
                MessageBox.Show("Le fichier est invalide.", "Erreur chargement du fichier", MessageBoxButtons.OK);
        }
        /// <summary>
        /// Change la vitesse de l'horloge
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sliderVitesse_ValueChanged(object sender, EventArgs e)
        {
            double valeur = sliderVitesse.Value + 1;

            double vitesse = valeur < 0 ? 1 / -(valeur - 1) : valeur + 1;
            controleur.ModifierVitesseTemps(vitesse);
        }

        /// <summary>
        /// Récupère les informations sur les clients (feux/incendies/secours)
        /// </summary>
        private void AjoutClients()
        {
            List<string> clients = controleur.AvoirClient();
            foreach (string client in clients)
                lstClients.Items.Add(client);
        }
        /// <summary>
        /// Récupère les informations sur l'aéroport sélectionnée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstAeroports_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstAeroports.SelectedIndex;
            if (index < 0)
            {
                return;
            }
            lstClientsAeroport.Items.Clear();
            lstAvions.Items.Clear();
            lstClients.Items.Clear();

            List<string> clients = controleur.AvoirClientAeroport(index);
            foreach (string client in clients)
            {
                lstClientsAeroport.Items.Add(client);
            }
            List<string> aeronefs = controleur.AvoirAeronefAeroport(index);
            foreach (string aeronef in aeronefs)
            {
                lstAvions.Items.Add(aeronef);
            }
            AjoutClients();
        }
    }
}
