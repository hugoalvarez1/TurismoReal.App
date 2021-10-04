using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using TurismoReal.Utils.Utils;

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

        #region Account
        public async void Account()
        {
            try
            {
                string nombre = String.Empty, pass = String.Empty, username = String.Empty;
                this.Dispatcher.Invoke((Action)(() =>
                {
                    username = txtUsuario.Text;
                    pass = txtPassword.Password;

                }));

                if (!string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(pass))
                {
                    var userFilterObj = new UsuarioDTO();
                    userFilterObj.username = username;
                    userFilterObj.password = pass;
                    //Credenciales de acceso                    
                    //user: admin
                    //pass: Test@1234

                    //Enviamos el objeto al servicio
                    var userDb = UsuarioServiceModel.GetUsuarioByCredenciales(userFilterObj);

                    if (userDb.HasValue)
                    {
                        ContextoDAO.Id = userDb.Value.id;
                        ContextoDAO.UserName = userDb.Value.username;
                        ContextoDAO.Cargo = "Administrador";

                        this.Dispatcher.Invoke((Action)(() =>
                        {
                            // se instancia la clase para poder abrir la ventana secundaria
                            AppTurismoWindow app = new AppTurismoWindow();
                            app.Show();
                            //se oculta la ventana principal, asi pudemos obtener sus propiedades desde toda la app
                            MainWindow mainInstance = (MainWindow)Application.Current.MainWindow;
                            mainInstance.Hide();
                            //se limpian los input
                            txtUsuario.Text = string.Empty;
                            txtPassword.Password = string.Empty;
                        }));
                    }
                }
                //else
                //{
                //    this.Dispatcher.Invoke((Action)(() =>
                //    {
                //        modalWait.IsOpen = false;
                //        var bc = new BrushConverter();
                //        btnInfo.Background = (Brush)bc.ConvertFrom("#DA291C");
                //        dlLogin.IsOpen = true;
                //        winMsg.Text = "Existen campos sin ingresar";
                //    }));
                //}
            }
            catch (Exception ex)
            {
                LoggerUtils.WriteLog(GetType().Name,
                    MethodBase.GetCurrentMethod().Name,
                    "Error en la aplicación", ex);
            }
            finally
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    modalWait.IsOpen = false;
                }));
            }
        }
        #endregion

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

        private async void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string userName = string.Empty;
            string pass = string.Empty;

            try
            {
                CargarModalEspera();

                await Task.Run(() =>
                {
                    Account();
                });
            }
            catch (Exception ex)
            {
                LoggerUtils.WriteLog(GetType().Name,
                    MethodBase.GetCurrentMethod().Name,
                    "Error en la aplicación", ex);
            }
        }

        public void CargarModalEspera()
        {
            modalWait.IsOpen = true;
        }
    }
}
