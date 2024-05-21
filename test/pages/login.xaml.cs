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
using test.classes;

namespace test.pages
{
    /// <summary>
    /// Логика взаимодействия для login.xaml
    /// </summary>
    public partial class login : Page
    {
        public login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTxB.Text;
            string password = PasswordBox.Password;

            if (OdbConnect.AuntenticateUser(login, password))
            {
                MessageBox.Show("Аутентификация успешка");
                int role = OdbConnect.GetRole(login);

                switch (role)
                {
                    case 1:
                        FrameApp.frameObject.Navigate(new user());
                        break;
                    case 2:
                        FrameApp.frameObject.Navigate(new manager());
                        break;
                   
                        
                }
            }
        }
    }
}
