using Hector.Modeles;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using Hector.Modeles;
using System.Threading.Tasks;

namespace Hector.DAO
{

    class MarqueDAO
    {

        /// <summary>
        /// Récupère toutes les marques de la BDD et les transforme en objet <b>Marque</b> sous formes d'une <b>List<Marque></b>
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <returns></returns>
        public static List<Marque> GetAllMarques(SQLiteConnection objetConnection)
        {
            List<Marque> ListeMarques = new List<Marque>();

            SQLiteCommand SelectCommandObject = new SQLiteCommand();
            SelectCommandObject.Connection = objetConnection;
            SelectCommandObject.CommandText = "SELECT * FROM Marques ORDER BY Nom";

            try
            {
                SQLiteDataReader Reader = SelectCommandObject.ExecuteReader();
                while (Reader.Read())
                {
                    Marque Marque = new Marque();

                    Marque.RefMarque = Convert.ToInt32(Reader["RefMarque"]);
                    Marque.NomMarque = Convert.ToString(Reader["Nom"]);

                    ListeMarques.Add(Marque);
                }

                return ListeMarques;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Récupère toutes les marques de la BDD en fonction d'un nom précis et les transforme en objets <b>Marque</b> sous forme d'une <b>List<Marque></b>
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <param name="nom"></param>
        /// <returns></returns>
        public static List<Marque> GetMarquesByName(SQLiteConnection objetConnection, string nom)
        {
            List<Marque> ListeMarques = new List<Marque>();

            SQLiteCommand SelectCommandObject = new SQLiteCommand();
            SelectCommandObject.Connection = objetConnection;
            SelectCommandObject.CommandText = "SELECT * FROM Marques WHERE Nom = @marque ORDER BY Nom";
            SelectCommandObject.Parameters.AddWithValue("@marque", nom);

            try
            {
                SQLiteDataReader reader = SelectCommandObject.ExecuteReader();
                while (reader.Read())
                {
                    Marque Marque = new Marque();

                    Marque.RefMarque = Convert.ToInt32(reader["RefMarque"]);
                    Marque.NomMarque = Convert.ToString(reader["Nom"]);

                    ListeMarques.Add(Marque);
                }

                return ListeMarques;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Récupère toutes les marques de la BDD en fonction d'une RefMarque précise et les transforme en objets <b>Marque</b> sous forme d'une <b>List<Marque></b>
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <param name="refMarque"></param>
        /// <returns></returns>
        public static Marque GetMarqueByRef(SQLiteConnection objetConnection, int Ref)
        {
            SQLiteCommand SelectCommandObject = new SQLiteCommand();
            SelectCommandObject.Connection = objetConnection;
            SelectCommandObject.CommandText = "SELECT * FROM Marques WHERE RefMarque = @ref ORDER BY Nom";
            SelectCommandObject.Parameters.AddWithValue("@ref", Ref);

            try
            {
                SQLiteDataReader reader = SelectCommandObject.ExecuteReader();
                if (reader.Read())
                {
                    Marque Marque = new Marque();

                    Marque.RefMarque = Convert.ToInt32(reader["RefMarque"]);
                    Marque.NomMarque = Convert.ToString(reader["Nom"]);

                    return Marque;
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
        /// Ajout d'une marque dans la BDD
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <param name="marque"></param>
        public static void AjouterMarque(SQLiteConnection objetConnection, Marque marque)
        {
            SQLiteCommand insertCommand = new SQLiteCommand();
            insertCommand.Connection = objetConnection;
            insertCommand.CommandText = "INSERT INTO Marques(Nom) VALUES(@Entry)";
            insertCommand.Parameters.AddWithValue("@Entry", marque.NomMarque);
            try
            {
                insertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Modification d'une marque dans la BDD
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <param name="marque"></param>
        public static void UpdateMarque(SQLiteConnection objetConnection, Marque marque)
        {
            SQLiteCommand UpdateCommand = new SQLiteCommand();
            UpdateCommand.Connection = objetConnection;

            UpdateCommand.CommandText = "UPDATE Marques SET Nom = @Entry1 WHERE RefMarque == @Entry2";
            UpdateCommand.Parameters.AddWithValue("@Entry1", marque.NomMarque);
            UpdateCommand.Parameters.AddWithValue("@Entry2", marque.RefMarque);

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
        /// Suppression d'une marque dans la BDD
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <param name="marque"></param>
        /// <returns></returns>
        public static bool SupprimerMarque(SQLiteConnection objetConnection, Marque marque)
        {
            List<Article> ListeArticles = ArticleDAO.GetArticlesByRefMarque(objetConnection, marque.RefMarque);

            if (ListeArticles.Count() == 0)
            {
                SQLiteCommand UpdateCommand = new SQLiteCommand();
                UpdateCommand.Connection = objetConnection;

                UpdateCommand.CommandText = "DELETE FROM Marques WHERE RefMarque == @Entry6";
                UpdateCommand.Parameters.AddWithValue("@Entry6", marque.RefMarque);

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
