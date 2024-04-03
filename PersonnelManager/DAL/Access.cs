using System;

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
            try
            {
                string connectionString = Environment.GetEnvironmentVariable("PersonnelManager_ConnectionString");
                Manager = BddManager.BddManager.GetInstance(connectionString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Environment.Exit(1);
            }
        }
    }
}