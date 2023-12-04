using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumbDb.Models
{
    public class PlantModel
    {
        [Key]
        public int PlantId { get; set; }
        public string Name { get; set; } = null!;
        public InstructionModel Instruction { get; set; } = null!;

        public GardenModel MyProperty { get; set; }
    }
}
