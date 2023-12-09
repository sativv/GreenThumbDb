using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using GreenThumbDb.Managers;
using GreenThumbDb.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenThumbDb.Database
{
    public class GreenThumbDbContext : DbContext
    {
        private readonly IEncryptionProvider _provider;

        public GreenThumbDbContext()
        {
            _provider = new GenerateEncryptionProvider(KeyManager.GetEncryptionKey());
        }

        public DbSet<GardenModel> Gardens { get; set; }
        public DbSet<InstructionModel> Instructions { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<PlantModel> Plants { get; set; }
        public DbSet<GardenPlantModel> GardenPlants { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GardenPlantModel>().HasKey(gp => new { gp.PlantId, gp.GardenId });

            modelBuilder.UseEncryption(_provider);

            modelBuilder.Entity<UserModel>().HasData(new UserModel
            {
                UserId = 1,
                Username = "david",
                Password = "david"
            });


            modelBuilder.Entity<GardenModel>().HasData(new GardenModel
            {
                UserId = 1,
                GardenId = 1,
                Name = "garden of david"
            });



            modelBuilder.Entity<PlantModel>().HasData(new PlantModel
            {
                PlantId = 1,
                Name = "Sunshine Succulent",
                instructionId = 1
            }, new PlantModel
            {
                PlantId = 2,
                Name = "Mystic Moonflower",
                instructionId = 2
            }, new PlantModel
            {
                PlantId = 3,
                Name = "Zen Zephyr Orchid",
                instructionId = 3
            }, new PlantModel
            {
                PlantId = 4,
                Name = "Crimson Cascade Fern",
                instructionId = 4
            },
            new PlantModel
            {
                PlantId = 5,
                Name = "Azure Breeze Bluebell",
                instructionId = 5
            }, new PlantModel
            {
                PlantId = 6,
                Name = "Silver Serenity Sage",
                instructionId = 6
            }, new PlantModel
            {
                PlantId = 7,
                Name = "Velvet Violet Verbena",
                instructionId = 7
            },
            new PlantModel
            {
                PlantId = 8,
                Name = "Emerald Echo Eucalyptus",
                instructionId = 8
            }, new PlantModel
            {
                PlantId = 9,
                Name = "Golden Glow Gazania",
                instructionId = 9
            },
            new PlantModel
            {
                PlantId = 10,
                Name = "Rustic Rosemary Radiance",
                instructionId = 10
            }
            );



            modelBuilder.Entity<InstructionModel>().HasData(new InstructionModel
            {
                InstructionId = 1,
                Instruction = "Place in a sunny spot and water sparingly to keep this desert beauty thriving",
                plantId = 1,

            },
            new InstructionModel
            {
                InstructionId = 2,
                Instruction = "Plant in well-draining soil and water in the evening for enchanting blooms under the moonlight.",
                plantId = 2


            }, new InstructionModel
            {
                InstructionId = 3,
                Instruction = "Provide high humidity and a peaceful environment for this orchid to flourish; avoid direct sunlight.",
                plantId = 3

            }, new InstructionModel
            {
                InstructionId = 4,
                Instruction = "Keep the soil consistently moist and mist the fern regularly to maintain its lush, cascading fronds.",
                plantId = 4
            }, new InstructionModel
            {
                InstructionId = 5,
                Instruction = "Plant in a cool, shaded area and water regularly for a burst of blue blooms in the spring.",
                plantId = 5
            }, new InstructionModel
            {
                InstructionId = 6,
                Instruction = "Trim regularly for bushier growth and plant in well-draining soil to prevent waterlogging.",
                plantId = 6
            }, new InstructionModel
            {
                InstructionId = 7,
                Instruction = " Allow the soil to dry between watering, and place in a sunny location to enjoy the vibrant violet blossoms.",
                plantId = 7
            }, new InstructionModel
            {
                InstructionId = 8,
                Instruction = "Provide ample sunlight and well-draining soil; prune occasionally for a bushier appearance and enhanced aroma.",
                plantId = 8
            }, new InstructionModel
            {
                InstructionId = 9,
                Instruction = "Plant in a sunny spot with good drainage and water sparingly to enjoy the radiant golden blooms.",
                plantId = 9
            }, new InstructionModel
            {
                InstructionId = 10,
                Instruction = "Thrives in well-draining soil and prefers drier conditions; trim regularly for a fragrant and compact rosemary bush.",
                plantId = 10
            }, new InstructionModel
            {
                InstructionId = 11,
                Instruction = "Place in indirect sunlight and water thoroughly, allowing the soil to dry between waterings for optimal growth.",
                plantId = 1
            },
    new InstructionModel
    {
        InstructionId = 12,
        Instruction = "Create a humid environment and provide filtered sunlight to promote healthy, vibrant foliage for this tropical beauty.",
        plantId = 2
    },
    new InstructionModel
    {
        InstructionId = 13,
        Instruction = "Water moderately and place in a location with bright, indirect light for stunning and long-lasting blooms.",
        plantId = 3
    },
    new InstructionModel
    {
        InstructionId = 14,
        Instruction = "Plant in nutrient-rich soil and water consistently to encourage the growth of flavorful and aromatic herbs.",
        plantId = 4
    },
    new InstructionModel
    {
        InstructionId = 15,
        Instruction = "Provide well-draining soil and ample sunlight, and water sparingly to maintain the distinctive shape of this succulent.",
        plantId = 5
    },
    new InstructionModel
    {
        InstructionId = 16,
        Instruction = "Place in a sunny location and water regularly, allowing the soil to dry slightly between waterings for optimal health.",
        plantId = 6
    },
    new InstructionModel
    {
        InstructionId = 17,
        Instruction = "Create a trellis for support, plant in full sun, and water consistently to cultivate a thriving and productive vine.",
        plantId = 7
    },
    new InstructionModel
    {
        InstructionId = 18,
        Instruction = "Ensure well-draining soil and provide bright, indirect light for this delicate fern to flourish in a controlled environment.",
        plantId = 8
    },
    new InstructionModel
    {
        InstructionId = 19,
        Instruction = "Water moderately and place in a location with filtered sunlight to encourage the growth of lush and colorful leaves.",
        plantId = 9
    },
    new InstructionModel
    {
        InstructionId = 20,
        Instruction = "Plant in a spacious container with rich soil, water consistently, and provide ample sunlight for robust and healthy growth.",
        plantId = 10
    });
        }









        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GreenThumbDb;trusted_connection=true");


        }
    }
}






