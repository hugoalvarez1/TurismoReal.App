using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using TurismoReal.App.ViewModel;
using TurismoReal.DataAccess.Entities;
using TurismoReal.Utils.Utils;

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

            var menuRegister = new List<SubItem>();
            menuRegister.Add(new SubItem("Crear Usuario", new UserControlCrearUsuario()));
            menuRegister.Add(new SubItem("Editar Usuario", new UserControlEditarUsuario()));           
            var item6 = new ItemMenu("Administración de Usuarios", menuRegister, PackIconKind.Register);

            var menuSchedule = new List<SubItem>();
            menuSchedule.Add(new SubItem("Services"));
            menuSchedule.Add(new SubItem("Meetings"));
            var item1 = new ItemMenu("Appointments", menuSchedule, PackIconKind.Schedule);

            var menuReports = new List<SubItem>();
            menuReports.Add(new SubItem("Customers"));
            menuReports.Add(new SubItem("Providers"));
            menuReports.Add(new SubItem("Products"));
            menuReports.Add(new SubItem("Stock"));
            menuReports.Add(new SubItem("Sales"));
            var item2 = new ItemMenu("Reportes", menuReports, PackIconKind.FileReport);

            var menuExpenses = new List<SubItem>();
            menuExpenses.Add(new SubItem("Fixed"));
            menuExpenses.Add(new SubItem("Variable"));
            var item3 = new ItemMenu("Expenses", menuExpenses, PackIconKind.ShoppingBasket);

            var menuFinancial = new List<SubItem>();
            menuFinancial.Add(new SubItem("Cash flow"));
            var item4 = new ItemMenu("Financial", menuFinancial, PackIconKind.ScaleBalance);

            Menu.Children.Add(new UserControlMenuItem(item6, this));
            Menu.Children.Add(new UserControlMenuItem(item1, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
            Menu.Children.Add(new UserControlMenuItem(item3, this));
            Menu.Children.Add(new UserControlMenuItem(item4, this));
        }

        internal void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);

            if (screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            ModalCerrarSesion.IsOpen = true;
            msgLogout.Text = String.Format("Hola {0}, {1} ¿Está seguro que desea cerrar su sesión actual?", ContextoDAO.UserName, Environment.NewLine);
        }

        private void BtnAceptarCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ContextoDAO.Id = 0;
                ContextoDAO.UserName = "";
                ContextoDAO.Cargo = "";
                ModalCerrarSesion.IsOpen = false;
                AppTurismoWindow mnw = new AppTurismoWindow();
                mnw.Owner = this;
                this.Hide(); // not required if using the child events below                       
                MainWindow signIn = (MainWindow)Application.Current.MainWindow;
                signIn.Show();
                mnw.Close();
            }
            catch (Exception ex)
            {                
                LoggerUtils.WriteLog(GetType().Name,
                    MethodBase.GetCurrentMethod().Name,
                    "Error en la aplicación", ex);
            }
        }
    }
}
