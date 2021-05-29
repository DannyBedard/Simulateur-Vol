using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        SimulatorController controleur;
        
        private List<PointF> airportPoints = new List<PointF>();
        private List<PointF> planePoints = new List<PointF>();
        private List<PointF[]> trajectoriesPoints = new List<PointF[]>();
        private List<PointF> secoursPoints = new List<PointF>();
        private List<PointF> incendiePoints = new List<PointF>();
        private List<PointF> observateurPoints = new List<PointF>();
        private string temps = "00:00:00";
        private Bitmap image;
        private SizeF tailleImage;
        public ViewSimulator(SimulatorController controleur)
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
        private void DrawAirports() {
            Graphics g = Graphics.FromImage(image);
            Pen pAirport = new Pen(Color.Red, 10);
            foreach (PointF point in airportPoints)
            {
                g.DrawEllipse(pAirport, new Rectangle(Point.Round(point), new Size(2, 2))); // On est obligé de transformer le PointF en Point car on dessine un cercle et non une image. Quand on va avoir choisit une image pour les aéroports on va utiliser un PointF
            }

            pAirport.Dispose();
            g.Dispose();
        }
        private void DessinerTemps()
        {
            RectangleF rectf = new RectangleF(image.Width - 600, image.Height - 100, 535, 90); //rectf for My Text
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
        private void DrawTrajectories(Bitmap bmap)
        {
        
        }

        public void UpdateSim()
        {
            DrawAirports();
            DrawClient();
            DessinerTemps();
            try
            {
                Invoke((MethodInvoker)delegate ()
                {
                    picMap.Image = image;
                    image = new Bitmap((int)tailleImage.Width, (int)tailleImage.Height);
                });
            }
            catch { }
        }

        internal void ChargerAeroports(List<string> aeroportsInfo)
        {
            foreach (string apString in aeroportsInfo)
            {
                lstAeroports.Items.Add(apString);
            }
        }

        public void AjouterPointAeroport(PointF point)
        {
            airportPoints.Add(point);
        }
        public void AjouterPointSecours(PointF point)
        {
            secoursPoints.Add(point);
        }
        public void AjouterPointIncendie(PointF point)
        {
            incendiePoints.Add(point);
        }
        public void AjouterPointObservateur(PointF point)
        {
            observateurPoints.Add(point);
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
    }
}
