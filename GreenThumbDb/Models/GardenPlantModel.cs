using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumbDb.Models
{
    public class GardenPlantModel
    {

        public int GardenId { get; set; }
        public GardenModel Garden { get; set; } = null!;
        public int PlantId { get; set; }
        public PlantModel Plant { get; set; } = null!;
    }
}
