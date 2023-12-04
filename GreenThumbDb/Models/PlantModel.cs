using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace GreenThumbDb.Models
{
    public class PlantModel
    {
        [Key]
        public int PlantId { get; set; }
        public string Name { get; set; } = null!;

        public int instructionId { get; set; }
        public List<InstructionModel> Instructions { get; set; } = new();

        public List<GardenPlantModel> GardenPlant { get; set; } = new();
    }
}
