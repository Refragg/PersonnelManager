namespace PersonnelManager.Model
{
    /// <summary>
    /// Classe correspond à la table 'service' de la base de données
    /// </summary>
    public class Service
    {
        /// <summary>
        /// L'identifiant du service
        /// </summary>
        public int IdService { get; }
        
        /// <summary>
        /// Le nom du service
        /// </summary>
        public string Nom { get; }

        /// <summary>
        /// Constructeur d'un service
        /// </summary>
        /// <param name="idService">L'identifiant de ce service</param>
        /// <param name="nom">Le nom de ce service</param>
        public Service(int idService, string nom)
        {
            IdService = idService;
            Nom = nom;
        }

        /// <summary>
        /// Méthode remplacée pour gérer l'affichage d'un service
        /// </summary>
        /// <returns>Le nom de ce service</returns>
        public override string ToString() => Nom;
    }
}