using System;
using System.Collections.Generic;
using PersonnelManager.DAL;
using PersonnelManager.Model;

namespace PersonnelManager.Controller
{
    /// <summary>
    /// Controlleur gérant les requêtes de la classe AbsencesForm
    /// </summary>
    public class AbsencesFormController
    {
        /// <summary>
        /// Méthode permettant de récupérer les absences pour un personnel
        /// </summary>
        /// <param name="personnel">Le personnel en question</param>
        /// <returns>La liste complète des absences pour ce personnel</returns>
        public List<Absence> GetAbsences(Personnel personnel) => AbsenceAccess.GetAbsences(personnel);

        /// <summary>
        /// Méthode permettant d'ajouter une absence pour un personnel
        /// </summary>
        /// <param name="absence">L'absence à ajouter</param>
        public void AddAbsence(Absence absence) => AbsenceAccess.AddAbsence(absence);
        
        /// <summary>
        /// Méthode permettant de mettre à jour une absence pour un personnel
        /// </summary>
        /// <param name="absence">L'absence à mettre à jour</param>
        /// <param name="dateDebutInitiale">La date de début de l'absence avant son changement</param>
        public void UpdateAbsence(Absence absence, DateTime dateDebutInitiale) => AbsenceAccess.UpdateAbsence(absence, dateDebutInitiale);
        
        /// <summary>
        /// Méthode permettant de supprimer une absence pour un personnel
        /// </summary>
        /// <param name="absence">L'absence à supprimer</param>
        public void DeleteAbsence(Absence absence) => AbsenceAccess.DeleteAbsence(absence);
    }
}