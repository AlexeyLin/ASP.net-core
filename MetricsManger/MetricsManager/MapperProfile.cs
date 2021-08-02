using System;
using AutoMapper;
using MetricsAgent.DAL.Models;
using MetricsAgent.Responses;

namespace MetricsAgent
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
        }
    }
}
