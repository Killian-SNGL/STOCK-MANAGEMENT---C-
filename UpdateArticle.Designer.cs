namespace Hector
{
    partial class Update_Article_Form
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
            this.SelecteurMarque = new System.Windows.Forms.ComboBox();
            this.marqueBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.marqueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.marqueBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.donneesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.donneesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label_marque = new System.Windows.Forms.Label();
            this.marqueDAOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.marqueBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SelecteurFamille = new System.Windows.Forms.ComboBox();
            this.familleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label_ssFamille = new System.Windows.Forms.Label();
            this.SelecteurSFamille = new System.Windows.Forms.ComboBox();
            this.sousFamilleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.TextboxRefArticle = new System.Windows.Forms.TextBox();
            this.Bouton2 = new System.Windows.Forms.Button();
            this.Bouton3 = new System.Windows.Forms.Button();
            this.Bouton1 = new System.Windows.Forms.Button();
            this.TextboxDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SelecteurPrix = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.SelecteurQuantite = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.marqueBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marqueBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marqueBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donneesBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donneesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marqueDAOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marqueBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.familleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sousFamilleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelecteurPrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelecteurQuantite)).BeginInit();
            this.SuspendLayout();
            // 
            // SelecteurMarque
            // 
            this.SelecteurMarque.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SelecteurMarque.DataSource = this.marqueBindingSource3;
            this.SelecteurMarque.DisplayMember = "NomMarque";
            this.SelecteurMarque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelecteurMarque.FormattingEnabled = true;
            this.SelecteurMarque.Location = new System.Drawing.Point(140, 117);
            this.SelecteurMarque.Name = "SelecteurMarque";
            this.SelecteurMarque.Size = new System.Drawing.Size(371, 21);
            this.SelecteurMarque.TabIndex = 0;
            this.SelecteurMarque.ValueMember = "NomMarque";
            // 
            // marqueBindingSource3
            // 
            this.marqueBindingSource3.DataSource = typeof(Hector.Modeles.Marque);
            // 
            // donneesBindingSource1
            // 
            this.donneesBindingSource1.DataSource = typeof(Hector.Modeles.Donnees);
            // 
            // donneesBindingSource
            // 
            this.donneesBindingSource.DataSource = typeof(Hector.Modeles.Donnees);
            // 
            // label_marque
            // 
            this.label_marque.AutoSize = true;
            this.label_marque.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_marque.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_marque.Location = new System.Drawing.Point(9, 117);
            this.label_marque.Name = "label_marque";
            this.label_marque.Size = new System.Drawing.Size(66, 18);
            this.label_marque.TabIndex = 1;
            this.label_marque.Text = "Marque :";
            // 
            // marqueDAOBindingSource
            // 
            this.marqueDAOBindingSource.DataSource = typeof(Hector.DAO.MarqueDAO);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Famille :";
            // 
            // SelecteurFamille
            // 
            this.SelecteurFamille.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SelecteurFamille.DataSource = this.familleBindingSource;
            this.SelecteurFamille.DisplayMember = "Nom";
            this.SelecteurFamille.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelecteurFamille.FormattingEnabled = true;
            this.SelecteurFamille.Location = new System.Drawing.Point(140, 146);
            this.SelecteurFamille.Name = "SelecteurFamille";
            this.SelecteurFamille.Size = new System.Drawing.Size(371, 21);
            this.SelecteurFamille.TabIndex = 3;
            this.SelecteurFamille.SelectedIndexChanged += new System.EventHandler(this.SelecteurFamille_SelectedIndexChanged);
            // 
            // familleBindingSource
            // 
            this.familleBindingSource.DataSource = typeof(Hector.Modeles.Famille);
            // 
            // label_ssFamille
            // 
            this.label_ssFamille.AutoSize = true;
            this.label_ssFamille.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_ssFamille.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ssFamille.Location = new System.Drawing.Point(9, 176);
            this.label_ssFamille.Name = "label_ssFamille";
            this.label_ssFamille.Size = new System.Drawing.Size(98, 18);
            this.label_ssFamille.TabIndex = 4;
            this.label_ssFamille.Text = "Sous-famille :";
            // 
            // SelecteurSFamille
            // 
            this.SelecteurSFamille.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SelecteurSFamille.DataSource = this.sousFamilleBindingSource;
            this.SelecteurSFamille.DisplayMember = "Nom";
            this.SelecteurSFamille.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelecteurSFamille.FormattingEnabled = true;
            this.SelecteurSFamille.Location = new System.Drawing.Point(140, 176);
            this.SelecteurSFamille.Name = "SelecteurSFamille";
            this.SelecteurSFamille.Size = new System.Drawing.Size(371, 21);
            this.SelecteurSFamille.TabIndex = 5;
            this.SelecteurSFamille.ValueMember = "Nom";
            // 
            // sousFamilleBindingSource
            // 
            this.sousFamilleBindingSource.DataSource = typeof(Hector.Modeles.SousFamille);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ref :";
            // 
            // TextboxRefArticle
            // 
            this.TextboxRefArticle.Location = new System.Drawing.Point(140, 9);
            this.TextboxRefArticle.Name = "TextboxRefArticle";
            this.TextboxRefArticle.Size = new System.Drawing.Size(371, 20);
            this.TextboxRefArticle.TabIndex = 7;
            // 
            // Bouton2
            // 
            this.Bouton2.Location = new System.Drawing.Point(355, 217);
            this.Bouton2.Name = "Bouton2";
            this.Bouton2.Size = new System.Drawing.Size(75, 23);
            this.Bouton2.TabIndex = 8;
            this.Bouton2.Text = "Modifier";
            this.Bouton2.UseVisualStyleBackColor = true;
            this.Bouton2.Click += new System.EventHandler(this.Bouton2_Click);
            // 
            // Bouton3
            // 
            this.Bouton3.Location = new System.Drawing.Point(436, 217);
            this.Bouton3.Name = "Bouton3";
            this.Bouton3.Size = new System.Drawing.Size(75, 23);
            this.Bouton3.TabIndex = 9;
            this.Bouton3.Text = "Annuler";
            this.Bouton3.UseVisualStyleBackColor = true;
            this.Bouton3.Click += new System.EventHandler(this.Bouton3_Click);
            // 
            // Bouton1
            // 
            this.Bouton1.Location = new System.Drawing.Point(274, 217);
            this.Bouton1.Name = "Bouton1";
            this.Bouton1.Size = new System.Drawing.Size(75, 23);
            this.Bouton1.TabIndex = 10;
            this.Bouton1.Text = "Ajouter/Suppression";
            this.Bouton1.UseVisualStyleBackColor = true;
            this.Bouton1.Click += new System.EventHandler(this.Bouton1_Click);
            // 
            // TextboxDescription
            // 
            this.TextboxDescription.Location = new System.Drawing.Point(140, 35);
            this.TextboxDescription.Multiline = true;
            this.TextboxDescription.Name = "TextboxDescription";
            this.TextboxDescription.Size = new System.Drawing.Size(371, 20);
            this.TextboxDescription.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Description :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "Prix (€) :";
            // 
            // SelecteurPrix
            // 
            this.SelecteurPrix.DecimalPlaces = 2;
            this.SelecteurPrix.Location = new System.Drawing.Point(140, 62);
            this.SelecteurPrix.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.SelecteurPrix.Name = "SelecteurPrix";
            this.SelecteurPrix.Size = new System.Drawing.Size(370, 20);
            this.SelecteurPrix.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 18);
            this.label5.TabIndex = 15;
            this.label5.Text = "Quantité :";
            // 
            // SelecteurQuantite
            // 
            this.SelecteurQuantite.Location = new System.Drawing.Point(140, 89);
            this.SelecteurQuantite.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.SelecteurQuantite.Name = "SelecteurQuantite";
            this.SelecteurQuantite.Size = new System.Drawing.Size(370, 20);
            this.SelecteurQuantite.TabIndex = 16;
            // 
            // Update_Article_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(519, 251);
            this.Controls.Add(this.SelecteurQuantite);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SelecteurPrix);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextboxDescription);
            this.Controls.Add(this.Bouton1);
            this.Controls.Add(this.Bouton3);
            this.Controls.Add(this.Bouton2);
            this.Controls.Add(this.TextboxRefArticle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SelecteurSFamille);
            this.Controls.Add(this.label_ssFamille);
            this.Controls.Add(this.SelecteurFamille);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_marque);
            this.Controls.Add(this.SelecteurMarque);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Update_Article_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UpdateArticle";
            ((System.ComponentModel.ISupportInitialize)(this.marqueBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.marqueBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.marqueBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donneesBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donneesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.marqueDAOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.marqueBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.familleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sousFamilleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelecteurPrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelecteurQuantite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox SelecteurMarque;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label_marque;
        private System.Windows.Forms.BindingSource marqueBindingSource;
        private System.Windows.Forms.BindingSource donneesBindingSource;
        private System.Windows.Forms.BindingSource marqueBindingSource1;
        private System.Windows.Forms.BindingSource marqueDAOBindingSource;
        private System.Windows.Forms.BindingSource donneesBindingSource1;
        private System.Windows.Forms.BindingSource marqueBindingSource2;
        private System.Windows.Forms.BindingSource marqueBindingSource3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SelecteurFamille;
        private System.Windows.Forms.BindingSource familleBindingSource;
        private System.Windows.Forms.Label label_ssFamille;
        private System.Windows.Forms.ComboBox SelecteurSFamille;
        private System.Windows.Forms.BindingSource sousFamilleBindingSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextboxRefArticle;
        private System.Windows.Forms.Button Bouton2;
        private System.Windows.Forms.Button Bouton3;
        private System.Windows.Forms.Button Bouton1;
        private System.Windows.Forms.TextBox TextboxDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown SelecteurPrix;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown SelecteurQuantite;
    }
}