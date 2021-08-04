using System;
using System.Security.Policy;
using AutoMapper;
using MetricsManager.DAL.Models;
using MetricsManager.Responses;

namespace MetricsManager
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        { 
            CreateMap<CpuMetric, CpuMetricDto>().ForMember(dest => dest.Time, opt => opt
                .MapFrom(orig => DateTimeOffset.FromUnixTimeSeconds(orig.Time))); ;
            CreateMap<DotNetMetric, DotNetMetricDto>().ForMember(dest => dest.Time, opt => opt
                .MapFrom(orig => DateTimeOffset.FromUnixTimeSeconds(orig.Time))); ;
            CreateMap<HddMetric, HddMetricDto>().ForMember(dest => dest.Time, opt => opt
                .MapFrom(orig => DateTimeOffset.FromUnixTimeSeconds(orig.Time))); ;
            CreateMap<NetworkMetric, NetworkMetricDto>().ForMember(dest => dest.Time, opt => opt
                .MapFrom(orig => DateTimeOffset.FromUnixTimeSeconds(orig.Time))); ;
            CreateMap<RamMetric, RamMetricDto>().ForMember(dest => dest.Time, opt => opt
                .MapFrom(orig => DateTimeOffset.FromUnixTimeSeconds(orig.Time))); ;
            CreateMap<AgentInfo, AgentInfoDto>().ForMember(dest => dest.Address, opt => opt
                .MapFrom(orig => new Url(orig.Address)));
        }
    }
}
