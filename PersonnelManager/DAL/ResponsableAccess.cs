using System.Collections.Generic;
using PersonnelManager.Model;

namespace PersonnelManager.DAL
{
    /// <summary>
    /// La classe d'accès aux informations d'un responsable
    /// </summary>
    public static class ResponsableAccess
    {
        /// <summary>
        /// L'instance unique pour accéder à la base de données
        /// </summary>
        private static Access _access = Access.Instance;

        /// <summary>
        /// Méthode permettant de valider les identifiants d'un responsable
        /// </summary>
        /// <param name="responsable">Le responsable à qui il faut vérifier les identifiants</param>
        /// <returns>'true' si les identifiants sont valides, 'false' sinon</returns>
        /// <exception cref="MySqlConnector.MySqlException">La requête vers la base de données a échoué</exception>
        public static bool ValidationIdentifiants(Responsable responsable)
        {
            var requestParams = new Dictionary<string, object>
            {
                { "login", responsable.Login },
                { "pass", responsable.Password }
            };
            
            var result = _access.Manager.ReqSelect("select * from responsable where login = @login and pwd = SHA2(@pass, 256)", requestParams);

            return result.Count == 1;
        }
    }
}