using System.Collections.Generic;
using PersonnelManager.Model;

namespace PersonnelManager.DAL
{
    /// <summary>
    /// La classe d'accès aux personnels
    /// </summary>
    public static class PersonnelAccess
    {
        /// <summary>
        /// L'instance unique pour accéder à la base de données
        /// </summary>
        private static Access _access = Access.Instance;

        /// <summary>
        /// Méthode permettant de récupérer les personnels depuis la base de données
        /// </summary>
        /// <returns>La liste complète des personnels</returns>
        /// <exception cref="MySqlConnector.MySqlException">La requête vers la base de données a échoué</exception>
        public static List<Personnel> GetPersonnels()
        {
            var result = _access.Manager.ReqSelect(
                "select idpersonnel, personnel.nom, prenom, tel, mail, idservice from personnel");
            
            var personnels = new List<Personnel>(result.Count);
            foreach (object[] ligne in result)
                personnels.Add(new Personnel(
                    (int)ligne[0],
                    (string)ligne[1],
                    (string)ligne[2],
                    (string)ligne[3],
                    (string)ligne[4],
                    ServiceAccess.GetService((int)ligne[5])));

            return personnels;
        }

        /// <summary>
        /// Méthode pour mettre à jour les champs d'un personnel dans la base de données
        /// </summary>
        /// <param name="personnel">Le personnel à mettre à jour</param>
        /// <exception cref="MySqlConnector.MySqlException">La requête vers la base de données a échoué</exception>
        public static void UpdatePersonnel(Personnel personnel)
        {
            var requestParams = new Dictionary<string, object>
            {
                { "idpersonnel", personnel.IdPersonnel },
                { "nom", personnel.Nom },
                { "prenom", personnel.Prenom },
                { "tel", personnel.Telephone },
                { "mail", personnel.Mail },
                { "idservice", personnel.Service.IdService }
            };
            
            _access.Manager.ReqUpdate(
                "update personnel " +
                "set nom = @nom, " +
                "prenom = @prenom, " +
                "tel = @tel, " +
                "mail = @mail, " +
                "idservice = @idservice " +
                "where idpersonnel = @idpersonnel",
                requestParams);
        }

        /// <summary>
        /// Méthode pour ajouter un personnel dans la base de données
        /// </summary>
        /// <param name="personnel">Le personnel à ajouter</param>
        /// <exception cref="MySqlConnector.MySqlException">La requête vers la base de données a échoué</exception>
        public static void AddPersonnel(Personnel personnel)
        {
            var requestParams = new Dictionary<string, object>
            {
                { "idpersonnel", personnel.IdPersonnel },
                { "nom", personnel.Nom },
                { "prenom", personnel.Prenom },
                { "tel", personnel.Telephone },
                { "mail", personnel.Mail },
                { "idservice", personnel.Service.IdService }
            };
            
            _access.Manager.ReqUpdate(
                "insert into personnel " +
                "values(@idpersonnel, " +
                "@nom, " +
                "@prenom, " +
                "@tel, " +
                "@mail, " +
                "@idservice)",
                requestParams);
        }
        
        /// <summary>
        /// Méthode pour supprimer un personnel dans la base de données
        /// </summary>
        /// <param name="personnel">Le personnel à supprimer</param>
        /// <exception cref="MySqlConnector.MySqlException">La requête vers la base de données a échoué</exception>
        public static void DeletePersonnel(Personnel personnel)
        {
            var requestParams = new Dictionary<string, object> {{ "idpersonnel", personnel.IdPersonnel }};
            
            _access.Manager.ReqUpdate("delete from personnel where idpersonnel = @idpersonnel", requestParams);
        }
    }
}