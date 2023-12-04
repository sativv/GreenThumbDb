using GreenThumbDb.Database;
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
    /// Interaction logic for AddPlantWindow.xaml
    /// </summary>
    public partial class AddPlantWindow : Window
    {
        List<InstructionModel> instructions = new();
        public AddPlantWindow(UserModel user)
        {
            currentUser = user;
            InitializeComponent();

            FillListView();
            FillSecondListView();
        }




        UserModel currentUser = new();

        private async void btnAddPlant_Click(object sender, RoutedEventArgs e)
        {


            string plantName = txtPlantName.Text;


            if (string.IsNullOrEmpty(plantName))
            {
                MessageBox.Show("Please enter a plant name");

            }
            else if (instructions.Count == 0)
            {
                MessageBox.Show("Please enter an instruction");
            }
            else
            {

                using (GreenThumbDbContext context = new())
                {
                    GreenThumbUoW uow = new(context);
                    var plantList = await uow.plantRepository.GetAllPlants();

                    foreach (var plant in plantList)
                    {
                        if (plant.Name == plantName)
                        {
                            MessageBox.Show("That plant already exists in the database");
                            return;
                        }
                    }




                    PlantModel newPlant = new()
                    {
                        Name = plantName,

                    };
                    await uow.plantRepository.AddPlant(newPlant);
                    await uow.Complete();

                    // ADD AN INSTRUCTION FOR EACH ITEM IN LISTVIEW

                    InstructionModel newInstruction = new()
                    {

                        plantId = newPlant.PlantId
                    };

                    await uow.instructionRepository.AddInstruction(newInstruction);
                    await uow.Complete();

                    newPlant.instructionId = newInstruction.InstructionId;
                    await uow.Complete();



                    MessageBox.Show($"{newPlant.Name} has been added!");
                    PlantWindow plantWindow = new(currentUser);
                    plantWindow.Show();
                    Close();

                }

            }


        }



        private async void FillListView()
        {

            using (GreenThumbDbContext context = new())
            {
                GreenThumbUoW uow = new(context);

                var instructionList = await uow.instructionRepository.GetAllInstructions();

                foreach (var instruction in instructionList)
                {
                    ListViewItem item = new();
                    item.Tag = instruction;
                    item.Content = instruction.Instruction;
                    lstInstructionsList.Items.Add(item);
                }
            }
        }
        private void FillSecondListView()
        {
            foreach (var instruction in instructions)
            {
                ListViewItem instructionItem = new();
                instructionItem.Tag = instruction;
                instructionItem.Content = instruction.Instruction;
                lstPlantInstructionsAdded.Items.Add(instructionItem);
            }
        }
        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            PlantWindow plantWindow = new(currentUser);
            plantWindow.Show();
            Close();
        }

        private void btnAddInstruction_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem itemToAdd = (ListViewItem)lstInstructionsList.SelectedItem;
            if (itemToAdd != null)
            {
                InstructionModel instructionToAdd = (InstructionModel)itemToAdd.Tag;
                instructions.Add(instructionToAdd);

            }
            FillSecondListView();

        }
    }
}

