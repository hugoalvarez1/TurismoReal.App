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

namespace TurismoReal.App
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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


    }
}
