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
        public AddPlantWindow(UserModel user)
        {
            currentUser = user;
            InitializeComponent();
        }
        UserModel currentUser = new();

        private async void btnAddPlant_Click(object sender, RoutedEventArgs e)
        {


            string plantName = txtPlantName.Text;
            string instruction = txtPlantInfo.Text;

            if (string.IsNullOrEmpty(plantName))
            {
                MessageBox.Show("Please enter a plant name");

            }
            else if (string.IsNullOrEmpty(instruction))
            {
                MessageBox.Show("Please enter an instrutction");
            }
            else
            {

                using (GreenThumbDbContext context = new())
                {
                    GreenThumbUoW uow = new(context);

                    PlantModel newPlant = new()
                    {
                        Name = plantName,

                    };
                    await uow.plantRepository.AddPlant(newPlant);
                    await uow.Complete();

                    InstructionModel newInstruction = new()
                    {
                        Instruction = instruction,
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
    }
}
