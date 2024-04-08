using System;

namespace PersonnelManager.Model
{
    /// <summary>
    /// Classe correspond à la table 'absence' de la base de données
    /// </summary>
    public class Absence
    {
        /// <summary>
        /// Le personnel déclarant cette absence
        /// </summary>
        public Personnel Personnel { get; }
        
        /// <summary>
        /// La date de début de l'absence
        /// </summary>
        public DateTime DateDebut { get; set; }
        
        /// <summary>
        /// La date de fin de l'absence
        /// </summary>
        public DateTime DateFin { get; set; }
        
        /// <summary>
        /// Le motif associé à cette absence
        /// </summary>
        public Motif Motif { get; set; }

        /// <summary>
        /// Constructeur pour une absence
        /// </summary>
        /// <param name="personnel">Le personnel déclarant cette absence</param>
        /// <param name="dateDebut">La date de début de cette absence</param>
        /// <param name="dateFin">La date de fin de cette absence</param>
        /// <param name="motif">Le motif de cette absence</param>
        public Absence(Personnel personnel, DateTime dateDebut, DateTime dateFin, Motif motif)
        {
            Personnel = personnel;
            DateDebut = dateDebut;
            DateFin = dateFin;
            Motif = motif;
        }
    }
}