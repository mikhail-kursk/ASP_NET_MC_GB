﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricAgent.Models
{
    public class MetricDto
    {
        public DateTime Time { get; set; }
        public int Value { get; set; }
        public int Id { get; set; }
    }
}
