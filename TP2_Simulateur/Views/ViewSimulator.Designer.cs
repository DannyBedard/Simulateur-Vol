
using System.Windows.Forms;

namespace TP2_Simulateur
{
    partial class ViewSimulator
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
            this.picMap = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnScenario = new System.Windows.Forms.Button();
            this.sliderVitesse = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.lstAeroports = new System.Windows.Forms.ListBox();
            this.lstClients = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderVitesse)).BeginInit();
            this.SuspendLayout();
            // 
            // picMap
            // 
            this.picMap.BackColor = System.Drawing.Color.Transparent;
            this.picMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picMap.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.picMap.Location = new System.Drawing.Point(0, 143);
            this.picMap.Name = "picMap";
            this.picMap.Size = new System.Drawing.Size(1075, 685);
            this.picMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMap.TabIndex = 0;
            this.picMap.TabStop = false;
            this.picMap.Click += new System.EventHandler(this.picMap_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1075, 0);
            this.panel1.TabIndex = 1;
            // 
            // btnScenario
            // 
            this.btnScenario.Location = new System.Drawing.Point(12, 12);
            this.btnScenario.Name = "btnScenario";
            this.btnScenario.Size = new System.Drawing.Size(229, 40);
            this.btnScenario.TabIndex = 2;
            this.btnScenario.Text = "Télécharger un scénario";
            this.btnScenario.UseVisualStyleBackColor = true;
            this.btnScenario.Click += new System.EventHandler(this.btnScenario_Click);
            // 
            // sliderVitesse
            // 
            this.sliderVitesse.LargeChange = 1;
            this.sliderVitesse.Location = new System.Drawing.Point(881, 58);
            this.sliderVitesse.Maximum = 3;
            this.sliderVitesse.Minimum = -3;
            this.sliderVitesse.Name = "sliderVitesse";
            this.sliderVitesse.Size = new System.Drawing.Size(195, 45);
            this.sliderVitesse.TabIndex = 3;
            this.sliderVitesse.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.sliderVitesse.ValueChanged += new System.EventHandler(this.sliderVitesse_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(805, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Vitesse : ";
            // 
            // lstAeroports
            // 
            this.lstAeroports.FormattingEnabled = true;
            this.lstAeroports.ItemHeight = 15;
            this.lstAeroports.Location = new System.Drawing.Point(12, 26);
            this.lstAeroports.Name = "lstAeroports";
            this.lstAeroports.Size = new System.Drawing.Size(264, 94);
            this.lstAeroports.TabIndex = 5;
            this.lstAeroports.Visible = false;
            this.lstAeroports.SelectedIndexChanged += new System.EventHandler(this.lstAeroports_SelectedIndexChanged);
            // 
            // lstClients
            // 
            this.lstClients.FormattingEnabled = true;
            this.lstClients.ItemHeight = 15;
            this.lstClients.Location = new System.Drawing.Point(343, 26);
            this.lstClients.Name = "lstClients";
            this.lstClients.Size = new System.Drawing.Size(263, 94);
            this.lstClients.TabIndex = 6;
            this.lstClients.Visible = false;
            // 
            // ViewSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 828);
            this.Controls.Add(this.lstClients);
            this.Controls.Add(this.lstAeroports);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sliderVitesse);
            this.Controls.Add(this.btnScenario);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picMap);
            this.Name = "ViewSimulator";
            this.Text = "Simulateur";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewSimulator_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderVitesse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picMap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnScenario;
        private System.Windows.Forms.OpenFileDialog emplacementScenarioDialog;
        private TrackBar sliderVitesse;
        private Label label2;
        private ListBox lstAeroports;
        private ListBox lstClients;
    }
}

