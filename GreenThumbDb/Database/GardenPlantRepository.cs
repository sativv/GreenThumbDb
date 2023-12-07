using GreenThumbDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumbDb.Database
{
    public class GardenPlantRepository
    {
        private readonly GreenThumbDbContext _context;

        public GardenPlantRepository(GreenThumbDbContext context)
        {
            _context = context;
        }

        public async Task AddGardenPlant(GardenPlantModel gardenPlantToAdd)
        {
            await _context.GardenPlants.AddAsync(gardenPlantToAdd);
        }

        public async Task<List<GardenPlantModel>> GetAllGardenPlants()
        {
            return await _context.GardenPlants.ToListAsync();
        }



        public async Task<GardenPlantModel?> GetById(int id)
        {
            return await _context.GardenPlants.FindAsync(id);
        }

    }
}
