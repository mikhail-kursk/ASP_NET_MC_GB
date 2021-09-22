using AutoMapper;
using MetricManager.Dto;
using MetricManager.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricManager
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // добавлять сопоставления в таком стиле нужно для всех объектов 
            CreateMap<AgentDto, AgentsEntity>();
        }
    }
}
