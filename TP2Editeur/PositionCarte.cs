using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP2Editeur
{
    public partial class PositionCarte : Form
    {
        VueEditeur controleur;
        public PositionCarte(VueEditeur controleur)
        {
            this.controleur = controleur;
            InitializeComponent();
        }

        private void PositionCarte_MouseClick(object sender, MouseEventArgs e)
        {
            controleur.PositionCartographique(e.X, e.Y);
            this.Close();
        }
    }
}
