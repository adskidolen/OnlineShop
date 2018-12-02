﻿using System;
using System.Collections.Generic;
using System.Text;

namespace KeepHome.Models
{
    public class Country
    {
        public Country()
        {
            this.Towns = new HashSet<Town>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Town> Towns{ get; set; }
    }
}
