using PersonnelManager.DAL;
using PersonnelManager.Model;

namespace PersonnelManager.Controller
{
    /// <summary>
    /// Controlleur gérant les requêtes de la classe ConnectionForm
    /// </summary>
    public class ConnectionFormController
    {
        /// <summary>
        /// Méthode permettant de valider les identifiants d'un utilisateur de l'application
        /// </summary>
        /// <param name="login">Le nom d'utilisateur de la personne à vérifier</param>
        /// <param name="password">Le mot de passe de l'utilisateur à vérifier</param>
        /// <returns>'true' si les identifiants sont valides, 'false' sinon</returns>
        public bool ValidationIdentifiants(string login, string password) => Access.ValidationIdentifiants(login, password);
    }
}