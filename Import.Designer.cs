
namespace Hector
{
    partial class Import_Form
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
            this.Button_Ajouter_CSV = new System.Windows.Forms.Button();
            this.Textbox_Fichier_CSV = new System.Windows.Forms.TextBox();
            this.Button_Import_Ecraser = new System.Windows.Forms.Button();
            this.Button_Import_Ajouter_Modifier = new System.Windows.Forms.Button();
            this.Progress_Bar_Import = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // Button_Ajouter_CSV
            // 
            this.Button_Ajouter_CSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(139)))), ((int)(((byte)(255)))));
            this.Button_Ajouter_CSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Button_Ajouter_CSV.FlatAppearance.BorderSize = 0;
            this.Button_Ajouter_CSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Ajouter_CSV.Font = new System.Drawing.Font("Bahnschrift Light SemiCondensed", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Ajouter_CSV.ForeColor = System.Drawing.Color.Black;
            this.Button_Ajouter_CSV.Location = new System.Drawing.Point(12, 12);
            this.Button_Ajouter_CSV.Name = "Button_Ajouter_CSV";
            this.Button_Ajouter_CSV.Size = new System.Drawing.Size(109, 24);
            this.Button_Ajouter_CSV.TabIndex = 0;
            this.Button_Ajouter_CSV.Text = "Ajouter (Fichier.csv)";
            this.Button_Ajouter_CSV.UseVisualStyleBackColor = false;
            this.Button_Ajouter_CSV.Click += new System.EventHandler(this.Button_Ajouter_CSV_Click);
            // 
            // Textbox_Fichier_CSV
            // 
            this.Textbox_Fichier_CSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.Textbox_Fichier_CSV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Textbox_Fichier_CSV.Enabled = false;
            this.Textbox_Fichier_CSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Textbox_Fichier_CSV.ForeColor = System.Drawing.Color.White;
            this.Textbox_Fichier_CSV.Location = new System.Drawing.Point(127, 15);
            this.Textbox_Fichier_CSV.Name = "Textbox_Fichier_CSV";
            this.Textbox_Fichier_CSV.Size = new System.Drawing.Size(279, 12);
            this.Textbox_Fichier_CSV.TabIndex = 1;
            // 
            // Button_Import_Ecraser
            // 
            this.Button_Import_Ecraser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(139)))), ((int)(((byte)(255)))));
            this.Button_Import_Ecraser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Button_Import_Ecraser.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(184)))), ((int)(((byte)(85)))));
            this.Button_Import_Ecraser.FlatAppearance.BorderSize = 0;
            this.Button_Import_Ecraser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Import_Ecraser.Font = new System.Drawing.Font("Bahnschrift Light SemiCondensed", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Import_Ecraser.ForeColor = System.Drawing.Color.Black;
            this.Button_Import_Ecraser.Location = new System.Drawing.Point(248, 70);
            this.Button_Import_Ecraser.Name = "Button_Import_Ecraser";
            this.Button_Import_Ecraser.Size = new System.Drawing.Size(158, 27);
            this.Button_Import_Ecraser.TabIndex = 2;
            this.Button_Import_Ecraser.Text = "Importer (remplacer)";
            this.Button_Import_Ecraser.UseVisualStyleBackColor = false;
            this.Button_Import_Ecraser.Click += new System.EventHandler(this.Button_Import_Ecraser_Click);
            // 
            // Button_Import_Ajouter_Modifier
            // 
            this.Button_Import_Ajouter_Modifier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(139)))), ((int)(((byte)(255)))));
            this.Button_Import_Ajouter_Modifier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Button_Import_Ajouter_Modifier.FlatAppearance.BorderSize = 0;
            this.Button_Import_Ajouter_Modifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Import_Ajouter_Modifier.Font = new System.Drawing.Font("Bahnschrift Light SemiCondensed", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Import_Ajouter_Modifier.ForeColor = System.Drawing.Color.Black;
            this.Button_Import_Ajouter_Modifier.Location = new System.Drawing.Point(84, 70);
            this.Button_Import_Ajouter_Modifier.Name = "Button_Import_Ajouter_Modifier";
            this.Button_Import_Ajouter_Modifier.Size = new System.Drawing.Size(158, 27);
            this.Button_Import_Ajouter_Modifier.TabIndex = 3;
            this.Button_Import_Ajouter_Modifier.Text = "Importer (ajout/modifications)";
            this.Button_Import_Ajouter_Modifier.UseVisualStyleBackColor = false;
            this.Button_Import_Ajouter_Modifier.Click += new System.EventHandler(this.Button_Import_Ajouter_Modifier_Click);
            // 
            // Progress_Bar_Import
            // 
            this.Progress_Bar_Import.BackColor = System.Drawing.Color.White;
            this.Progress_Bar_Import.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(185)))), ((int)(((byte)(84)))));
            this.Progress_Bar_Import.Location = new System.Drawing.Point(12, 42);
            this.Progress_Bar_Import.Name = "Progress_Bar_Import";
            this.Progress_Bar_Import.Size = new System.Drawing.Size(394, 22);
            this.Progress_Bar_Import.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.Progress_Bar_Import.TabIndex = 4;
            // 
            // Import_Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(418, 111);
            this.Controls.Add(this.Progress_Bar_Import);
            this.Controls.Add(this.Button_Import_Ajouter_Modifier);
            this.Controls.Add(this.Button_Import_Ecraser);
            this.Controls.Add(this.Textbox_Fichier_CSV);
            this.Controls.Add(this.Button_Ajouter_CSV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Import_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_Ajouter_CSV;
        private System.Windows.Forms.TextBox Textbox_Fichier_CSV;
        private System.Windows.Forms.Button Button_Import_Ecraser;
        private System.Windows.Forms.Button Button_Import_Ajouter_Modifier;
        private System.Windows.Forms.ProgressBar Progress_Bar_Import;
    }
}