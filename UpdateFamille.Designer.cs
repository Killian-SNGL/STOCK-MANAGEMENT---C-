
namespace Hector
{
    partial class Update_Famille_Form
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
            this.label3 = new System.Windows.Forms.Label();
            this.TextboxNom = new System.Windows.Forms.TextBox();
            this.Bouton1 = new System.Windows.Forms.Button();
            this.Bouton3 = new System.Windows.Forms.Button();
            this.Bouton2 = new System.Windows.Forms.Button();
            this.TextboxRefFamille = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 18);
            this.label3.TabIndex = 19;
            this.label3.Text = "Nom :";
            // 
            // TextboxNom
            // 
            this.TextboxNom.Location = new System.Drawing.Point(139, 35);
            this.TextboxNom.Multiline = true;
            this.TextboxNom.Name = "TextboxNom";
            this.TextboxNom.Size = new System.Drawing.Size(371, 20);
            this.TextboxNom.TabIndex = 18;
            // 
            // Bouton1
            // 
            this.Bouton1.Location = new System.Drawing.Point(273, 61);
            this.Bouton1.Name = "Bouton1";
            this.Bouton1.Size = new System.Drawing.Size(75, 23);
            this.Bouton1.TabIndex = 17;
            this.Bouton1.Text = "Suppression";
            this.Bouton1.UseVisualStyleBackColor = true;
            this.Bouton1.Click += new System.EventHandler(this.Bouton1_Click);
            // 
            // Bouton3
            // 
            this.Bouton3.Location = new System.Drawing.Point(435, 61);
            this.Bouton3.Name = "Bouton3";
            this.Bouton3.Size = new System.Drawing.Size(75, 23);
            this.Bouton3.TabIndex = 16;
            this.Bouton3.Text = "Annuler";
            this.Bouton3.UseVisualStyleBackColor = true;
            this.Bouton3.Click += new System.EventHandler(this.Bouton3_Click);
            // 
            // Bouton2
            // 
            this.Bouton2.Location = new System.Drawing.Point(354, 61);
            this.Bouton2.Name = "Bouton2";
            this.Bouton2.Size = new System.Drawing.Size(75, 23);
            this.Bouton2.TabIndex = 15;
            this.Bouton2.Text = "Modifier/Ajouter";
            this.Bouton2.UseVisualStyleBackColor = true;
            this.Bouton2.Click += new System.EventHandler(this.Bouton2_Click);
            // 
            // TextboxRefFamille
            // 
            this.TextboxRefFamille.Location = new System.Drawing.Point(139, 9);
            this.TextboxRefFamille.Name = "TextboxRefFamille";
            this.TextboxRefFamille.Size = new System.Drawing.Size(371, 20);
            this.TextboxRefFamille.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "Ref :";
            // 
            // Update_Famille_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(519, 93);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextboxNom);
            this.Controls.Add(this.Bouton1);
            this.Controls.Add(this.Bouton3);
            this.Controls.Add(this.Bouton2);
            this.Controls.Add(this.TextboxRefFamille);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Update_Famille_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UpdateFamille";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextboxNom;
        private System.Windows.Forms.Button Bouton1;
        private System.Windows.Forms.Button Bouton3;
        private System.Windows.Forms.Button Bouton2;
        private System.Windows.Forms.TextBox TextboxRefFamille;
        private System.Windows.Forms.Label label2;
    }
}