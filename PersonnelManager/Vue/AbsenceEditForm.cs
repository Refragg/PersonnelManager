using System.Windows.Forms;

namespace PersonnelManager.Vue
{
    public partial class AbsenceEditForm : Form
    {
        public AbsenceEditForm(bool isAdding = false)
        {
            InitializeComponent();
            Text = isAdding ? "Ajouter une absence" : "Modifier une absence";
            btnConfirm.Text = isAdding ? "Ajouter" : "Modifier";
        }
    }
}