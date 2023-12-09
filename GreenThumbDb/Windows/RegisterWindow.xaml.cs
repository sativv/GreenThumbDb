using GreenThumbDb.Database;
using GreenThumbDb.Models;
using System.Windows;

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


        // returns to the main window
        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }

        // reads input windows and registers user, checks if username is already taken. 
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
                    await uow.Complete();
                    GardenModel newGarden = new()
                    {
                        Name = "Garden of " + username,
                        UserId = newUser.UserId
                    };
                    await uow.gardenRepository.AddGarden(newGarden);


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
