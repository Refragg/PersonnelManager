namespace PersonnelManager.Model
{
    /// <summary>
    /// Classe correspond à la table 'motif' de la base de données
    /// </summary>
    public class Motif
    {
        /// <summary>
        /// L'identifiant du motif
        /// </summary>
        public int IdMotif { get; }
        
        /// <summary>
        /// La description du motif
        /// </summary>
        public string Libelle { get; }
        
        /// <summary>
        /// Constructeur pour un Motif
        /// </summary>
        /// <param name="idMotif">L'identifiant de ce motif</param>
        /// <param name="libelle">La description de ce motif</param>
        public Motif(int idMotif, string libelle)
        {
            IdMotif = idMotif;
            Libelle = libelle;
        }

        /// <summary>
        /// Méthode remplacée pour gérer l'affichage d'un motif d'absence
        /// </summary>
        /// <returns>Le nom du motif d'absence</returns>
        public override string ToString()
        {
            return Libelle;
        }
    }
}