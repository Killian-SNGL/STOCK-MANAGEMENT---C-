using Hector.Modeles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hector
{
    public partial class Update_Sous_Famille_Form : Form
    {
        public Donnees DonneesDB { get; set; } //représente les données de notre application à savoir liste d'articles, familles, sous-familles marques
        public SousFamille SousFamilleObject { get; set; }
        public bool Modification { get; set; } //détecteur de modification
        public bool Suppression { get; set; } //détecteur de suppression
        public bool Ajout { get; set; } //détecteur d'ajout
        public string PathDB { get; set; } //chemin de la BDD

        public Update_Sous_Famille_Form(Donnees donnees, String pathDB)
        {
            Modification = false;
            Suppression = false;
            Ajout = false;
            DonneesDB = donnees;
            PathDB = pathDB;
            InitializeComponent();
        }

        public void ModifierSousFamille(SousFamille sousFamille)
        {
            SousFamilleObject = sousFamille;
            this.Text = "Modification : " + sousFamille.Nom;
            Bouton3.Text = "Supprimer";
            Bouton2.Text = "Modifier";
            TextBoxRefSousFamille.Text = sousFamille.RefSousFamille.ToString();
            TextBoxFamille.Text = sousFamille.Famille.Nom;
            TextBoxNomSousFamille.Text = sousFamille.Nom;
        }

        public void AjouterSousFamille(SousFamille sousFamille)
        {
            this.Text = "Ajout d'une sous-famille";
            Bouton3.Hide();
            Bouton2.Text = "Ajouter";
            TextBoxRefSousFamille.Text = "SERA GENEREE AUTOMATIQUEMENT";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Bouton2.Text == "Modifier")
            {
                if (SousFamilleObject.Nom != TextBoxNomSousFamille.Text)
                {
                    SousFamilleObject.Nom = TextBoxNomSousFamille.Text;
                    SousFamilleObject.Famille.Nom = TextBoxFamille.Text;

                    using (SQLiteConnection DB = new SQLiteConnection(@"Data Source =" + PathDB + ";Version=3;"))
                    {
                        try
                        {
                            DB.Open();
                            DAO.SousFamilleDAO.UpdateSousFamille(DB, SousFamilleObject);
                            Modification = true;
                            DB.Close();
                        }

                        catch (Exception ExceptionObjet)
                        {
                            MessageBox.Show("Modification non prise en compte.", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }

                    DialogResult result = MessageBox.Show("Modification prise en compte.", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                else
                {
                    this.Close();
                }
            }
            else if (Bouton2.Text == "Ajouter")
            {
                if (TextBoxNomSousFamille.Text != "")
                {
                    SousFamilleObject = new SousFamille();
                    SousFamilleObject.Nom = TextBoxNomSousFamille.Text;
                    SousFamilleObject.Famille.Nom = TextBoxFamille.Text;

                    using (SQLiteConnection DB = new SQLiteConnection(@"Data Source =" + PathDB + ";Version=3;"))
                    {
                        try
                        {
                            DB.Open();
                            DAO.SousFamilleDAO.AjouterSousFamille(DB, SousFamilleObject);
                            Ajout = true;
                            DB.Close();
                        }

                        catch (Exception ExceptionObjet)
                        {
                            MessageBox.Show("Ajout non pris en compte.", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    DialogResult result = MessageBox.Show("Ajout pris en compte.", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("Au moins un des champs est vide.", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void Bouton3_Click(object sender, EventArgs e)
        {
            DialogResult result;
            using (SQLiteConnection DB = new SQLiteConnection(@"Data Source =" + PathDB + ";Version=3;"))
            {
                try
                {
                    DB.Open();
                    Suppression = DAO.SousFamilleDAO.SupprimerSousFamille(DB, SousFamilleObject);
                    DB.Close();
                }
                catch (Exception ExceptionObjet)
                {
                }

                if (Suppression)
                {
                    result = MessageBox.Show("Suppression prise en compte.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                else if (!Suppression)
                {
                    result = MessageBox.Show("Suppression impossible. Sous-famille liée à des articles.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Close();
                    }
                }
            }
        }

    }
}
