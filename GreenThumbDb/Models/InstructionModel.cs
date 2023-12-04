using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumbDb.Models
{
    public class InstructionModel
    {

        [Key]
        public int InstructionId { get; set; }
        public string Instruction { get; set; } = null!;

        public int plantId { get; set; }
        public PlantModel Plant { get; set; } = null!;
    }
}
