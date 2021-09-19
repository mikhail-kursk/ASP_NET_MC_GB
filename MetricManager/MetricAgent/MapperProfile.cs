using AutoMapper;
using MetricAgent.Dto;
using MetricAgent.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricAgent
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // добавлять сопоставления в таком стиле нужно для всех объектов 
            CreateMap<CpuEntity, SelectDto>();
            CreateMap<CreateDto, CpuEntity>();
            CreateMap<UpdateDto, CpuEntity>();
            CreateMap<long, CpuEntity>();

            CreateMap<DotnetEntity, SelectDto>();
            CreateMap<CreateDto, DotnetEntity>();
            CreateMap<UpdateDto, DotnetEntity>();
            CreateMap<long, DotnetEntity>();

            CreateMap<HddEntity, SelectDto>();
            CreateMap<CreateDto, HddEntity>();
            CreateMap<UpdateDto, HddEntity>();
            CreateMap<long, HddEntity>();

            CreateMap<NetworkEntity, SelectDto>();
            CreateMap<CreateDto, NetworkEntity>();
            CreateMap<UpdateDto, NetworkEntity>();
            CreateMap<long, NetworkEntity>();

            CreateMap<RamEntity, SelectDto>();
            CreateMap<CreateDto, RamEntity>();
            CreateMap<UpdateDto, RamEntity>();
            CreateMap<long, RamEntity>();
        }
    }
}
