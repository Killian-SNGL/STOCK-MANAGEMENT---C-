
namespace Hector
{
    partial class Update_Marque_Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextboxRefMarque = new System.Windows.Forms.TextBox();
            this.TextboxNomMarque = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Bouton2 = new System.Windows.Forms.Button();
            this.Bouton3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
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
            this.label2.Location = new System.Drawing.Point(9, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nom :";
            // 
            // TextboxRefMarque
            // 
            this.TextboxRefMarque.Enabled = false;
            this.TextboxRefMarque.Location = new System.Drawing.Point(136, 9);
            this.TextboxRefMarque.Name = "TextboxRefMarque";
            this.TextboxRefMarque.Size = new System.Drawing.Size(371, 20);
            this.TextboxRefMarque.TabIndex = 2;
            // 
            // TextboxNomMarque
            // 
            this.TextboxNomMarque.Location = new System.Drawing.Point(136, 36);
            this.TextboxNomMarque.Name = "TextboxNomMarque";
            this.TextboxNomMarque.Size = new System.Drawing.Size(371, 20);
            this.TextboxNomMarque.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(432, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Annuler";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Bouton2
            // 
            this.Bouton2.Location = new System.Drawing.Point(351, 61);
            this.Bouton2.Name = "Bouton2";
            this.Bouton2.Size = new System.Drawing.Size(75, 23);
            this.Bouton2.TabIndex = 5;
            this.Bouton2.Text = "Modifier/Ajout";
            this.Bouton2.UseVisualStyleBackColor = true;
            this.Bouton2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Bouton3
            // 
            this.Bouton3.Location = new System.Drawing.Point(270, 60);
            this.Bouton3.Name = "Bouton3";
            this.Bouton3.Size = new System.Drawing.Size(75, 23);
            this.Bouton3.TabIndex = 6;
            this.Bouton3.Text = "Supprimer";
            this.Bouton3.UseVisualStyleBackColor = true;
            this.Bouton3.Click += new System.EventHandler(this.Bouton3_Click);
            // 
            // Update_Marque_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(515, 93);
            this.Controls.Add(this.Bouton3);
            this.Controls.Add(this.Bouton2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TextboxNomMarque);
            this.Controls.Add(this.TextboxRefMarque);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Update_Marque_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UpdateMarque";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextboxRefMarque;
        private System.Windows.Forms.TextBox TextboxNomMarque;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Bouton2;
        private System.Windows.Forms.Button Bouton3;
    }
}