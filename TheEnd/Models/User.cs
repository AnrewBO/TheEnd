using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheEnd.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; } // имя пользователя
        public string LastName { get; set; }
        public string Biograph { get; set; }
        public DateTime Year { get; set; } // возраст пользователя
    }
}
