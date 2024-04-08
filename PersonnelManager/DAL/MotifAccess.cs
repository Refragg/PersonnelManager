using System.Collections.Generic;
using PersonnelManager.Model;

namespace PersonnelManager.DAL
{
    /// <summary>
    /// La classe d'accès aux motifs d'absences
    /// </summary>
    public class MotifAccess
    {
        /// <summary>
        /// L'instance unique pour accéder à la base de données
        /// </summary>
        private static Access _access = Access.Instance;

        /// <summary>
        /// Méthode permettant de récupérer les motifs d'absence depuis la base de données
        /// </summary>
        /// <returns>La liste complète des motifs d'absence</returns>
        /// <exception cref="MySqlConnector.MySqlException">La requête vers la base de données a échoué</exception>
        public static List<Motif> GetMotifs()
        {
            var result = _access.Manager.ReqSelect("select * from motif");
            
            var motifs = new List<Motif>();
            foreach (object[] motif in result)
                motifs.Add(new Motif((int)motif[0], (string)motif[1]));

            return motifs;
        }
        
        /// <summary>
        /// Méthode permettant de récupérer un motif d'absence précis depuis son ID dans la base de données
        /// </summary>
        /// <param name="idMotif">L'ID du motif d'absence à récupérer</param>
        /// <returns>Le motif d'absence en question</returns>
        /// <exception cref="MySqlConnector.MySqlException">La requête vers la base de données a échoué</exception>
        public static Motif GetMotif(int idMotif)
        {
            var result = _access.Manager.ReqSelect(
                "select idmotif, libelle from motif where idmotif = @idmotif",
                new Dictionary<string, object> { { "idmotif", idMotif } });

            var rawMotif = result[0];

            return new Motif((int)rawMotif[0], (string)rawMotif[1]);
        }
    }
}