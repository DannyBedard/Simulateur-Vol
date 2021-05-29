﻿using System;
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
        private Trajectoire trajetTest;
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
        private void DessinerAeroports() {
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

        private void DessinerIncendies()
        {
            Graphics g = Graphics.FromImage(image);
            Image feuImg = new Bitmap("Ressources/incendie.png");
            ImageAttributes wrapMode = new ImageAttributes();
            lock (lockObject) 
            {
                foreach (PointF point in incendiePoints)
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    g.DrawImage(feuImg, new Rectangle(Point.Round(point), new Size(30, 30)), 0, 0, feuImg.Width, feuImg.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            feuImg.Dispose();
            wrapMode.Dispose();
            g.Dispose();
        }
        private void DessinerSecours() 
        {
            Graphics g = Graphics.FromImage(image);
            Image secoursImg = new Bitmap("Ressources/secours.png");
            ImageAttributes wrapMode = new ImageAttributes();
            lock(lockObject)
            {
                foreach (PointF point in secoursPoints)
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    g.DrawImage(secoursImg, new Rectangle(Point.Round(point), new Size(30, 30)), 0, 0, secoursImg.Width, secoursImg.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            secoursImg.Dispose();
            wrapMode.Dispose();
            g.Dispose();
        }
        private void DrawTrajectories(Bitmap bmap)
        {
        
        }


        public void UpdateSim(double vitesse)
        {
            DessinerTemps();
            DessinerAeroports();
            DessinerIncendies();
            DessinerSecours();
            DessinerObservateurs();
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
            ImageAttributes wrapMode = new ImageAttributes();
            lock (lockObject)
            {
                foreach (PointF point in observateurPoints)
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    g.DrawImage(observateurImg, new Rectangle(Point.Round(point), new Size(30, 30)), 0, 0, observateurImg.Width, observateurImg.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            observateurImg.Dispose();
            wrapMode.Dispose();
            g.Dispose();
        }

        internal void ChargerAeroportsNom(List<string> aeroportsNom)
        {
            foreach (string apString in aeroportsNom)
            {
                lstAeroports.Items.Add(apString);
            }
        }

        //private void DessinerLigne(PointF depart, PointF actuel)
        //{
        //    Graphics g = Graphics.FromImage(image);
        //    Pen pLigne = new Pen(Color.Red, 5);

        //    g.DrawLine(pLigne, depart, actuel); ;
        //    g.Dispose();
        //    pLigne.Dispose();
        //}

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
