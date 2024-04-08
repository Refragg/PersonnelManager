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

        /// <summary>
        /// Méthode permettant de récupérer un service précis depuis son ID dans la base de données
        /// </summary>
        /// <param name="idService">L'ID du service à récupérer</param>
        /// <returns>Le service en question</returns>
        /// <exception cref="MySqlConnector.MySqlException">La requête vers la base de données a échoué</exception>
        public static Service GetService(int idService)
        {
            var result = _access.Manager.ReqSelect(
                "select idservice, nom from service where idservice = @idservice",
                new Dictionary<string, object> { { "idservice", idService } });

            var rawService = result[0];

            return new Service((int)rawService[0], (string)rawService[1]);
        }
    }
}