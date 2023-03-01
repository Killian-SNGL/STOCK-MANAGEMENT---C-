
namespace Hector
{
    partial class Update_Sous_Famille_Form
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxRefSousFamille = new System.Windows.Forms.TextBox();
            this.TextBoxNomSousFamille = new System.Windows.Forms.TextBox();
            this.Bouton1 = new System.Windows.Forms.Button();
            this.Bouton2 = new System.Windows.Forms.Button();
            this.Bouton3 = new System.Windows.Forms.Button();
            this.TextBoxFamille = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.familleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.familleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ref :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Famille :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nom :";
            // 
            // TextBoxRefSousFamille
            // 
            this.TextBoxRefSousFamille.Enabled = false;
            this.TextBoxRefSousFamille.Location = new System.Drawing.Point(132, 11);
            this.TextBoxRefSousFamille.Name = "TextBoxRefSousFamille";
            this.TextBoxRefSousFamille.Size = new System.Drawing.Size(371, 20);
            this.TextBoxRefSousFamille.TabIndex = 3;
            // 
            // TextBoxNomSousFamille
            // 
            this.TextBoxNomSousFamille.Location = new System.Drawing.Point(132, 78);
            this.TextBoxNomSousFamille.Name = "TextBoxNomSousFamille";
            this.TextBoxNomSousFamille.Size = new System.Drawing.Size(371, 20);
            this.TextBoxNomSousFamille.TabIndex = 4;
            // 
            // Bouton1
            // 
            this.Bouton1.Location = new System.Drawing.Point(428, 104);
            this.Bouton1.Name = "Bouton1";
            this.Bouton1.Size = new System.Drawing.Size(75, 23);
            this.Bouton1.TabIndex = 6;
            this.Bouton1.Text = "Annuler";
            this.Bouton1.UseVisualStyleBackColor = true;
            // 
            // Bouton2
            // 
            this.Bouton2.Location = new System.Drawing.Point(347, 104);
            this.Bouton2.Name = "Bouton2";
            this.Bouton2.Size = new System.Drawing.Size(75, 23);
            this.Bouton2.TabIndex = 7;
            this.Bouton2.Text = "Modifier/Ajouter";
            this.Bouton2.UseVisualStyleBackColor = true;
            // 
            // Bouton3
            // 
            this.Bouton3.Location = new System.Drawing.Point(266, 104);
            this.Bouton3.Name = "Bouton3";
            this.Bouton3.Size = new System.Drawing.Size(75, 23);
            this.Bouton3.TabIndex = 8;
            this.Bouton3.Text = "Supprimer";
            this.Bouton3.UseVisualStyleBackColor = true;
            // 
            // TextBoxFamille
            // 
            this.TextBoxFamille.Enabled = false;
            this.TextBoxFamille.Location = new System.Drawing.Point(132, 42);
            this.TextBoxFamille.Name = "TextBoxFamille";
            this.TextBoxFamille.Size = new System.Drawing.Size(371, 20);
            this.TextBoxFamille.TabIndex = 9;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // familleBindingSource
            // 
            this.familleBindingSource.DataSource = typeof(Hector.Modeles.Famille);
            // 
            // Update_Sous_Famille_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(515, 135);
            this.Controls.Add(this.TextBoxFamille);
            this.Controls.Add(this.Bouton3);
            this.Controls.Add(this.Bouton2);
            this.Controls.Add(this.Bouton1);
            this.Controls.Add(this.TextBoxNomSousFamille);
            this.Controls.Add(this.TextBoxRefSousFamille);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Update_Sous_Famille_Form";
            this.Text = "UpdateSousFamille";
            ((System.ComponentModel.ISupportInitialize)(this.familleBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBoxRefSousFamille;
        private System.Windows.Forms.TextBox TextBoxNomSousFamille;
        private System.Windows.Forms.BindingSource familleBindingSource;
        private System.Windows.Forms.Button Bouton1;
        private System.Windows.Forms.Button Bouton2;
        private System.Windows.Forms.Button Bouton3;
        private System.Windows.Forms.TextBox TextBoxFamille;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}