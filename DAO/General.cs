using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hector.DAO
{
    /// <summary>
    /// DAO général de la BDD
    /// </summary>
    public static class General
    {
        /// <summary>
        /// Récupère dernier ID inséré dans la BDD
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <returns></returns>
        public static int GetLastInsertedID(SQLiteConnection objetConnection)
        {
            SQLiteCommand SelectCommandObject = new SQLiteCommand();
            SelectCommandObject.Connection = objetConnection;
            SelectCommandObject.CommandText = "SELECT last_insert_rowid();";


            try
            {
                SelectCommandObject.ExecuteNonQuery();
                return Convert.ToInt32(SelectCommandObject.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Vide les tables de la BDD
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <returns></returns>
        public static bool ClearAllTables(SQLiteConnection objetConnection)
        {
            SQLiteCommand ClearCommand = new SQLiteCommand();
            ClearCommand.Connection = objetConnection;
            ClearCommand.CommandText = "DELETE FROM `Articles`;" +
                "DELETE FROM `Familles`;" +
                "DELETE FROM `Marques`;" +
                "DELETE FROM `SousFamilles`;";

            try
            {
                ClearCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Vide table Articles de la BDD
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <returns></returns>
        public static int ClearTableArticles(SQLiteConnection objetConnection)
        {
            SQLiteCommand TruncateCommandObject = new SQLiteCommand();
            TruncateCommandObject.Connection = objetConnection;
            TruncateCommandObject.CommandText = "DELETE FROM `Articles`;";

            try
            {
                TruncateCommandObject.ExecuteNonQuery();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return 0;
            }
        }

        /// <summary>
        /// Vide table Familles de la BDD
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <returns></returns>
        public static int ClearTableFamilles(SQLiteConnection objetConnection)
        {
            SQLiteCommand TruncateCommandObject = new SQLiteCommand();
            TruncateCommandObject.Connection = objetConnection;
            TruncateCommandObject.CommandText = "DELETE FROM `Familles`;";

            try
            {
                TruncateCommandObject.ExecuteNonQuery();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return 0;
            }
        }

        /// <summary>
        /// Vide table Marques de la BDD
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <returns></returns>
        public static int ClearTableMarques(SQLiteConnection objetConnection)
        {
            SQLiteCommand TruncateCommandObject = new SQLiteCommand();
            TruncateCommandObject.Connection = objetConnection;
            TruncateCommandObject.CommandText = "DELETE FROM `Marques`;";

            try
            {
                TruncateCommandObject.ExecuteNonQuery();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return 0;
            }
        }

        /// <summary>
        /// Vide table SousFamilles de la BDD
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <returns></returns>
        public static int ClearTableSousFamilles(SQLiteConnection objetConnection)
        {
            SQLiteCommand TruncateCommandObject = new SQLiteCommand();
            TruncateCommandObject.Connection = objetConnection;
            TruncateCommandObject.CommandText = "DELETE FROM `SousFamilles`;";

            try
            {
                TruncateCommandObject.ExecuteNonQuery();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return 0;
            }
        }
    }
}
