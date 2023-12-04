using GreenThumbDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumbDb.Database
{
    public class GardenRepository
    {
        private readonly GreenThumbDbContext _context;
        public GardenRepository(GreenThumbDbContext context)
        {
            _context = context;
        }




        public async Task<PlantModel?> GetById(int id)
        {
            return await _context.Plants.FindAsync(id);
        }

        public async Task Remove(int id)
        {
            PlantModel? plantToRemove = await GetById(id);
            if (plantToRemove != null)
            {
                _context.Remove(plantToRemove);
            }
        }
    }
}
