using System;
using System.Collections.Generic;
using PersonnelManager.Model;

namespace PersonnelManager.DAL
{
    /// <summary>
    /// La classe d'accès aux absences d'un personnel
    /// </summary>
    public static class AbsenceAccess
    {
        /// <summary>
        /// L'instance unique pour accéder à la base de données
        /// </summary>
        private static Access _access = Access.Instance;

        /// <summary>
        /// Méthode permettant de récupérer les absences d'un personnel depuis la base de données
        /// </summary>
        /// <param name="personnel">Le personnel en question</param>
        /// <returns>La liste complète des absences pour le personnel en question</returns>
        /// <exception cref="MySqlConnector.MySqlException">La requête vers la base de données a échoué</exception>
        public static List<Absence> GetAbsences(Personnel personnel)
        {
            var result = _access.Manager.ReqSelect(
                "select idpersonnel, datedebut, datefin, idmotif " +
                "from absence " +
                "where idpersonnel = @idpersonnel",
                new Dictionary<string, object> { { "idpersonnel", personnel.IdPersonnel } });
            
            var absences = new List<Absence>();
            foreach (object[] absence in result)
                absences.Add(new Absence(
                    PersonnelAccess.GetPersonnel((int)absence[0]),
                    (DateTime)absence[1],
                    (DateTime)absence[2],
                    MotifAccess.GetMotif((int)absence[3])));

            return absences;
        }
    }
}