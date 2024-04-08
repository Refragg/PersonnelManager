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
    }
}