using MySqlConnector;
using System;
using System.Collections.Generic;

namespace PersonnelManager.BddManager
{
    /// <summary>
    /// Singleton : connexion à la base de données et exécution des requêtes
    /// </summary>
    public class BddManager
    {
        /// <summary>
        /// Instance unique de la classe
        /// </summary>
        private static BddManager _instance = null;
        /// <summary>
        /// Objet de connexion à la BDD à partir d'une chaîne de connexion
        /// </summary>
        private readonly MySqlConnection _connection;

        /// <summary>
        /// Constructeur pour créer la connexion à la BDD et l'ouvrir
        /// </summary>
        /// <param name="stringConnect">Chaine de connexion</param>
        private BddManager(string stringConnect)
        {
            _connection = new MySqlConnection(stringConnect);
            _connection.Open();
        }

        /// <summary>
        /// Création d'une seule instance de la classe
        /// </summary>
        /// <param name="stringConnect">Chaine de connexion</param>
        /// <returns>Instance unique de la classe</returns>
        public static BddManager GetInstance(string stringConnect)
        {
            if (_instance == null)
            {
                _instance = new BddManager(stringConnect);
            }
            return _instance;
        }

        /// <summary>
        /// Exécution d'une requête de type LCT (begin transaction...)
        /// </summary>
        /// <param name="stringQuery">Requête SQL</param>
        public void ReqControle(string stringQuery)
        {
            MySqlCommand command = new MySqlCommand(stringQuery, _connection);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Exécution d'une requête de type LMD (insert, update, delete)
        /// </summary>
        /// <param name="stringQuery">Requête SQL</param>
        /// <param name="parameters">Dictionnaire contenant les paramètres</param>
        public void ReqUpdate(string stringQuery, Dictionary<string, object> parameters = null)
        {
            MySqlCommand command = new MySqlCommand(stringQuery, _connection);
            if (!(parameters is null))
            {
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    command.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));
                }
            }
            command.Prepare();
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Exécution d'une requête de type LID (select)
        /// </summary>
        /// <param name="stringQuery">Requête</param>
        /// <param name="parameters">Dictoinnaire contenant les parametres</param>
        /// <returns>Liste de tableaux d'objets contenant les valeurs des colonnes</returns>
        public List<Object[]> ReqSelect(string stringQuery, Dictionary<string, object> parameters = null)
        {
            MySqlCommand command = new MySqlCommand(stringQuery, _connection);
            if (!(parameters is null))
            {
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    command.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));
                }
            }
            command.Prepare();
            MySqlDataReader reader = command.ExecuteReader();
            int nbCols = reader.FieldCount;
            List<Object[]> records = new List<object[]>();
            while (reader.Read())
            {
                Object[] attributs = new Object[nbCols];
                reader.GetValues(attributs);
                records.Add(attributs);
            }
            reader.Close();
            return records;
        }
    }
}