using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hector.Modeles;
using Hector.DAO;
using System.Data.SQLite;

namespace Hector
{
    public partial class Update_Famille_Form : Form
    {
        public Donnees DonneesDB { get; set; } //représente les données de notre application à savoir liste d'articles, familles, sous-familles marques
        public bool Modification { get; set; } //détecteur de modification
        public bool Suppression { get; set; } //détecteur de suppression
        public bool Ajout { get; set; } //détecteur d'ajout
        public string PathDB { get; set; }//chemin de la BDD

        public Famille FamilleObjet { get; set; }
        public Update_Famille_Form(Donnees donnees, String pathDB)
        {
            Modification = false;
            Suppression = false;
            Ajout = false;
            DonneesDB = donnees;
            PathDB = pathDB;
            InitializeComponent();
        }

        /// <summary>
        /// Préparer le formulaire pour modifier
        /// </summary>
        /// <param name="famille"></param>
        public void ModifierFamille(Famille famille)
        {
            FamilleObjet = famille;

            this.Text = "Modification famille : " + FamilleObjet.Nom;

            Bouton1.Enabled = true;
            Bouton1.Show();
            Bouton1.Text = "Supprimer";
            Bouton2.Text = "Modifier";

            TextboxNom.Text = FamilleObjet.Nom;
            TextboxRefFamille.Text = FamilleObjet.RefFamille.ToString();
            TextboxRefFamille.Enabled = false;
        }

        /// <summary>
        /// Préparer le formulaire pour ajout
        /// </summary>
        public void AjouterFamille()
        {
            this.Text = "Ajout d'une famille";

            Bouton1.Enabled = false;
            Bouton1.Hide();
            Bouton1.Text = "";
            Bouton2.Text = "Ajouter";
            TextboxRefFamille.Enabled = false;
            TextboxRefFamille.Text = " SERA GENEREE AUTOMATIQUEMENT ";
        }

        /// <summary>
        /// Déclenchement évènement bouton 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bouton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Déclenchement évènement bouton 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bouton2_Click(object sender, EventArgs e)
        {
            if (Bouton2.Text == "Ajouter")
            {
                string Contenu = TextboxNom.Text;

                FamilleObjet = new Famille();
                FamilleObjet.Nom = Contenu;

                using (SQLiteConnection DB = new SQLiteConnection(@"Data Source =" + PathDB + ";Version=3;"))
                {
                    try
                    {
                        if (FamilleObjet.Nom != "")
                        {
                            DB.Open();
                            FamilleDAO.AjouterFamille(DB, FamilleObjet);
                            MessageBox.Show("Ajout pris en compte.", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DonneesDB.ListeFamilles.Add(FamilleObjet);
                            Ajout = true;
                            DB.Close();
                        }
                        else
                        {
                            MessageBox.Show("Au moins un des champs est vide.", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    catch (Exception E)
                    {
                        MessageBox.Show("Ajout non pris en compte.", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                this.Close();
            }

            if (Bouton2.Text == "Modifier")
            {
                string Contenu = TextboxNom.Text;
                FamilleObjet.Nom = Contenu;

                using (SQLiteConnection DB = new SQLiteConnection(@"Data Source =" + PathDB + ";Version=3;"))
                {
                    try
                    {

                        if (FamilleObjet.Nom != "")
                        {
                            DB.Open();
                            FamilleDAO.UpdateFamille(DB, FamilleObjet);
                            MessageBox.Show("Modification prise en compte.", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            int IndexInListeFamilles = DonneesDB.ListeFamilles.FindIndex(item => item.RefFamille == FamilleObjet.RefFamille);
                            DonneesDB.ListeFamilles[IndexInListeFamilles] = FamilleObjet;
                            Modification = true;
                            DB.Close();
                        }
                        else
                        {
                            MessageBox.Show("Au moins un des champs est vide.", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception E)
                    {
                        MessageBox.Show("Modification non prise en compte.", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                this.Close();
            }
        }

        private void SupprimerFamille()
        {
            using (SQLiteConnection DB = new SQLiteConnection(@"Data Source =" + PathDB + ";Version=3;"))
            {
                try
                {
                    DB.Open();
                    if (FamilleDAO.SupprimerFamille(DB, FamilleObjet))
                    {
                        MessageBox.Show("Suppression prise en compte.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        int IndexInListeFamilles = DonneesDB.ListeFamilles.FindIndex(item => item.RefFamille == FamilleObjet.RefFamille);
                        DonneesDB.ListeFamilles.RemoveAt(IndexInListeFamilles);
                        Suppression = true;
                    }
                    else
                    {
                        MessageBox.Show("Suppression impossible. Famille liée à des articles.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception E)
                {
                    MessageBox.Show("Suppression impossible.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.Close();
        }

        /// <summary>
        /// Déclenchement évènement bouton 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bouton1_Click(object sender, EventArgs e)
        {
            if (Bouton1.Text == "Supprimer")
            {
                SupprimerFamille();
            }
        }
    }

}
