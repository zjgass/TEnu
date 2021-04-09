using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Query
    {
        public bool Fuzzy { get; set; }

        public List<string> Queries { get; set; }
    }
}
