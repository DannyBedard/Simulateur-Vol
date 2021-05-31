using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP2Editeur
{
    public partial class VueMap : Form
    {
        Editeur controleur;
        public VueMap(Editeur controleur)
        {
            this.controleur = controleur;
            InitializeComponent();
            picMap.Image = new Bitmap("carte.jpg");
        }

        private void picMap_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse = (MouseEventArgs) e;
            controleur.AfficherPositionChoisit(mouse.X, mouse.Y);
            this.Close();
        }

        public SizeF avoirTailleCarte()
        {
            return picMap.Size;
        }
    }
}
