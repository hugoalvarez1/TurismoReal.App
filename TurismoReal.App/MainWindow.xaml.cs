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

        internal void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);

            if (screen != null)
            {
                PanelMain.Children.Clear();
                PanelMain.Children.Add(screen);                
            }
        }        

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            UserControlLogin screen = new UserControlLogin();
            if (screen != null)
            {
                PanelMain.Children.Clear();
                PanelMain.Children.Add(screen);
            }
        }
    }
}
