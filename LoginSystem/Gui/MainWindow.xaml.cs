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
using Bizz;

namespace Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Users User;   
        public MainWindow()
        {
            InitializeComponent();
            Users User = new Users();
        }

        private void Click_Adminitrator(object sender, RoutedEventArgs e)
        {
            //Convert.ToString(User.Groupflag) == "Administrator"
            if (true)
            {
                AdminitratorPanelWindow APW = new AdminitratorPanelWindow();
                APW.Show();
                this.Hide();
            }
            else
            { 
                MessageBox.Show("NO ACCESS!\nOnly Adminitrators are allowed in this Panel");
            }
        }

        private void Click_About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Class:\tAspit-Lab/Software Contruction\nTask:\tLogin System Template\nCreation Date:\t06/12-2017\nProgram Desiger:\tTheReaper666", " - About Us");
        }

        private void Click_Logout(object sender, RoutedEventArgs e)
        {
            LoginWindow LW = new LoginWindow();
            LW.Show();
            this.Close();
        }

        private void Click_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
