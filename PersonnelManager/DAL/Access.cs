using System;
using System.Windows.Forms;

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
        public static Access Instance { get; } = new Access();

        /// <summary>
        /// L'instance du BddManager
        /// </summary>
        public BddManager.BddManager Manager;
        
        /// <summary>
        /// Constructeur privé valorisant le BddManager
        /// </summary>
        private Access()
        {
            string connectionString = Environment.GetEnvironmentVariable("PersonnelManager_ConnectionString");
            if (string.IsNullOrEmpty(connectionString))
                MessageBox.Show(
                    "La chaîne de connexion à la base de données est vide, la connexion à la base de données va probablement échouer.\r\n\r\nVeuillez vous référer a la documentation pour fournir une châine de connexion valide",
                    "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Manager = BddManager.BddManager.GetInstance(connectionString);
        }
    }
}