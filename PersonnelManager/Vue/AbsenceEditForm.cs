using System.Windows.Forms;
using PersonnelManager.Model;

namespace PersonnelManager.Vue
{
    /// <summary>
    /// Fenêtre d'édition (ou d'addition) d'une absence
    /// </summary>
    public partial class AbsenceEditForm : Form
    {
        /// <summary>
        /// Constructeur de la fenêtre
        /// </summary>
        /// <param name="absence">L'absence à éditer, s'il faut ajouter une absence, utilisez null</param>
        public AbsenceEditForm(Absence absence = null)
        {
            InitializeComponent();
            Text = absence == null ? "Ajouter une absence" : "Modifier une absence";
            btnConfirm.Text = absence == null ? "Ajouter" : "Modifier";
        }
    }
}