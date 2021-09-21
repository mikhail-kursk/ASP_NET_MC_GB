using System;
using System.Collections.Generic;
using System.Text;

namespace MetricAgent.Entityes
{
    public class HddEntity : BaseEntity
    {
        public int Value { get; set; }
        public DateTime Time { get; set; }
    }
}
