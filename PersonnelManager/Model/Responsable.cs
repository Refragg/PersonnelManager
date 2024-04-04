namespace PersonnelManager.Model
{
    /// <summary>
    /// Classe représentant le compte responsable des personnels
    /// </summary>
    public class Responsable
    {
        /// <summary>
        /// Nom d'utilisateur du responsable
        /// </summary>
        public string Login { get; }
        
        /// <summary>
        /// Mot de passe (en clair) du responsable
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// Constructeur d'un responsable
        /// </summary>
        /// <param name="login">Le nom d'utilisateur de ce responsable</param>
        /// <param name="password">Le mot de passe (en clair) de ce responsable</param>
        public Responsable(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}