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
using System.Windows.Media.Animation;
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
            FillListAsync();
        }

        PlantModel currentPlant = new();
        public UserModel currentUser { get; }


        // fills the listview with the current plants instructions
        private void FillListAsync()
        {
            using (GreenThumbDbContext context = new())
            {

                var instructionList = context.Instructions.Where(I => I.plantId == currentPlant.PlantId).ToList();

                foreach (var instruction in instructionList)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = instruction;
                    item.Content = instruction.Instruction;
                    lstInstructions.Items.Add(item);
                }
            }
        }

        // fills the textfield with the current plants name
        private void FillFieldsAsync()
        {

            txtPlantName.Text = currentPlant.Name;
        }
        // returns user to plant window
        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            PlantWindow plantWindow = new(currentUser);
            plantWindow.Show();
            Close();

        }

        // adds the current plant to the currently signed in users garden
        private async void btnAddToGarden_Click(object sender, RoutedEventArgs e)
        {


            using (GreenThumbDbContext context = new())
            {
                GreenThumbUoW uow = new(context);

                PlantModel plantToAdd = currentPlant;

                var currentUserGarden = context.Gardens.Where(g => g.UserId == currentUser.UserId).FirstOrDefault();

                int plant = currentPlant.PlantId;
                if (currentUserGarden == null)
                {
                    return;
                }

                GardenPlantModel gardenPlantModel = new()
                {
                    PlantId = plant,
                    GardenId = currentUserGarden.GardenId,
                };

                if (plantToAdd != null)
                {
                    await uow.gardenPlantRepository.AddGardenPlant(gardenPlantModel);


                    MessageBox.Show($"{plantToAdd.Name} was added to your garden!");

                }

                await uow.Complete();
            }
            MyGardenWindow gardenwindow = new(currentUser);
            gardenwindow.Show();
            Close();
        }
    }
}
