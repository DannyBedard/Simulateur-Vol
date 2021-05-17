using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace TP2Editeur
{
    public partial class VueEditeur : Form
    {
        private Scenario scenario = new Scenario();
        private Editeur controleur;
        public VueEditeur(Editeur editeur)
        {
            controleur = editeur;
            InitializeComponent();
        }
       
        private void btnAjouterAeroport_Click(object sender, EventArgs e)
        {
            if (txbAeroportNom.Text == "" || !int.TryParse(txbAeroportMinPassager.Text, out _) || !int.TryParse(txbAeroportMaxPassager.Text, out _) || !int.TryParse(txbAeroportMinMarchandise.Text, out _) || !int.TryParse(txbAeroportMaxMarchandises.Text, out _)) { 
                MessageBox.Show("Veuillez remplir correctement les champs");
            }
            else {
                string apName = txbAeroportNom.Text;
                string apPosition = txbAeroportPosition.Text;
                int minPassager = int.Parse(txbAeroportMinPassager.Text);
                int maxPassager = int.Parse(txbAeroportMaxPassager.Text);
                int minMarchandise = int.Parse(txbAeroportMinMarchandise.Text);
                int maxMarchandise = int.Parse(txbAeroportMaxMarchandises.Text);
                controleur.ajouterAeroport(apName, apPosition, minPassager, maxPassager, minMarchandise, maxMarchandise);
            }
        }
        public void mettreAJourListeAeroports(List<string> aeroports) {
            lstAeroports.Items.Clear();
            foreach (string aeroport in aeroports) {
                lstAeroports.Items.Add(aeroport);
            }
        }
        private void cmbAeronefType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = cmbAeronefType.Text;
            switch (type) 
            {
                case "Citerne":
                    lblAjout.Text = "Remplissage";
                    lblEnlever.Text = "Largage";
                    txbAeronefEmbarquement.Visible = true;
                    txbAeronefDebarquement.Visible = true;
                    break;
                case "Passagers" :
                case "Marchandises":
                    lblAjout.Text = "Embarquement";
                    lblEnlever.Text = "Débarquement";
                    txbAeronefEmbarquement.Visible = true;
                    txbAeronefDebarquement.Visible = true;
                    break;
                case "Hélicoptère de secours":
                case "Observation":
                    lblAjout.Text = "";
                    lblEnlever.Text = "";
                    txbAeronefEmbarquement.Visible = false;
                    txbAeronefDebarquement.Visible = false;
                    break;
            }
        }

        private void lstAeroports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAeroports.SelectedIndex == -1)
            {
                btnAjouterAeronef.Enabled = false;
                return;
            }
            btnAjouterAeronef.Enabled = true;
            mettreAJourListeAeronef(lstAeroports.SelectedIndex);
            // TODO: Permetre de modifier l'aéroport sélectionné.
        }
        private void mettreAJourListeAeronef(int indexAeroport) {
            lstAeronefs.Items.Clear();
            List<string> aeronefsString = controleur.avoirAeronefsDeAeroport(indexAeroport);
            foreach (string aeronef in aeronefsString)
            {
                lstAeronefs.Items.Add(aeronef);
            }
        }

        internal string choisirEmplacement()
        {
            emplacementScenarioDialog.ShowDialog();
            return emplacementScenarioDialog.FileName;
        }

        private void btnGenererScenario_Click(object sender, EventArgs e)
        {
            controleur.genererScenario();
        }

        private void btnAjouterAeronef_Click(object sender, EventArgs e)
        {
            if (txbAeronefNom.Text == "" || !int.TryParse(txbAeronefVitesse.Text,out _) || !int.TryParse(txbAeronefEntretient.Text, out _) || !int.TryParse(txbAeronefDebarquement.Text, out _) || !int.TryParse(txbAeronefEmbarquement.Text, out _) || !int.TryParse(txbCapacite.Text, out _))
                MessageBox.Show("Veuillez remplir correctement les champs");
            else {
                int apIndex = lstAeroports.SelectedIndex;
                string aeronefNom = txbAeronefNom.Text;
                string aeronefType = cmbAeronefType.Text;
                int tempsEmbarquement = int.Parse(txbAeronefEmbarquement.Text);
                int capacite = int.Parse(txbCapacite.Text);
                int tempsDebarquement = int.Parse(txbAeronefDebarquement.Text);
                int tempsEntretient = int.Parse(txbAeronefEntretient.Text);
                int vitesse = int.Parse(txbAeronefVitesse.Text);
                controleur.ajouterAeronef(apIndex, aeronefNom, aeronefType, capacite, vitesse, tempsEmbarquement, tempsDebarquement, tempsEntretient);
                mettreAJourListeAeronef(apIndex);
            }
        }

    }
}
