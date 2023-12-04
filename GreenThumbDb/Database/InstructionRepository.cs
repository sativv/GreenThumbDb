using GreenThumbDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumbDb.Database
{
    public class InstructionRepository
    {
        private readonly GreenThumbDbContext _context;

        public InstructionRepository(GreenThumbDbContext context)
        {
            _context = context;
        }

        public async Task AddInstruction(InstructionModel instructionToAdd)
        {
            await _context.Instructions.AddAsync(instructionToAdd);
        }

        public async Task<List<InstructionModel>> GetAllInstructions()
        {
            return await _context.Instructions.ToListAsync();
        }
    }
}
