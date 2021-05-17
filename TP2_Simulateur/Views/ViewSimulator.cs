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
        SimulatorController controleur;
        private Bitmap map;
        private List<PointF> airportPoints = new List<PointF>();
        private List<PointF> planePoints = new List<PointF>();
        private List<PointF[]> trajectoriesPoints = new List<PointF[]>();
        private Bitmap bmpFront;
        private Bitmap FrontImage { get { return bmpFront;  } set { picMap.Image = value; bmpFront = value; } }
        public ViewSimulator(SimulatorController controleur)
        {
            this.controleur = controleur;
            InitializeComponent();
        }

        internal void loadMap(Bitmap p_map)
        {
            map = p_map;
            picMap.BackgroundImage = map;
        }

        private void picMap_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse = (MouseEventArgs)e;
            int x = mouse.X;
            int y = mouse.Y;
            // TODO: Traduire x,y en lat,long

        }
        private void drawAirports(Bitmap bmap) {
            Graphics g = Graphics.FromImage(bmap);
            Pen pAirport = new Pen(Color.Red, 10);
            foreach (PointF pos in airportPoints)
            {
                g.DrawEllipse(pAirport, new Rectangle(Point.Round(pos), new Size(2, 2))); // On est obligé de transformer le PointF en Point car on dessine un cercle et non une image. Quand on va avoir choisit une image pour les aéroports on va utiliser un PointF
            }
            pAirport.Dispose();
            g.Dispose();
        }
        private void drawTrajectories(Bitmap bmap)
        {
        
        }

        internal void updateSim()
        {
            Image backImage = getBackImage();
            Bitmap bmap = new Bitmap(backImage.Width, backImage.Height);
            drawAirports(bmap);
            //drawPlanes();
            //drawTrajectories(bmap);
            //draw...
            if (FrontImage == null || bmap != FrontImage)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (FrontImage != null)
                    {
                        FrontImage.Dispose();
                    }
                    FrontImage = bmap;
                });
            }
        }

        internal void addTrajectory(PointF firstPoint, PointF secondPoint)
        {
            trajectoriesPoints.Add(new PointF[] { firstPoint, secondPoint });
        }

        public void addAirportToView(PointF position)
        {
            airportPoints.Add(position);
        }

        public SizeF getImageSize() {
            Image backImage = getBackImage();

            return backImage.Size;
            
        }
        private Image getBackImage() {
            return (Image)this.Invoke((Func<Image>)delegate
            {
                return (Image)picMap.BackgroundImage.Clone();
            });
        }

        private void btnScenario_Click(object sender, EventArgs e)
        {
            emplacementScenarioDialog = new OpenFileDialog();
            emplacementScenarioDialog.ShowDialog();
            controleur.TelechargerScenario(emplacementScenarioDialog.FileName);
        }
    }
}
