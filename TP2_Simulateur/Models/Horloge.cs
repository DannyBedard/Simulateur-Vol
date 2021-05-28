using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace TP2_Simulateur.Models
{
    public class Horloge
    {
        public delegate void TempsModifierEventHandler(string temps);
        public event TempsModifierEventHandler TempsModifier;
        public delegate void ChangementHeureEventHandler();
        public event ChangementHeureEventHandler ChangementHeure;

        private Timer timer = new Timer();
        private int seconde = 0;
        private int minute = 0;
        private int heure = 0;
        private int tickSeconde = 15;
        private int Seconde 
        {
            get
            {
                return seconde;
            }
            set
            {
                if (value == 60)
                {
                    seconde = 0;
                    Minute += 1;
                }
                else
                    seconde = value;
            }
        }
        private int Minute 
        {
            get
            {
                return minute;
            }
            set
            {
                if (value == 60)
                {
                    minute = 0;
                    Heure += 1;
                }
                else
                    minute = value;
            }
        }
        private int Heure 
        {
            get { return heure; }
            set
            {
                heure = value;
                ChangementHeure.Invoke();
            }
        }
        private double vitesse = 1.0;
        public double Vitesse 
        {
            get 
            {
                return vitesse;
            }
            set
            {
                vitesse = value;
                timer.Interval = 1000 / vitesse;
            }
        }
        public Horloge() {
            timer.Interval = 1000;
            timer.Elapsed += MettreAJourTemps;
        }
        private string TempsString() 
        {
            return Heure.ToString("00") + ":" + Minute.ToString("00") + ":" + Seconde.ToString("00");
        }
        private void MettreAJourTemps(object sender, ElapsedEventArgs e)
        {
            Seconde += tickSeconde;
            TempsModifier.Invoke(TempsString());
        }
        public void Start() 
        {
            timer.Start();
        }
        public void Stop() {
        
        }
    }
}
