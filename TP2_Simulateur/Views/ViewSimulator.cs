﻿using System;
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
        private Bitmap image;
        private SizeF tailleImage;
        public ViewSimulator(SimulatorController controleur)
        {
            this.controleur = controleur;
            InitializeComponent();
            
        }

        internal void loadMap(Bitmap p_map)
        {

                picMap.BackgroundImage = p_map;
                tailleImage = picMap.BackgroundImage.Size;
                image = new Bitmap((int)tailleImage.Width, (int)tailleImage.Height);

        }

        private void picMap_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse = (MouseEventArgs)e;
            int x = mouse.X;
            int y = mouse.Y;
            // TODO: Traduire x,y en lat,long

        }
        private void drawAirports() {
                Graphics g = Graphics.FromImage(image);
                Pen pAirport = new Pen(Color.Red, 10);
                foreach (PointF point in airportPoints)
                {
                    g.DrawEllipse(pAirport, new Rectangle(Point.Round(point), new Size(2, 2))); // On est obligé de transformer le PointF en Point car on dessine un cercle et non une image. Quand on va avoir choisit une image pour les aéroports on va utiliser un PointF
                }

                pAirport.Dispose();
                g.Dispose();
            
        }
        private void drawTrajectories(Bitmap bmap)
        {
        
        }

        public void updateSim()
        {

                drawAirports();
                Invoke((MethodInvoker)delegate () {
                    picMap.Image = image;
                });
            

        }

        public void dessinerAeroport(PointF point)
        {
            airportPoints.Add(point);
        }


        public SizeF getImageSize() {
            return tailleImage; 
            
        }


        private void btnScenario_Click(object sender, EventArgs e)
        {
            emplacementScenarioDialog = new OpenFileDialog();
            emplacementScenarioDialog.ShowDialog();
            controleur.TelechargerScenario(emplacementScenarioDialog.FileName);
            btnScenario.Text = controleur.scenario.ListAeroport[0].Nom;
        }
    }
}
