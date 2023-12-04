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
    /// Interaction logic for PlantDetailsWindow.xaml
    /// </summary>
    public partial class PlantDetailsWindow : Window
    {
        public PlantDetailsWindow(UserModel user, PlantModel selectedPlant)
        {
            currentUser = user;
            currentPlant = selectedPlant;

            InitializeComponent();
            FillFieldsAsync();
        }

        private void FillFieldsAsync()
        {
            txtPlantInfo.Text = currentPlant.Instructions.ToString();
            txtPlantName.Text = currentPlant.Name;
        }
        PlantModel currentPlant = new();
        public UserModel currentUser { get; }
        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            PlantWindow plantWindow = new(currentUser);
            plantWindow.Show();
            Close();

        }

        private void btnAddToGarden_Click(object sender, RoutedEventArgs e)
        {
            PlantModel plantToAdd = currentPlant;

            using (GreenThumbDbContext context = new())
            {
                GreenThumbUoW uow = new(context);
            }
        }
    }
}
