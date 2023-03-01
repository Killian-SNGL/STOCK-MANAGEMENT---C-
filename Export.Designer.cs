namespace Hector
{
    partial class Export_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Localisation_Export = new System.Windows.Forms.Button();
            this.Text_box_FichierCSV_Export = new System.Windows.Forms.TextBox();
            this.ProgressBar_Export = new System.Windows.Forms.ProgressBar();
            this.Exporter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Localisation_Export
            // 
            this.Localisation_Export.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(139)))), ((int)(((byte)(255)))));
            this.Localisation_Export.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Localisation_Export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Localisation_Export.Font = new System.Drawing.Font("Bahnschrift Light SemiCondensed", 8.25F);
            this.Localisation_Export.Location = new System.Drawing.Point(12, 12);
            this.Localisation_Export.Name = "Localisation_Export";
            this.Localisation_Export.Size = new System.Drawing.Size(109, 24);
            this.Localisation_Export.TabIndex = 0;
            this.Localisation_Export.Text = "Localisation";
            this.Localisation_Export.UseVisualStyleBackColor = false;
            this.Localisation_Export.Click += new System.EventHandler(this.Localisation_Export_Click);
            // 
            // Text_box_FichierCSV_Export
            // 
            this.Text_box_FichierCSV_Export.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.Text_box_FichierCSV_Export.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Text_box_FichierCSV_Export.Enabled = false;
            this.Text_box_FichierCSV_Export.ForeColor = System.Drawing.Color.White;
            this.Text_box_FichierCSV_Export.Location = new System.Drawing.Point(127, 15);
            this.Text_box_FichierCSV_Export.Name = "Text_box_FichierCSV_Export";
            this.Text_box_FichierCSV_Export.Size = new System.Drawing.Size(279, 13);
            this.Text_box_FichierCSV_Export.TabIndex = 1;
            // 
            // progressBar_Export
            // 
            this.ProgressBar_Export.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(185)))), ((int)(((byte)(84)))));
            this.ProgressBar_Export.Location = new System.Drawing.Point(12, 42);
            this.ProgressBar_Export.Name = "progressBar_Export";
            this.ProgressBar_Export.Size = new System.Drawing.Size(394, 22);
            this.ProgressBar_Export.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressBar_Export.TabIndex = 2;
            // 
            // Exporter
            // 
            this.Exporter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(139)))), ((int)(((byte)(255)))));
            this.Exporter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Exporter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exporter.Font = new System.Drawing.Font("Bahnschrift Light SemiCondensed", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exporter.Location = new System.Drawing.Point(256, 70);
            this.Exporter.Name = "Exporter";
            this.Exporter.Size = new System.Drawing.Size(150, 27);
            this.Exporter.TabIndex = 3;
            this.Exporter.Text = "Exporter";
            this.Exporter.UseVisualStyleBackColor = false;
            this.Exporter.Click += new System.EventHandler(this.Exporter_Click);
            // 
            // Export_Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(418, 111);
            this.Controls.Add(this.Exporter);
            this.Controls.Add(this.ProgressBar_Export);
            this.Controls.Add(this.Text_box_FichierCSV_Export);
            this.Controls.Add(this.Localisation_Export);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Export_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Localisation_Export;
        private System.Windows.Forms.TextBox Text_box_FichierCSV_Export;
        private System.Windows.Forms.ProgressBar ProgressBar_Export;
        private System.Windows.Forms.Button Exporter;
    }
}
