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
            if (Convert.ToString(User.Groupflag) == "Administrator")
            {
                AdminitratorPanelWindow APW = new AdminitratorPanelWindow();
                APW.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("NO ACCESS!, Only Adminitrators are allowed in this Panel");
            }
        }

        private void Click_About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Text - Description"," - About Us");
        }
    }
}
