using GreenThumbDb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumbDb.Database
{
    public class PlantRepository
    {
        private readonly GreenThumbDbContext _context;
        public PlantRepository(GreenThumbDbContext context)
        {
            _context = context;
        }




        public async Task<List<PlantModel>> GetAllPlants()
        {
            return await _context.Plants.ToListAsync();
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


        public async Task AddPlant(PlantModel plantToAdd)
        {
            await _context.Plants.AddAsync(plantToAdd);
        }


    }
}
