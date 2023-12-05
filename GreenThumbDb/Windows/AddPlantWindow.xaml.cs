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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GreenThumbDb.Windows
{
    /// <summary>
    /// Interaction logic for AddPlantWindow.xaml
    /// </summary>
    public partial class AddPlantWindow : Window
    {

        List<string> instructionStrings = new();
        public AddPlantWindow(UserModel user)
        {
            currentUser = user;
            InitializeComponent();



        }




        UserModel currentUser = new();

        private async void btnAddPlant_Click(object sender, RoutedEventArgs e)
        {


            string plantName = txtPlantName.Text;


            if (string.IsNullOrEmpty(plantName))
            {
                MessageBox.Show("Please enter a plant name");

            }
            else if (instructionStrings.Count == 0)
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


                    foreach (var instructionString in instructionStrings)
                    {

                        InstructionModel newInstruction = new()
                        {
                            Instruction = instructionString,
                            plantId = newPlant.PlantId
                        };
                        await uow.instructionRepository.AddInstruction(newInstruction);
                        await uow.Complete();

                        newPlant.instructionId = newInstruction.InstructionId;
                        await uow.Complete();
                    }





                    MessageBox.Show($"{newPlant.Name} has been added!");
                    PlantWindow plantWindow = new(currentUser);
                    plantWindow.Show();
                    Close();

                }

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
            lstPlantInstructionsAdded.Items.Clear();
            string instructionString = txtInstruction.Text;
            instructionStrings.Add(instructionString);

            foreach (var instruction in instructionStrings)
            {
                ListViewItem item = new();
                item.Tag = instruction;
                item.Content = instruction;
                lstPlantInstructionsAdded.Items.Add(item);
                txtInstruction.Text = "";
            }




        }
    }
}

