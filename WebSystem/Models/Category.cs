using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebSystem.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string CreatedById { get; set; }
        public virtual IdentityUser CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public virtual IdentityUser ModifiedBy { get; set; }
        public string ModifiedById { get; set; }
    }
}
