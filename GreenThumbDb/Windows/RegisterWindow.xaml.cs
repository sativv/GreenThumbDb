using GreenThumbDb.Database;
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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }

        private async void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;


            using (GreenThumbDbContext context = new())
            {
                GreenThumbUoW uow = new(context);
                var userList = await uow.userRepository.GetAllUsers();

                foreach (var user in userList)
                {
                    if (user.Username == username)
                    {
                        MessageBox.Show("Username already taken");
                        return;
                    }
                }

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
                    UserModel newUser = new()
                    {
                        Username
                    = username,
                        Password = password
                    };

                    await uow.userRepository.AddUser(newUser);

                    MessageBox.Show($"Welcome to Green Thumb Gardening {username}");
                    SignInWindow signInWindow = new SignInWindow();
                    signInWindow.Show();
                    Close();
                    await uow.Complete();

                }


            }
        }
    }
}
