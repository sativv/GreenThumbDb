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
    /// Interaction logic for MyGardenWindow.xaml
    /// </summary>

    public partial class MyGardenWindow : Window
    {

        public MyGardenWindow(UserModel user)
        {
            InitializeComponent();
            currentUser = user;
        }

        public UserModel currentUser { get; }

        private void btnBrowsePlants_Click(object sender, RoutedEventArgs e)
        {
            PlantWindow plantWindow = new PlantWindow(currentUser);
            plantWindow.Show();
            Close();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem itemToRemove = (ListViewItem)lstPlantList.SelectedItem;

            using (GreenThumbDbContext context = new())
            {
                GreenThumbUoW uow = new(context);

                if (itemToRemove != null)
                {

                }
            }


        }

        private void lstPlantList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstPlantList.SelectedIndex != -1)
            {
                btnRemove.Visibility = Visibility.Visible;

            }
            else
            {
                btnRemove.Visibility = Visibility.Hidden;
            }
        }
    }
}
