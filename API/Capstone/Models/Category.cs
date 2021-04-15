using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return this.CategoryId == ((Category)obj).CategoryId;
        }
    }
}
