using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumbDb.Models
{
    public class GardenModel
    {
        [Key]
        public int GardenId { get; set; }
        public string Name { get; set; } = null!;
        public UserModel User { get; set; } = null!;

        public List<GardenModel> Garden { get; set; } = new();

    }
}
