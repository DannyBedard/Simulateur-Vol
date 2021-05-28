using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using TP2_Simulateur.Models;

namespace TP2_Simulateur
{
    public class SimulatorController
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SimulatorController controller = new SimulatorController();
            controller.showMainMenu();
        }

        public XmlSerializer xs;
        public ViewSimulator view;
        public Scenario scenario;
        private List<Aeroport> airports = new List<Aeroport>();
        private Thread timerThread;
        private Stopwatch timer = new Stopwatch();
        private bool running = false;
        public void showMainMenu() {
            view = new ViewSimulator(this);
            Bitmap map = new Bitmap("Ressources/carte.jpg");
            view.loadMap(map); // Charge la map sur la vue
            view.Show();
            Application.Run(view);
        }
        private EventHandler start;
        
        private void updateSimView() {
            timer.Start();
            long now = timer.ElapsedMilliseconds;
            long lastFrame = timer.ElapsedMilliseconds;
            foreach (PointF point in scenario.avoirPointsAeroport())
            {
                view.dessinerAeroport(point);
            }
            while (running) 
            {
                now = timer.ElapsedMilliseconds;
                long delta = now - lastFrame;
                lastFrame = now;
                // 33 = 30 FPS 
                if (delta < 33)
                {
                    Thread.Sleep((int)(33 - delta));
                }
                view.updateSim();
            }
        }
        private void init() {
            scenario.TailleImage = view.getImageSize();
            
            running = true;
            timerThread = new Thread(new ThreadStart(updateSimView));
            timerThread.Start();

        }

        public void TelechargerScenario(string fichier)
        {
            xs = new XmlSerializer(typeof(Scenario));
            using (StreamReader rd = new StreamReader(fichier))
            {
                scenario = (Scenario)xs.Deserialize(rd);
                init();
            }

        }

    }


}
