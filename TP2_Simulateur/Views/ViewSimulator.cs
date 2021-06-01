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
        
        private List<PointF> airportPoints = new List<PointF>();
        private List<PointF> AeronefPoints = new List<PointF>();
        private List<Tuple<PointF[], Color>> trajectoires = new List<Tuple<PointF[], Color>>();
        private List<PointF> secoursPoints = new List<PointF>();
        private List<PointF> incendiePoints = new List<PointF>();
        private List<PointF> observateurPoints = new List<PointF>();
        private string temps = "00:00:00";
        private Bitmap image;
        private SizeF tailleImage;
        public ViewSimulator(COTAI controleur)
        {
            this.controleur = controleur;
            InitializeComponent();
        }

        internal void LoadMap(Bitmap p_map)
        {

            picMap.BackgroundImage = p_map;
            tailleImage = picMap.BackgroundImage.Size;
            image = new Bitmap((int)tailleImage.Width, (int)tailleImage.Height);
        }
        public void AfficherTemps(string p_temps) {
            temps = p_temps;
        }
        private void picMap_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse = (MouseEventArgs)e;
            int x = mouse.X;
            int y = mouse.Y;
            // TODO: Traduire x,y en lat,long
        }
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

        private void DessinerAeroports() {
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
        private void DessinerSecours() 
        {
            Graphics g = Graphics.FromImage(image);
            Image secoursImg = new Bitmap("Ressources/secours.png");
            lock(lockObject)
            {
                foreach (PointF point in secoursPoints)
                {
                    g.DrawImage(secoursImg, new Rectangle(Point.Round(point), new Size(30, 30)));
                }
            }

            secoursImg.Dispose();
            g.Dispose();
        }

        internal void ViderListesDePoint()
        {
            secoursPoints.Clear();
            incendiePoints.Clear();
            observateurPoints.Clear();
            trajectoires.Clear();
        }

        private void DrawTrajectories(Bitmap bmap)
        {
        
        }

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

        internal void ChargerAeroportsNom(List<string> aeroportsNom)
        {
            foreach (string apString in aeroportsNom)
            {
                lstAeroports.Items.Add(apString);
            }
        }
        public void AjouterPointsTrajectoire(List<Tuple<PointF[], Color>> p_trajectoires) 
        {
            
            foreach (Tuple<PointF[], Color> trajectoire in p_trajectoires)
            {
                this.trajectoires = p_trajectoires;
                AjouterPointAeronef(trajectoire.Item1[1]);
            }
        }  
        public void AjouterPointAeroport(PointF point)
        {
            airportPoints.Add(point);
        }
        public void AjouterPointSecours(PointF point)
        {
            lock (lockObject) 
            {
                secoursPoints.Add(point);
            }
        }
        public void AjouterPointIncendie(PointF point)
        {
            lock (lockObject) 
            {
                incendiePoints.Add(point);
            }
        }
        public void AjouterPointObservateur(PointF point)
        {
            lock (lockObject) 
            {
                observateurPoints.Add(point);
            }
        }

        public void AjouterPointAeronef(PointF point)
        {
            lock (lockObject)
            {
                AeronefPoints.Add(point);
            }
        }

        public SizeF GetImageSize() {
            return tailleImage; 
        }

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

        private void sliderVitesse_ValueChanged(object sender, EventArgs e)
        {
            double valeur = sliderVitesse.Value + 1;

            double vitesse = valeur < 0 ? 1 / -(valeur-1) : valeur + 1;
            controleur.ModifierVitesseTemps(vitesse);
        }

        private void ViewSimulator_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        public void DrawClient()
        {
            Graphics g = Graphics.FromImage(image);
            Pen crayon = new Pen(Color.Purple, 20);
            foreach (PointF point in secoursPoints)
            {
                g.DrawEllipse(crayon, new Rectangle(Point.Round(point), new Size(2, 2))); 
            }

            crayon.Dispose();
            g.Dispose();
        }

        private void AjoutClients()
        { 
            List<string> clients = controleur.AvoirClient();
            foreach (string client in clients)
                lstClients.Items.Add(client);
        }

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
