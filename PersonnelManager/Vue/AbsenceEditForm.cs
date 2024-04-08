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
        /// Représente un des champs d'une absence
        /// </summary>
        public enum AbsenceField
        {
            None,
            DateDebut,
            DateFin,
            Motif
        }
        
        /// <summary>
        /// Constructeur de la fenêtre
        /// </summary>
        /// <param name="absence">L'absence à éditer, s'il faut ajouter une absence, utilisez null</param>
        /// <param name="startField">Le champ a focus en premier</param>
        public AbsenceEditForm(Absence absence = null, AbsenceField startField = AbsenceField.None)
        {
            InitializeComponent();
            Text = absence == null ? "Ajouter une absence" : "Modifier une absence";
            btnConfirm.Text = absence == null ? "Ajouter" : "Modifier";
        }
    }
}