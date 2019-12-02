﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace remotebash.web.Models
{
    public class Laboratory
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public List<Computer> ComputerSet { get; set; }
    }
}
