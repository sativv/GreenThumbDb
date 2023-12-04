using GreenThumbDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumbDb.Database
{
    internal class GardenPlantRepository
    {
        private readonly GreenThumbDbContext _context;

        public GardenPlantRepository(GreenThumbDbContext context)
        {
            _context = context;
        }




    }
}
