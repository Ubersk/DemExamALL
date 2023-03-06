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

namespace v0._2.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = Convert.ToString(LoginBox.Text);
            string password = Convert.ToString(PasswordBox.Text);
            if (login == "admin")
            {
                if (password == "admin")
                {
                    BaseWindow auth = new BaseWindow();
                    auth.Show();
                    this.Close();
                }
            }
        }
    }
}
