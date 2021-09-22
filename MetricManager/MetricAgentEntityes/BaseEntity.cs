using System;

namespace MetricAgent.Entityes
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public int Value { get; set; }
        public DateTime Time { get; set; }
    }
}
