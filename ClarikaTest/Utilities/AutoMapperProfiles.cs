using AutoMapper;
using ClarikaTest.Models;

namespace ClarikaTest.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Members, ClarikaTest.DataAccess.Domain.Models.Members>().ReverseMap();
            CreateMap<Tweets, ClarikaTest.DataAccess.Domain.Models.Tweets>().ReverseMap();
        }
    }
}
