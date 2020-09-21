using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebSystem.Models
{
    public class Ticket
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public int CreatedById { get; set; }
        public virtual IdentityUser CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public int ModifiedById { get; set; }
        public virtual IdentityUser ModifiedBy { get; set; }
        public DateTime Modified { get; set; }
    }
}
