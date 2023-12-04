using EntityFrameworkCore.EncryptColumn.Attribute;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumbDb.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; } = null!;

        [EncryptColumn]
        public string Password { get; set; } = null!;

        public GardenModel Garden { get; set; } = null!;
    }
}
