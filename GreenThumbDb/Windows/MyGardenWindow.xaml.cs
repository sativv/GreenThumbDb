﻿using GreenThumbDb.Database;
using GreenThumbDb.Models;
using Microsoft.EntityFrameworkCore;
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
            FillList();
        }

        // fills the listview with every item from the gardenplant joint table where userid is the same as current logged in user id
        private void FillList()
        {
            lstPlantList.Items.Clear();
            using (GreenThumbDbContext context = new())
            {
                GreenThumbUoW uow = new(context);

                var gardenPlantList = context.GardenPlants.Include(g => g.Garden).Include(g => g.Plant).Where(gp => gp.Garden.UserId == currentUser.UserId).ToList();

                foreach (var gp in gardenPlantList)
                {
                    ListViewItem gpItem = new ListViewItem();
                    gpItem.Tag = gp;
                    gpItem.Content = gp.Plant.Name;
                    lstPlantList.Items.Add(gpItem);
                }
            }
        }

        public UserModel currentUser { get; }

        // sends user to the plantWindow
        private void btnBrowsePlants_Click(object sender, RoutedEventArgs e)
        {
            PlantWindow plantWindow = new PlantWindow(currentUser);
            plantWindow.Show();
            Close();
        }


        // sends the selected listviewitem (plant) to the plantDetailsWindow and opens it

        private void btnPlantInfo_Click(object sender, RoutedEventArgs e)
        {
            if (lstPlantList.SelectedItem != null)
            {
                ListViewItem selectedItem = (ListViewItem)lstPlantList.SelectedItem;
                GardenPlantModel selectedPlant = (GardenPlantModel)selectedItem.Tag;
                PlantModel plant = selectedPlant.Plant;
                PlantDetailsWindow plantDetailsWindow = new(currentUser, plant);
                plantDetailsWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Please select a plant");
            }
        }

        private void lstPlantList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnRemove.Visibility = Visibility.Visible;
        }

        private async void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem itemToRemove = (ListViewItem)lstPlantList.SelectedItem;

            using (GreenThumbDbContext context = new())
            {
                GreenThumbUoW uow = new(context);

                if (itemToRemove != null)
                {
                    GardenPlantModel gardenPlantToRemove = (GardenPlantModel)itemToRemove.Tag;

                    await uow.gardenPlantRepository.Remove(gardenPlantToRemove);
                    await uow.Complete();
                    FillList();
                }
            }
        }
    }
}
