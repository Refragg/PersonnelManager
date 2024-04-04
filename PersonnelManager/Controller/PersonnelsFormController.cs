using System.Collections.Generic;
using PersonnelManager.DAL;
using PersonnelManager.Model;

namespace PersonnelManager.Controller
{
    /// <summary>
    /// Controlleur gérant les requêtes de la classe PersonnelsForm
    /// </summary>
    public class PersonnelsFormController
    {
        /// <summary>
        /// Méthode pour mettre à jour les champs d'un personnel
        /// </summary>
        /// <param name="personnel">Le personnel à mettre à jour</param>
        public void UpdatePersonnel(Personnel personnel) => PersonnelAccess.UpdatePersonnel(personnel);
        
        /// <summary>
        /// Méthode pour ajouter un personnel
        /// </summary>
        /// <param name="personnel">Le personnel à ajouter</param>
        public void AddPersonnel(Personnel personnel) => PersonnelAccess.AddPersonnel(personnel);

        /// <summary>
        /// Méthode permettant de récupérer les personnels
        /// </summary>
        /// <returns>La liste complète des personnels</returns>
        public List<Personnel> GetPersonnels() => PersonnelAccess.GetPersonnels();

        /// <summary>
        /// Méthode pour supprimer un personnel
        /// </summary>
        /// <param name="personnel">Le personnel à supprimer</param>
        public void DeletePersonnel(Personnel personnel) => PersonnelAccess.DeletePersonnel(personnel);
    }
}