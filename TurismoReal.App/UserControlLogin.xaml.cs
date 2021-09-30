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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TurismoReal.DataAccess;
using TurismoReal.DataAccess.Entities;
using TurismoReal.DataAccess.Services;
using MySql.Data.MySqlClient;

namespace TurismoReal.App
{
    /// <summary>
    /// Interaction logic for UserControlLogin.xaml
    /// </summary>
    public partial class UserControlLogin : UserControl
    {
        private IUsuarioServices UsuarioServiceModel 
        {
            get 
            {
                return UsuarioServices.GetInstance();
            
            }
        }
        public UserControlLogin()
        {
            InitializeComponent();
            //MainWindow mainInstance = (MainWindow)Application.Current.MainWindow;
            //mainInstance.imgBackground.Opacity = 0;                   
        }

        private void txtPassword_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void ShowPassword_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowPasswordFunction();

        }

        private void ShowPassword_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            HidePasswordFunction();

        }

        private void ShowPassword_MouseLeave(object sender, MouseEventArgs e)
        {
            HidePasswordFunction();

        }

        private void ShowPasswordFunction()
        {
            if (txtPassword.Password != "")
            {
                PasswordUnmask.Visibility = Visibility.Visible;
                PasswordUnmask.Text = String.Format("Su Contraseña es: {0}", txtPassword.Password);
                OpenEye.Kind = MaterialDesignThemes.Wpf.PackIconKind.EyeOff;
                var bc = new BrushConverter();
                OpenEye.Foreground = (Brush)bc.ConvertFrom("#FFFFFF");
            }
        }

        private void HidePasswordFunction()
        {
            PasswordUnmask.Visibility = Visibility.Hidden;
            txtPassword.Visibility = Visibility.Visible;
            OpenEye.Kind = MaterialDesignThemes.Wpf.PackIconKind.Eye;
            var bc = new BrushConverter();
            OpenEye.Foreground = (Brush)bc.ConvertFrom("#FFFFFF");
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string userName = string.Empty;
            string pass = string.Empty;
            
            //cadena de conexion
            MySqlConnection conectar = new MySqlConnection("server=hosteldatabase.mysql.database.azure.com; database= hostel; Uid= hostel@hosteldatabase; pwd=hotel1234!;");
            conectar.Open();
            MySqlCommand codigo = new MySqlCommand();
            MySqlConnection conectarse = new MySqlConnection();
            codigo.Connection = conectar;

            codigo.CommandText = ("select * from admin where username ='" + txtUsuario.Text + "'and password = '" + txtPassword.Password + "' ");
            MySqlDataReader leer = codigo.ExecuteReader();
            if (leer.Read())
            {

                MessageBox.Show("Bienvenido");

            }
            else 
            {
                MessageBox.Show("Usuario o contraseña incorrecta");
            }
            
            try
            {
                userName = txtUsuario.Text; 
                pass = txtPassword.Password;

                // obtener al usuario que se logeo en la app, y si existe enviarlo a la sgte visto sino enviarle un mensaje de usuario invaliso
                // tarea poner mensaje de rellenar textos


                if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(pass))
                {
                    ContextoDAO.UserName = userName;
                    ContextoDAO.Cargo = "Administrador";
                    UsuarioServiceModel.GetAllUsuario();
                    
                    AppTurismoWindow app = new AppTurismoWindow();
                    app.Show();

                    MainWindow mainInstance = (MainWindow)Application.Current.MainWindow;
                    mainInstance.Close();



                }
            }
            catch (Exception ex)
            {

            }
            conectar.Close();
        }
    }
}
