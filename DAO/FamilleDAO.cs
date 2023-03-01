using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hector.Modeles;

namespace Hector.DAO
{
    /// <summary>
    /// DAO d'un objet <b>Famille</b>
    /// </summary>
    public class FamilleDAO
    {
        /// <summary>
        /// Récupère toutes les familles de la BDD et les transforme en objets <b>Famille</b> sous forme d'une <b>List<Famille></b>
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <param name="nom"></param>
        /// <returns></returns>
        public static List<Famille> GetAllFamilles(SQLiteConnection objetConnection)
        {
            List<Famille> ListeFamilles = new List<Famille>();

            SQLiteCommand SelectCommandObject = new SQLiteCommand();
            SelectCommandObject.Connection = objetConnection;
            SelectCommandObject.CommandText = "SELECT * FROM Familles ORDER BY Nom";

            try
            {
                SQLiteDataReader reader = SelectCommandObject.ExecuteReader();
                while (reader.Read())
                {
                    Famille Famille = new Famille();

                    Famille.RefFamille = Convert.ToInt32(reader["RefFamille"]);
                    Famille.Nom = Convert.ToString(reader["Nom"]);

                    ListeFamilles.Add(Famille);
                }

                return ListeFamilles;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Récupère toutes les familles de la BDD en fonction d'un nom précis et les transforme en objets <b>Famille</b> sous forme d'une <b>List<Famille></b>
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <param name="nom"></param>
        /// <returns></returns>
        public static List<Famille> GetFamillesByName(SQLiteConnection objetConnection, string nom)
        {
            List<Famille> ListeFamilles = new List<Famille>();

            SQLiteCommand SelectCommandObject = new SQLiteCommand();
            SelectCommandObject.Connection = objetConnection;
            SelectCommandObject.CommandText = "SELECT * FROM Familles WHERE Nom = @nom ORDER BY Nom";
            SelectCommandObject.Parameters.AddWithValue("@nom", nom);

            try
            {
                SQLiteDataReader Reader = SelectCommandObject.ExecuteReader();
                while (Reader.Read())
                {
                    Famille Famille = new Famille();

                    Famille.RefFamille = Convert.ToInt32(Reader["RefFamille"]);
                    Famille.Nom = Convert.ToString(Reader["Nom"]);

                    ListeFamilles.Add(Famille);
                }

                return ListeFamilles;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Récupère une famille précise dans la BDD en fonction de sa référence et le transforme en objet <b>Famille</b>
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <param name="Ref"></param>
        /// <returns></returns>
        public static Famille GetFamilleByRef(SQLiteConnection objetConnection, int Ref)
        {

            SQLiteCommand SelectCommandObject = new SQLiteCommand();
            SelectCommandObject.Connection = objetConnection;
            SelectCommandObject.CommandText = "SELECT * FROM Familles WHERE RefFamille = @ref ORDER BY Nom";
            SelectCommandObject.Parameters.AddWithValue("@ref", Ref);

            try
            {
                SQLiteDataReader Reader = SelectCommandObject.ExecuteReader();
                if (Reader.Read())
                {
                    Famille Famille = new Famille();

                    Famille.RefFamille = Convert.ToInt32(Reader["RefFamille"]);
                    Famille.Nom = Convert.ToString(Reader["Nom"]);

                    return Famille;
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
        /// Ajout d'une famille dans la BDD
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <param name="famille"></param>
        public static void AjouterFamille(SQLiteConnection objetConnection, Famille famille)
        {
            SQLiteCommand InsertCommand = new SQLiteCommand();
            InsertCommand.Connection = objetConnection;
            InsertCommand.CommandText = "INSERT INTO Familles(Nom) VALUES(@Entry)";
            InsertCommand.Parameters.AddWithValue("@Entry", famille.Nom);
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
        /// Modification d'une famille dans la BDD
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <param name="famille"></param>
        public static void UpdateFamille(SQLiteConnection objetConnection, Famille famille)
        {
            SQLiteCommand UpdateCommand = new SQLiteCommand();
            UpdateCommand.Connection = objetConnection;

            UpdateCommand.CommandText = "UPDATE Familles SET Nom = @Entry1 WHERE RefFamille == @Entry2";
            UpdateCommand.Parameters.AddWithValue("@Entry1", famille.Nom);
            UpdateCommand.Parameters.AddWithValue("@Entry2", famille.RefFamille);

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
        /// Suppression d'une famille dans la BDD
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <param name="famille"></param>
        /// <returns></returns>
        public static bool SupprimerFamille(SQLiteConnection objetConnection, Famille famille)
        {
            List<SousFamille> ListeSousFamilles = SousFamilleDAO.GetSousFamillesByRefFamille(objetConnection, famille.RefFamille);

            if (ListeSousFamilles.Count() > 0) //si famille est associée à au moins une sous-famille
            {
                bool ArticleReference = false; //par défaut aucun article est lié à une sous famille de famille
                int IndiceListe = 0;

                while (!ArticleReference && IndiceListe != ListeSousFamilles.Count()-1)
                {
                    if (ArticleDAO.GetArticlesByRefSousFamille(objetConnection, ListeSousFamilles[IndiceListe].RefSousFamille).Count() != 0)
                    {
                        ArticleReference = true;
                    }
                    IndiceListe++;
                }

                if (!ArticleReference) //s'il n'existe aucun article lié à une sous-famille liée à famille
                {
                    SQLiteCommand UpdateCommand = new SQLiteCommand();
                    UpdateCommand.Connection = objetConnection;

                    UpdateCommand.CommandText = "DELETE FROM Familles WHERE RefFamille == @Entry6";
                    UpdateCommand.Parameters.AddWithValue("@Entry6", famille.RefFamille);

                    try
                    {
                        foreach (SousFamille sf in ListeSousFamilles)
                        {
                            SousFamilleDAO.SupprimerSousFamille(objetConnection, sf);
                        }
                        UpdateCommand.ExecuteNonQuery();

                        return true; //suppression possible
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                else
                {
                    return false; //suppression impossible
                }
            }
            else //si famille n'est associée à aucune une sous-famille
            {
                SQLiteCommand UpdateCommand = new SQLiteCommand();
                UpdateCommand.Connection = objetConnection;

                UpdateCommand.CommandText = "DELETE FROM Familles WHERE RefFamille == @Entry6";
                UpdateCommand.Parameters.AddWithValue("@Entry6", famille.RefFamille);

                try
                {
                    UpdateCommand.ExecuteNonQuery();

                    return true; //suppression possible
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }        
        }
    }
}
