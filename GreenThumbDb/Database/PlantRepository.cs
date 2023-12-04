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
    }
}
