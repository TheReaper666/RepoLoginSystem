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
using Bizz;

namespace Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        BizzFunctions BizzF;
        public LoginWindow()
        {
            InitializeComponent();
            BizzF = new BizzFunctions();

        }

        private void Login_click(object sender, RoutedEventArgs e)
        {
            
            if (BizzF.CheckCredentials(textBoxUsername.Text, textBoxPassword.Text))
            {

                MainWindow MW = new MainWindow();
                MW.Show();
                this.Close();
            }
        }
    }
}
