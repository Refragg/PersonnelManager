using System;
using System.Windows.Forms;
using MySqlConnector;

namespace PersonnelManager.DAL
{
    /// <summary>
    /// (Singleton) Interface publique pour accéder à la base de données
    /// </summary>
    public class Access
    {
        /// <summary>
        /// L'instance unique de la classe
        /// </summary>
        public static Access Instance { private set; get; } = new Access();

        /// <summary>
        /// L'instance du BddManager
        /// </summary>
        /// <remarks>Les identifiants doivent être validés avec <see cref="ValidationIdentifiants"/> avant de pouvoir accéder à ce membre</remarks>
        public BddManager.BddManager Manager;
        
        /// <summary>
        /// Vérifie la validité des identifiants donnés en paramètre et valorise l'instance de la classe en cas de succès
        /// </summary>
        /// <param name="login">Le nom d'utilisateur à vérifier</param>
        /// <param name="password">Le mot de passe (en clair) à vérifier</param>
        /// <returns>'true' si les identifiants sont valides, 'false' sinon</returns>
        public static bool ValidationIdentifiants(string login, string password)
        {
            string connectionString = Environment.GetEnvironmentVariable("PersonnelManager_ConnectionString");
            if (string.IsNullOrEmpty(connectionString))
                MessageBox.Show(
                    "La chaîne de connexion à la base de données est vide, la connexion à la base de données va probablement échouer.\r\n\r\nVeuillez vous référer a la documentation pour fournir une châine de connexion valide",
                    "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            // Utilisation de la châine de connexion comme base et ajout des paramètres 'user id' et 'password' à celle-ci
            MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder(connectionString);
            
            connectionStringBuilder.UserID = login;
            connectionStringBuilder.Password = password;

            try
            {
                Instance.Manager = BddManager.BddManager.GetInstance(connectionStringBuilder.ToString());
            }
            catch (MySqlException e)
            {
                if (e.ErrorCode == MySqlErrorCode.AccessDenied)
                    return false;

                throw;
            }

            return true;
        }

        /// <summary>
        /// Constructeur privé pour le respect du singleton
        /// </summary>
        private Access()
        {
        }
    }
}