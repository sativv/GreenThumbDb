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
    /// Interaction logic for PlantWindow.xaml
    /// </summary>
    public partial class PlantWindow : Window
    {
        public PlantWindow(UserModel user)
        {
            currentUser = user;
            InitializeComponent();
            FillListAsync();
        }

        UserModel currentUser = new();

        private async Task FillListAsync()
        {
            lstPlantList.Items.Clear();
            using (GreenThumbDbContext context = new GreenThumbDbContext())
            {
                GreenThumbUoW uow = new(context);

                var plantList = await uow.plantRepository.GetAllPlants();

                foreach (var plant in plantList)
                {
                    ListViewItem listViewItem = new();
                    listViewItem.Tag = plant;
                    listViewItem.Content = plant.Name;
                    lstPlantList.Items.Add(listViewItem);
                }
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {


        }

        private void txtSearchPlant_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchString = txtSearchPlant.Text;

            using (GreenThumbDbContext context = new GreenThumbDbContext())
            {
                GreenThumbUoW uow = new(context);

                var plantList = uow.plantRepository.GetAllPlants();


            }
        }


        private async void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem itemToRemove = (ListViewItem)lstPlantList.SelectedItem;

            using (GreenThumbDbContext context = new())
            {
                GreenThumbUoW uow = new(context);

                if (itemToRemove != null)
                {
                    PlantModel plantToRemove = (PlantModel)itemToRemove.Tag;
                    await uow.plantRepository.Remove(plantToRemove.PlantId);
                    await uow.Complete();
                    await FillListAsync();

                }
            }


        }


        private void lstPlantList_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            btnRemove.Visibility = Visibility.Visible;
        }

        private void btnPlantInfo_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = (ListViewItem)lstPlantList.SelectedItem;
            PlantModel selectedPlant = (PlantModel)selectedItem.Tag;
            PlantDetailsWindow plantDetailsWindow = new(currentUser, selectedPlant);
            plantDetailsWindow.Show();
            Close();
        }
    }
}
