using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheEnd.Models
{
    public class Course
    {
        public int id { get; set; }
        public string Name { get; set; }
        public uint Price { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string Img { get; set; }
    }
}
