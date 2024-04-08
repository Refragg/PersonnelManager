using System.Collections.Generic;
using PersonnelManager.DAL;
using PersonnelManager.Model;

namespace PersonnelManager.Controller
{
    /// <summary>
    /// Controlleur gérant les requêtes de la classe AbsenceEditForm
    /// </summary>
    public class AbsenceEditFormController
    {
        /// <summary>
        /// Méthode permettant de récupérer tout les motifs d'absence possible
        /// </summary>
        /// <returns>La liste complète des motifs d'absence</returns>
        public List<Motif> GetMotifs() => MotifAccess.GetMotifs();
    }
}