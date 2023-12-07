using GreenThumbDb.Database;
using GreenThumbDb.Managers;
using GreenThumbDb.Models;
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

namespace GreenThumbDb.Windows
{
    /// <summary>
    /// Interaction logic for SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {

        public SignInWindow()
        {
            InitializeComponent();
        }


        // reads the username and password textboes. First checks if username exists in the list of users and then checks if password is correct
        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            btnLogin.IsEnabled = false;
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            bool loginSucess = false;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a username");
            }
            else if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter a password");
            }
            else
            {
                using (GreenThumbDbContext context = new())
                {
                    GreenThumbUoW uow = new(context);

                    var userList = await uow.userRepository.GetAllUsers();


                    foreach (UserModel user in userList)
                    {
                        if (user.Username == username && user.Password == password)
                        {

                            MyGardenWindow myGardenWindow = new(user);
                            MessageBox.Show($"Welcome {user.Username}!");
                            myGardenWindow.Show();
                            loginSucess = true;

                            Close();

                        }
                        else if (user.Username == username && user.Password != password)
                        {
                            MessageBox.Show("Incorrect password");
                            btnLogin.IsEnabled = true;
                            return;
                        }
                    }
                    if (!loginSucess)
                    {


                        MessageBox.Show("That username does not exist");
                        btnLogin.IsEnabled = true;
                        return;
                    }
                }
            }
            btnLogin.IsEnabled = true;
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }
    }
}
