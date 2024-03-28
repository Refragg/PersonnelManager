using System.Windows.Forms;

namespace PersonnelManager.Vue
{
    public partial class PersonnelEditForm : Form
    {
        public PersonnelEditForm(bool isAdding = false)
        {
            InitializeComponent();
            Text = isAdding ? "Ajouter un personnel" : "Modifier un personnel";
            btnConfirm.Text = isAdding ? "Ajouter" : "Modifier";
        }
    }
}