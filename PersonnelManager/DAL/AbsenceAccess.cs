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

        /// <summary>
        /// Méthode pour ajouter une absence à un personnel dans la base de données
        /// </summary>
        /// <param name="absence">L'absence à ajouter</param>
        /// <exception cref="MySqlConnector.MySqlException">La requête vers la base de données a échoué</exception>
        public static void AddAbsence(Absence absence)
        {
            var requestParams = new Dictionary<string, object>
            {
                { "idpersonnel", absence.Personnel.IdPersonnel },
                { "datedebut", absence.DateDebut },
                { "datefin", absence.DateFin },
                { "idmotif", absence.Motif.IdMotif }
            };
            
            _access.Manager.ReqUpdate(
                "insert into absence " +
                "values(@idpersonnel, " +
                "@datedebut, " +
                "@datefin, " +
                "@idmotif)",
                requestParams);
        }
        
        /// <summary>
        /// Méthode pour mettre à jour les champs d'une absence d'un personnel dans la base de données
        /// </summary>
        /// <param name="absence">L'absence à mettre à jour</param>
        /// <param name="dateDebutInitiale">La date de début de l'absence avant son changement</param>
        /// <exception cref="MySqlConnector.MySqlException">La requête vers la base de données a échoué</exception>
        public static void UpdateAbsence(Absence absence, DateTime dateDebutInitiale)
        {
            var requestParams = new Dictionary<string, object>
            {
                { "idpersonnel", absence.Personnel.IdPersonnel },
                { "datedebut", absence.DateDebut },
                { "datedebutinitiale", dateDebutInitiale },
                { "datefin", absence.DateFin },
                { "idmotif", absence.Motif.IdMotif }
            };
            
            _access.Manager.ReqUpdate(
                "update absence " +
                "set idpersonnel = @idpersonnel, " +
                "datedebut = @datedebut, " +
                "datefin = @datefin, " +
                "idmotif = @idmotif " +
                "where idpersonnel = @idpersonnel and datedebut = @datedebutinitiale",
                requestParams);
        }
        
        /// <summary>
        /// Méthode pour supprimer une absence d'un personnel dans la base de données
        /// </summary>
        /// <param name="absence">L'absence concernée</param>
        /// <exception cref="MySqlConnector.MySqlException">La requête vers la base de données a échoué</exception>
        public static void DeleteAbsence(Absence absence)
        {
            var requestParams = new Dictionary<string, object> {{ "idpersonnel", absence.Personnel.IdPersonnel }, { "datedebut", absence.DateDebut }};
            
            _access.Manager.ReqUpdate("delete from absence where idpersonnel = @idpersonnel and datedebut = @datedebut", requestParams);
        }
    }
}