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
        public PlantRepository plantRepository { get; }
        public GardenRepository gardenRepository { get; }
        public UserRepository userRepository { get; }

        public GreenThumbUoW(GreenThumbDbContext context)
        {
            _context = context;

            plantRepository = new(context);
            gardenRepository = new(context);
            userRepository = new(context);
        }

        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }
    }

}

