using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSystem.Models
{
    public enum Status: int
    {
        Active = 0,
        Closed = 1,
        Resolved = 2,
        Proposed = 3
    }
}
