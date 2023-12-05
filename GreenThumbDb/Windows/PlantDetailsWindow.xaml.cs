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

            currentPlant = selectedPlant;

            InitializeComponent();
            FillFieldsAsync();
            FillListAsync();
        }

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

        private void FillFieldsAsync()
        {

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

        private async void btnAddToGarden_Click(object sender, RoutedEventArgs e)
        {
            PlantModel plantToAdd = currentPlant;

            var garden = currentUser.Garden.GardenId;




            using (GreenThumbDbContext context = new())
            {
                GreenThumbUoW uow = new(context);
                if (plantToAdd != null)
                {



                }
                MessageBox.Show($"{plantToAdd.Name} was added to your garden!");
                await uow.Complete();
            }
        }
    }
}
