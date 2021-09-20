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
            CreateMap<DeleteDto, CpuEntity>();

            CreateMap<DotnetEntity, SelectDto>();
            CreateMap<CreateDto, DotnetEntity>();
            CreateMap<UpdateDto, DotnetEntity>();
            CreateMap<DeleteDto, DotnetEntity>();

            CreateMap<HddEntity, SelectDto>();
            CreateMap<CreateDto, HddEntity>();
            CreateMap<UpdateDto, HddEntity>();
            CreateMap<DeleteDto, HddEntity>();

            CreateMap<NetworkEntity, SelectDto>();
            CreateMap<CreateDto, NetworkEntity>();
            CreateMap<UpdateDto, NetworkEntity>();
            CreateMap<DeleteDto, NetworkEntity>();

            CreateMap<RamEntity, SelectDto>();
            CreateMap<CreateDto, RamEntity>();
            CreateMap<UpdateDto, RamEntity>();;
            CreateMap<DeleteDto, RamEntity>();;
        }
    }
}
