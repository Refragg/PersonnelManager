using System.Collections.Generic;
using PersonnelManager.DAL;
using PersonnelManager.Model;

namespace PersonnelManager.Controller
{
    /// <summary>
    /// Controlleur gérant les requêtes de la classe PersonnelEditForm
    /// </summary>
    public class PersonnelEditFormController
    {
        /// <summary>
        /// Méthode permettant de récupérer les services
        /// </summary>
        /// <returns>La liste complète des services</returns>
        public List<Service> GetServices() => ServiceAccess.GetServices();
    }
}