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
        /// Méthode permettant de valider les identifiants d'un responsable
        /// </summary>
        /// <param name="responsable">Le responsable à qui il faut vérifier les identifiants</param>
        /// <returns>'true' si les identifiants sont valides, 'false' sinon</returns>
        public bool ValidationIdentifiants(Responsable responsable) => ResponsableAccess.ValidationIdentifiants(responsable);
    }
}