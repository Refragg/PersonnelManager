using System.Collections.Generic;
using PersonnelManager.Model;

namespace PersonnelManager.DAL
{
    /// <summary>
    /// La classe d'accès aux services
    /// </summary>
    public static class ServiceAccess
    {
        /// <summary>
        /// L'instance unique pour accéder à la base de données
        /// </summary>
        private static Access _access = Access.Instance;

        /// <summary>
        /// Méthode permettant de récupérer les services depuis la base de données
        /// </summary>
        /// <returns>La liste complète des services</returns>
        /// <exception cref="MySqlConnector.MySqlException">La requête vers la base de données a échoué</exception>
        public static List<Service> GetServices()
        {
            var result = _access.Manager.ReqSelect("select * from service");
            
            var services = new List<Service>();
            foreach (object[] service in result)
                services.Add(new Service((int)service[0], (string)service[1]));

            return services;
        }
    }
}