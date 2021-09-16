using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricAgent.Models
{
    public class AllMetricsResponse
    {
        public List<MetricDto> Metrics { get; set; }
    }    
}
