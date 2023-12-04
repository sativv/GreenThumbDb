using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumbDb.Database
{
    public class GreenThumbUoW
    {
        private readonly GreenThumbDbContext _context;

        public GreenThumbUoW(GreenThumbDbContext context)
        {
            _context = context;

        }

        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }
    }
}
