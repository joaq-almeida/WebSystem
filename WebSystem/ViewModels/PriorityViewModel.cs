using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSystem.Services
{
    public class PriorityViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
    }
}
