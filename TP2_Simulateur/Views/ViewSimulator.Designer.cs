
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
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).BeginInit();
            this.SuspendLayout();
            // 
            // picMap
            // 
            this.picMap.BackColor = System.Drawing.Color.Transparent;
            this.picMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picMap.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.picMap.Location = new System.Drawing.Point(0, 162);
            this.picMap.Name = "picMap";
            this.picMap.Size = new System.Drawing.Size(1088, 666);
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
            this.panel1.Size = new System.Drawing.Size(1088, 0);
            this.panel1.TabIndex = 1;
            // 
            // btnScenario
            // 
            this.btnScenario.Location = new System.Drawing.Point(24, 13);
            this.btnScenario.Name = "btnScenario";
            this.btnScenario.Size = new System.Drawing.Size(229, 23);
            this.btnScenario.TabIndex = 2;
            this.btnScenario.Text = "Télécharger un scénario";
            this.btnScenario.UseVisualStyleBackColor = true;
            this.btnScenario.Click += new System.EventHandler(this.btnScenario_Click);
            // 
            // ViewSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 828);
            this.Controls.Add(this.btnScenario);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picMap);
            this.Name = "ViewSimulator";
            this.Text = "Simulateur";
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picMap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnScenario;
        private System.Windows.Forms.OpenFileDialog emplacementScenarioDialog;
    }
}

