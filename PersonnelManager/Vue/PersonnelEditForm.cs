using System.Windows.Forms;
using PersonnelManager.Model;

namespace PersonnelManager.Vue
{
    /// <summary>
    /// Fenêtre d'édition (ou d'addition) d'un personnel
    /// </summary>
    public partial class PersonnelEditForm : Form
    {
        /// <summary>
        /// Constructeur de la fenêtre
        /// </summary>
        /// <param name="personnel">Le personnel à éditer, s'il faut ajouter un personnel, utilisez null</param>
        public PersonnelEditForm(Personnel personnel = null)
        {
            InitializeComponent();
            Text = personnel == null ? "Ajouter un personnel" : "Modifier un personnel";
            btnConfirm.Text = personnel == null ? "Ajouter" : "Modifier";
        }
    }
}