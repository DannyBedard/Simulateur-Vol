using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
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


        public ViewSimulator view = new ViewSimulator();
        private List<Airport> airports = new List<Airport>();
        private Thread timerThread;
        private Stopwatch timer = new Stopwatch();
        private bool running = false;
        public void showMainMenu() {
            Bitmap map = new Bitmap("Ressources/world-map.bmp");
            init(); // Ajoute des aéroports
            view.loadMap(map); // Charge la map sur la vue

            start = (s, e) => {
                // On envoit la liste des points des aéroports quand la fenêtre s'ouvre
                foreach (Airport ap in airports)
                {
                    PointF position = ap.Position.Transposer(view.getImageSize());
                    view.addAirportToView(position);
                }
                timerThread = new Thread(new ThreadStart(updateSimView));
                timerThread.Start();
                Application.Idle -= start;
            };
            Application.Idle += start;
            Application.Run(view);
        }
        private EventHandler start;
        
        private void updateSimView() {
            timer.Start();
            long now = timer.ElapsedMilliseconds;
            long lastFrame = timer.ElapsedMilliseconds;
            
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
            Airport yul = new Airport("YUL", "45° 27' N, 73° 44' W"); // Aéroport Pierre-Elliot-Trudeau (Montréal)
            Airport bod = new Airport("BOD", "44° 49' N, 0° 42' W"); // Aéroport de Bordeaux (France)

            airports.Add(yul);
            airports.Add(bod);
            running = true;
        }

    }


}
