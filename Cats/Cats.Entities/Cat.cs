using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cats.Entities
{
    public class Cat
    {
        public int ID  { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string WebSite { get; set; }
    }
}
