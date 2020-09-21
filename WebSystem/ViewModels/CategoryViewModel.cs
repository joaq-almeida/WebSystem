using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSystem.ViewModels
{
    public class CategoryViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
    }
}
