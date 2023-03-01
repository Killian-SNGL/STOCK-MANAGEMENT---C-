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
using System.Data.SQLite;

namespace Hector
{
    public partial class Update_Marque_Form : Form
    {
        public Donnees DonneesDB { get; set; } //représente les données de notre application à savoir liste d'articles, familles, sous-familles marques
        public Marque MarqueObjet { get; set; }
        public string PathDB { get; set; } //chemin de la BDD
        public bool Modification { get; set; } //détecteur de modification
        public bool Suppression { get; set; } //détecteur de suppression
        public bool Ajout { get; set; } //détecteur d'ajout

        /// <summary>
        /// Initialise une nouvelle instance de l'objet <b>Update_Marque_Form</b>
        /// </summary>
        /// <param name="donnees"></param>
        /// <param name="path"></param>
        public Update_Marque_Form(Donnees donnees, string path)
        {
            PathDB = path;
            DonneesDB = donnees;
            Modification = false;
            Ajout = false;
            Suppression = false;
            InitializeComponent();
        }

        /// <summary>
        /// Préparer le formulaire pour modifier
        /// </summary>
        /// <param name="marque"></param>
        public void ModifierMarque(Marque marque)
        {
            MarqueObjet = marque;
            this.Text = "Modification : " + marque.NomMarque;
            Bouton3.Text = "Supprimer";
            Bouton2.Text = "Modifier";
            TextboxRefMarque.Text = marque.RefMarque.ToString();
            TextboxNomMarque.Text = marque.NomMarque;
        }

        /// <summary>
        /// Préparer le formulaire pour ajout
        /// </summary>
        public void AjoutMarque()
        {
            this.Text = "Ajout d'une marque";
            Bouton3.Hide();
            Bouton2.Text = "Ajout";
            TextboxRefMarque.Text = "SERA GENEREE AUTOMATIQUEMENT";
        }

        /// <summary>
        /// Déclenchement évènement bouton 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Déclenchement évènement bouton 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if(Bouton2.Text == "Modifier")
            {
                if (MarqueObjet.NomMarque != TextboxNomMarque.Text)
                {
                    MarqueObjet.NomMarque = TextboxNomMarque.Text;
                    using (SQLiteConnection DB = new SQLiteConnection(@"Data Source =" + PathDB + ";Version=3;"))
                    {
                        try
                        {
                            DB.Open();
                            DAO.MarqueDAO.UpdateMarque(DB, MarqueObjet);
                            Modification = true;
                            DB.Close();
                        }

                        catch (Exception ExceptionObjet)
                        {
                        }
                    }

                    DialogResult result = MessageBox.Show("Modification pris en compte.", "Modification", MessageBoxButtons.OK);

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
            else if(Bouton2.Text == "Ajout")
            {
                if (TextboxNomMarque.Text != "")
                {
                    MarqueObjet = new Marque();
                    MarqueObjet.NomMarque = TextboxNomMarque.Text;
                    using (SQLiteConnection DB = new SQLiteConnection(@"Data Source =" + PathDB + ";Version=3;"))
                    {
                        try
                        {
                            DB.Open();
                            DAO.MarqueDAO.AjouterMarque(DB, MarqueObjet);
                            Ajout = true;
                            DB.Close();
                        }

                        catch (Exception ExceptionObjet)
                        {
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

        /// <summary>
        /// Déclenchement évènement bouton 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bouton3_Click(object sender, EventArgs e)
        {
            DialogResult result;
            using (SQLiteConnection DB = new SQLiteConnection(@"Data Source =" + PathDB + ";Version=3;"))
            {
                try
                {
                    DB.Open();
                    Suppression = DAO.MarqueDAO.SupprimerMarque(DB, MarqueObjet);
                    DB.Close();
                }
                catch (Exception ExceptionObjet)
                {
                }

                if(Suppression)
                {
                    result = MessageBox.Show("Suppression prise en compte.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                else if(!Suppression)
                {
                    result = MessageBox.Show("Suppression impossible. Marque liée à des articles.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Close();
                    }
                }
            }
        }
    }
}
