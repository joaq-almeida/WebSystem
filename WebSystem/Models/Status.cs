using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSystem.Models
{
    public class Status
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public int CreatedById { get; set; }
        public DateTime Modified { get; set; }
        public int ModifiedById { get; set; }
    }
}
