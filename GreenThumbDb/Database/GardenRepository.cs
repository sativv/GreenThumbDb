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
    }
}
