using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hector.Modeles;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Hector.DAO
{
    /// <summary>
    /// DAO des objets <b>SousFamille</b>
    /// </summary>
    public class SousFamilleDAO
    {
        /// <summary>
        /// Récupère toutes les sous-familles de la BDD et les transforme en objets <b>Famille</b> sous forme d'une <b>List<SousFamille></b>
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <returns></returns>
        public static List<SousFamille> GetAllSousFamilles(SQLiteConnection objetConnection)
        {
            List<SousFamille> ListeSousFamilles = new List<SousFamille>();

            SQLiteCommand SelectCommandObject = new SQLiteCommand();
            SelectCommandObject.Connection = objetConnection;
            SelectCommandObject.CommandText = "SELECT * FROM SousFamilles ORDER BY Nom";

            try
            {
                SQLiteDataReader reader = SelectCommandObject.ExecuteReader();
                while (reader.Read())
                {
                    SousFamille sousFamille = new SousFamille();

                    sousFamille.RefSousFamille = Convert.ToInt32(reader["RefSousFamille"]);
                    sousFamille.Nom = Convert.ToString(reader["Nom"]);

                    //recuperation de la famille a partir de sa ref:
                    sousFamille.Famille = FamilleDAO.GetFamilleByRef(objetConnection, Convert.ToInt32(reader["RefFamille"]));
                    //TODO : VERIF SI BESOIN.

                    ListeSousFamilles.Add(sousFamille);
                }

                return ListeSousFamilles;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Récupère toutes les sous-familles de la BDD avec un nom précis et les transforme en objets <b>Famille</b> sous forme d'une <b>List<SousFamille></b>
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <param name="nom"></param>
        /// <returns></returns>
        public static List<SousFamille> GetSousFamillesByName(SQLiteConnection objetConnection, string nom)
        {
            List<SousFamille> ListeSousFamilles = new List<SousFamille>();

            SQLiteCommand SelectCommandObject = new SQLiteCommand();
            SelectCommandObject.Connection = objetConnection;
            SelectCommandObject.CommandText = "SELECT * FROM SousFamilles WHERE Nom = @nom ORDER BY Nom";
            SelectCommandObject.Parameters.AddWithValue("@nom", nom);

            try
            {
                SQLiteDataReader reader = SelectCommandObject.ExecuteReader();
                while (reader.Read())
                {
                    SousFamille sousFamille = new SousFamille();

                    sousFamille.RefSousFamille = Convert.ToInt32(reader["RefSousFamille"]);
                    sousFamille.Nom = Convert.ToString(reader["Nom"]);

                    //recuperation de la famille a partir de sa ref:
                    sousFamille.Famille = FamilleDAO.GetFamilleByRef(objetConnection, Convert.ToInt32(reader["RefFamille"]));
                    //TODO : VERIF SI BESOIN.

                    ListeSousFamilles.Add(sousFamille);
                }

                return ListeSousFamilles;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Récupère toutes les sous-familles de la BDD avec une référence précise et les transforme en objets <b>Famille</b> sous forme d'une <b>List<SousFamille></b>
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <param name="Ref"></param>
        /// <returns></returns>
        public static SousFamille GetSousFamillesByRef(SQLiteConnection objetConnection, int Ref)
        {

            SQLiteCommand SelectCommandObject = new SQLiteCommand();
            SelectCommandObject.Connection = objetConnection;
            SelectCommandObject.CommandText = "SELECT * FROM SousFamilles WHERE RefSousFamille = @ref ORDER BY Nom";
            SelectCommandObject.Parameters.AddWithValue("@ref", Ref);

            try
            {
                SQLiteDataReader reader = SelectCommandObject.ExecuteReader();
                if (reader.Read())
                {
                    SousFamille sousFamille = new SousFamille();

                    sousFamille.RefSousFamille = Convert.ToInt32(reader["RefSousFamille"]);
                    sousFamille.Nom = Convert.ToString(reader["Nom"]);

                    //recuperation de la famille a partir de sa ref:
                    sousFamille.Famille = FamilleDAO.GetFamilleByRef(objetConnection, Convert.ToInt32(reader["RefFamille"]));
                    //TODO : VERIF SI BESOIN.

                    return sousFamille;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Récupère toutes les sous-familles de la BDD associée à une RefFamille particulière et les transforme en objets <b>Famille</b> sous forme d'une <b>List<SousFamille></b>
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <param name="RefFamille"></param>
        /// <returns></returns>
        public static List<SousFamille> GetSousFamillesByRefFamille(SQLiteConnection objetConnection, int RefFamille)
        {
            List<SousFamille> ListeSousFamilles = new List<SousFamille>();

            SQLiteCommand SelectCommandObject = new SQLiteCommand();
            SelectCommandObject.Connection = objetConnection;
            SelectCommandObject.CommandText = "SELECT * FROM SousFamilles WHERE RefFamille = @ref ORDER BY Nom";
            SelectCommandObject.Parameters.AddWithValue("@ref", RefFamille);

            try
            {
                SQLiteDataReader Reader = SelectCommandObject.ExecuteReader();
                while (Reader.Read())
                {
                    SousFamille sousFamille = new SousFamille();

                    sousFamille.RefSousFamille = Convert.ToInt32(Reader["RefSousFamille"]);
                    sousFamille.Nom = Convert.ToString(Reader["Nom"]);

                    //recuperation de la famille a partir de sa ref:
                    sousFamille.Famille = FamilleDAO.GetFamilleByRef(objetConnection, Convert.ToInt32(Reader["RefFamille"]));
                    //TODO : VERIF SI BESOIN.

                    ListeSousFamilles.Add(sousFamille);
                }

                return ListeSousFamilles;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Ajout d'une sous-famille dans la BDD
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <param name="sousFamille"></param>
        public static void AjouterSousFamille(SQLiteConnection objetConnection, SousFamille sousFamille)
        {
            SQLiteCommand InsertCommand = new SQLiteCommand();
            InsertCommand.Connection = objetConnection;
            InsertCommand.CommandText = "INSERT INTO SousFamilles(RefFamille, Nom) VALUES(@Entry1, @Entry2)";
            InsertCommand.Parameters.AddWithValue("@Entry1", sousFamille.Famille.RefFamille);
            InsertCommand.Parameters.AddWithValue("@Entry2", sousFamille.Nom);
            try
            {
                InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Mise à jour d'une sous-famille dans la BDD
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <param name="sousFamille"></param>
        public static void UpdateSousFamille(SQLiteConnection objetConnection, SousFamille sousFamille)
        {
            SQLiteCommand UpdateCommand = new SQLiteCommand();
            UpdateCommand.Connection = objetConnection;

            UpdateCommand.CommandText = "UPDATE SousFamilles SET RefFamille = @Entry1, Nom = @Entry2 WHERE RefSousFamille == @Entry3";
            UpdateCommand.Parameters.AddWithValue("@Entry1", sousFamille.Famille.RefFamille);
            UpdateCommand.Parameters.AddWithValue("@Entry2", sousFamille.Nom);
            UpdateCommand.Parameters.AddWithValue("@Entry3", sousFamille.RefSousFamille);

            try
            {
                UpdateCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Suppression d'une sous-famille
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <param name="sousFamille"></param>
        /// <returns></returns>
        public static bool SupprimerSousFamille(SQLiteConnection objetConnection, SousFamille sousFamille)
        {
            List<Article> ListeArticles = ArticleDAO.GetArticlesByRefSousFamille(objetConnection, sousFamille.RefSousFamille);
            //on récupère tous les articles liés à cette sous-famille

            if (ListeArticles.Count() == 0) //si aucun article n'est lié à celle-ci, la suppression peut s'effectuer
            {
                SQLiteCommand UpdateCommand = new SQLiteCommand();
                UpdateCommand.Connection = objetConnection;

                UpdateCommand.CommandText = "DELETE FROM SousFamilles WHERE RefSousFamille == @Entry6";
                UpdateCommand.Parameters.AddWithValue("@Entry6", sousFamille.RefSousFamille);

                try
                {
                    UpdateCommand.ExecuteNonQuery();

                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                return false;
            }


        }
    }
}
