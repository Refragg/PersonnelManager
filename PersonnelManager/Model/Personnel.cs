namespace PersonnelManager.Model
{
    /// <summary>
    /// Classe correspond à la table 'personnel' de la base de données
    /// </summary>
    public class Personnel
    {
        /// <summary>
        /// L'identifiant du personnel
        /// </summary>
        public int IdPersonnel { get; }

        /// <summary>
        /// Le nom de famille du personnel
        /// </summary>
        public string Nom { get; }
        
        /// <summary>
        /// Le prénom du personnel
        /// </summary>
        public string Prenom { get; }
        
        /// <summary>
        /// Le numéro de téléphone du personnel
        /// </summary>
        public string Telephone { get; }
        
        /// <summary>
        /// L'adresse mail du personnel
        /// </summary>
        public string Mail { get; }
        
        /// <summary>
        /// Le service auquel le personnel appartient
        /// </summary>
        public Service Service { get; }

        /// <summary>
        /// Le constructeur d'un personnel
        /// </summary>
        /// <param name="idPersonnel">L'identifiant de ce personnel</param>
        /// <param name="nom">Le nom de famille de ce personnel</param>
        /// <param name="prenom">Le prénom de ce personnel</param>
        /// <param name="telephone">Le numéro de téléphone de ce personnel</param>
        /// <param name="mail">L'adresse mail de ce personnel</param>
        /// <param name="service">Le service auquel ce personnel appartient</param>
        public Personnel(int idPersonnel, string nom, string prenom, string telephone, string mail, Service service)
        {
            IdPersonnel = idPersonnel;
            Nom = nom;
            Prenom = prenom;
            Telephone = telephone;
            Mail = mail;
            Service = service;
        }
    }
}