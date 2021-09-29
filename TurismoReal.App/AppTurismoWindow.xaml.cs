using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TurismoReal.DataAccess.Entities;

namespace TurismoReal.App
{
    /// <summary>
    /// Interaction logic for AppTurismoWindow.xaml
    /// </summary>
    public partial class AppTurismoWindow : Window
    {
        string userSession = ContextoDAO.UserName;
        string userCargo = ContextoDAO.Cargo;

        public AppTurismoWindow()
        {
            InitializeComponent();

            txtWelcome.Text = string.Format("Bienvenido {0} - {1}", userSession, userCargo);
        }
    }
}
