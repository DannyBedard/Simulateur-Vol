
namespace TP2Editeur
{
    partial class VueEditeur
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txbAeroportPosition = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAjouterAeroport = new System.Windows.Forms.Button();
            this.lstAeroports = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbAeroportNom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbAeroportMinPassager = new System.Windows.Forms.TextBox();
            this.txbAeroportMaxPassager = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbAeroportMinMarchandise = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbAeroportMaxMarchandises = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lstAeronefs = new System.Windows.Forms.ListBox();
            this.txbAeronefNom = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbAeronefType = new System.Windows.Forms.ComboBox();
            this.txbAeronefVitesse = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txbAeronefEmbarquement = new System.Windows.Forms.TextBox();
            this.lblAjout = new System.Windows.Forms.Label();
            this.txbAeronefDebarquement = new System.Windows.Forms.TextBox();
            this.lblEnlever = new System.Windows.Forms.Label();
            this.txbAeronefEntretient = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnAjouterAeronef = new System.Windows.Forms.Button();
            this.txbCapacite = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnGenererScenario = new System.Windows.Forms.Button();
            this.emplacementScenarioDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // txbAeroportPosition
            // 
            this.txbAeroportPosition.Location = new System.Drawing.Point(234, 214);
            this.txbAeroportPosition.Name = "txbAeroportPosition";
            this.txbAeroportPosition.Size = new System.Drawing.Size(100, 23);
            this.txbAeroportPosition.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Position :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 2;
            // 
            // btnAjouterAeroport
            // 
            this.btnAjouterAeroport.Location = new System.Drawing.Point(24, 252);
            this.btnAjouterAeroport.Name = "btnAjouterAeroport";
            this.btnAjouterAeroport.Size = new System.Drawing.Size(1013, 24);
            this.btnAjouterAeroport.TabIndex = 3;
            this.btnAjouterAeroport.Text = "Ajouter un aéroport";
            this.btnAjouterAeroport.UseVisualStyleBackColor = true;
            this.btnAjouterAeroport.Click += new System.EventHandler(this.btnAjouterAeroport_Click);
            // 
            // lstAeroports
            // 
            this.lstAeroports.FormattingEnabled = true;
            this.lstAeroports.ItemHeight = 15;
            this.lstAeroports.Location = new System.Drawing.Point(24, 29);
            this.lstAeroports.Name = "lstAeroports";
            this.lstAeroports.Size = new System.Drawing.Size(1013, 154);
            this.lstAeroports.TabIndex = 4;
            this.lstAeroports.SelectedIndexChanged += new System.EventHandler(this.lstAeroports_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nom :";
            // 
            // txbAeroportNom
            // 
            this.txbAeroportNom.Location = new System.Drawing.Point(69, 214);
            this.txbAeroportNom.Name = "txbAeroportNom";
            this.txbAeroportNom.Size = new System.Drawing.Size(100, 23);
            this.txbAeroportNom.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(340, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "MinPassagers:";
            // 
            // txbAeroportMinPassager
            // 
            this.txbAeroportMinPassager.Location = new System.Drawing.Point(428, 214);
            this.txbAeroportMinPassager.Name = "txbAeroportMinPassager";
            this.txbAeroportMinPassager.Size = new System.Drawing.Size(38, 23);
            this.txbAeroportMinPassager.TabIndex = 8;
            // 
            // txbAeroportMaxPassager
            // 
            this.txbAeroportMaxPassager.Location = new System.Drawing.Point(560, 213);
            this.txbAeroportMaxPassager.Name = "txbAeroportMaxPassager";
            this.txbAeroportMaxPassager.Size = new System.Drawing.Size(38, 23);
            this.txbAeroportMaxPassager.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(472, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "MaxPassagers:";
            // 
            // txbAeroportMinMarchandise
            // 
            this.txbAeroportMinMarchandise.Location = new System.Drawing.Point(714, 214);
            this.txbAeroportMinMarchandise.Name = "txbAeroportMinMarchandise";
            this.txbAeroportMinMarchandise.Size = new System.Drawing.Size(38, 23);
            this.txbAeroportMinMarchandise.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(604, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "MinMarchandises:";
            // 
            // txbAeroportMaxMarchandises
            // 
            this.txbAeroportMaxMarchandises.Location = new System.Drawing.Point(870, 215);
            this.txbAeroportMaxMarchandises.Name = "txbAeroportMaxMarchandises";
            this.txbAeroportMaxMarchandises.Size = new System.Drawing.Size(38, 23);
            this.txbAeroportMaxMarchandises.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(758, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "MaxMarchandises:";
            // 
            // lstAeronefs
            // 
            this.lstAeronefs.FormattingEnabled = true;
            this.lstAeronefs.ItemHeight = 15;
            this.lstAeronefs.Location = new System.Drawing.Point(24, 296);
            this.lstAeronefs.Name = "lstAeronefs";
            this.lstAeronefs.Size = new System.Drawing.Size(1015, 154);
            this.lstAeronefs.TabIndex = 15;
            // 
            // txbAeronefNom
            // 
            this.txbAeronefNom.Location = new System.Drawing.Point(69, 472);
            this.txbAeronefNom.Name = "txbAeronefNom";
            this.txbAeronefNom.Size = new System.Drawing.Size(100, 23);
            this.txbAeronefNom.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 475);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "Nom :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(175, 475);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 15);
            this.label9.TabIndex = 18;
            this.label9.Text = "Type :";
            // 
            // cmbAeronefType
            // 
            this.cmbAeronefType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAeronefType.Items.AddRange(new object[] {
            "Passagers",
            "Marchandises",
            "Observation",
            "Citerne",
            "Hélicoptère de secours"});
            this.cmbAeronefType.Location = new System.Drawing.Point(218, 472);
            this.cmbAeronefType.Name = "cmbAeronefType";
            this.cmbAeronefType.Size = new System.Drawing.Size(121, 23);
            this.cmbAeronefType.TabIndex = 19;
            this.cmbAeronefType.SelectedIndexChanged += new System.EventHandler(this.cmbAeronefType_SelectedIndexChanged);
            // 
            // txbAeronefVitesse
            // 
            this.txbAeronefVitesse.Enabled = false;
            this.txbAeronefVitesse.Location = new System.Drawing.Point(580, 472);
            this.txbAeronefVitesse.Name = "txbAeronefVitesse";
            this.txbAeronefVitesse.Size = new System.Drawing.Size(43, 23);
            this.txbAeronefVitesse.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(525, 475);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 15);
            this.label10.TabIndex = 20;
            this.label10.Text = "Vitesse :";
            // 
            // txbAeronefEmbarquement
            // 
            this.txbAeronefEmbarquement.Enabled = false;
            this.txbAeronefEmbarquement.Location = new System.Drawing.Point(994, 472);
            this.txbAeronefEmbarquement.Name = "txbAeronefEmbarquement";
            this.txbAeronefEmbarquement.Size = new System.Drawing.Size(43, 23);
            this.txbAeronefEmbarquement.TabIndex = 23;
            // 
            // lblAjout
            // 
            this.lblAjout.Location = new System.Drawing.Point(893, 475);
            this.lblAjout.Name = "lblAjout";
            this.lblAjout.Size = new System.Drawing.Size(95, 15);
            this.lblAjout.TabIndex = 22;
            this.lblAjout.Text = "Embarquement :";
            this.lblAjout.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txbAeronefDebarquement
            // 
            this.txbAeronefDebarquement.Enabled = false;
            this.txbAeronefDebarquement.Location = new System.Drawing.Point(846, 472);
            this.txbAeronefDebarquement.Name = "txbAeronefDebarquement";
            this.txbAeronefDebarquement.Size = new System.Drawing.Size(43, 23);
            this.txbAeronefDebarquement.TabIndex = 25;
            // 
            // lblEnlever
            // 
            this.lblEnlever.Location = new System.Drawing.Point(748, 475);
            this.lblEnlever.Name = "lblEnlever";
            this.lblEnlever.Size = new System.Drawing.Size(92, 15);
            this.lblEnlever.TabIndex = 24;
            this.lblEnlever.Text = "Débarquement :";
            this.lblEnlever.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txbAeronefEntretient
            // 
            this.txbAeronefEntretient.Enabled = false;
            this.txbAeronefEntretient.Location = new System.Drawing.Point(699, 472);
            this.txbAeronefEntretient.Name = "txbAeronefEntretient";
            this.txbAeronefEntretient.Size = new System.Drawing.Size(43, 23);
            this.txbAeronefEntretient.TabIndex = 27;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(629, 475);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 15);
            this.label13.TabIndex = 26;
            this.label13.Text = "Entretient :";
            // 
            // btnAjouterAeronef
            // 
            this.btnAjouterAeronef.Enabled = false;
            this.btnAjouterAeronef.Location = new System.Drawing.Point(24, 501);
            this.btnAjouterAeronef.Name = "btnAjouterAeronef";
            this.btnAjouterAeronef.Size = new System.Drawing.Size(1013, 24);
            this.btnAjouterAeronef.TabIndex = 28;
            this.btnAjouterAeronef.Text = "Ajouter un aeronef";
            this.btnAjouterAeronef.UseVisualStyleBackColor = true;
            this.btnAjouterAeronef.Click += new System.EventHandler(this.btnAjouterAeronef_Click);
            // 
            // txbCapacite
            // 
            this.txbCapacite.Enabled = false;
            this.txbCapacite.Location = new System.Drawing.Point(472, 472);
            this.txbCapacite.Name = "txbCapacite";
            this.txbCapacite.Size = new System.Drawing.Size(43, 23);
            this.txbCapacite.TabIndex = 30;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(407, 475);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 15);
            this.label14.TabIndex = 29;
            this.label14.Text = "Capacité :";
            // 
            // btnGenererScenario
            // 
            this.btnGenererScenario.Location = new System.Drawing.Point(24, 538);
            this.btnGenererScenario.Name = "btnGenererScenario";
            this.btnGenererScenario.Size = new System.Drawing.Size(1013, 48);
            this.btnGenererScenario.TabIndex = 31;
            this.btnGenererScenario.Text = "Générer le scénario";
            this.btnGenererScenario.UseVisualStyleBackColor = true;
            this.btnGenererScenario.Click += new System.EventHandler(this.btnGenererScenario_Click);
            // 
            // emplacementScenarioDialog
            // 
            this.emplacementScenarioDialog.Filter = "XML-File | *.xml";
            this.emplacementScenarioDialog.Title = "Générer le scénario";
            // 
            // VueEditeur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 598);
            this.Controls.Add(this.btnGenererScenario);
            this.Controls.Add(this.txbCapacite);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnAjouterAeronef);
            this.Controls.Add(this.txbAeronefEntretient);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txbAeronefDebarquement);
            this.Controls.Add(this.lblEnlever);
            this.Controls.Add(this.txbAeronefEmbarquement);
            this.Controls.Add(this.lblAjout);
            this.Controls.Add(this.txbAeronefVitesse);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbAeronefType);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txbAeronefNom);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lstAeronefs);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txbAeroportMaxMarchandises);
            this.Controls.Add(this.txbAeroportMinMarchandise);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txbAeroportMaxPassager);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txbAeroportMinPassager);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbAeroportNom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstAeroports);
            this.Controls.Add(this.btnAjouterAeroport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbAeroportPosition);
            this.Name = "VueEditeur";
            this.Text = "Editeur de scénario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbAeroportPosition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAjouterAeroport;
        private System.Windows.Forms.ListBox lstAeroports;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbAeroportNom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbAeroportMinPassager;
        private System.Windows.Forms.TextBox txbAeroportMaxPassager;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbAeroportMinMarchandise;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbAeroportMaxMarchandises;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lstAeronefs;
        private System.Windows.Forms.TextBox txbAeronefNom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbAeronefType;
        private System.Windows.Forms.TextBox txbAeronefVitesse;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txbAeronefEmbarquement;
        private System.Windows.Forms.Label lblAjout;
        private System.Windows.Forms.TextBox txbAeronefDebarquement;
        private System.Windows.Forms.Label lblEnlever;
        private System.Windows.Forms.TextBox txbAeronefEntretient;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnAjouterAeronef;
        private System.Windows.Forms.TextBox txbCapacite;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnGenererScenario;
        private System.Windows.Forms.SaveFileDialog emplacementScenarioDialog;
    }
}

