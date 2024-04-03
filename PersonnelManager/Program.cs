using System;
using System.Windows.Forms;
using PersonnelManager.Vue;

namespace PersonnelManager
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée de l'application
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ConnectionForm());
        }
    }
}