using AutoMapper;
using MovieApi.Dtos;
using MovieApi.Models;

namespace MovieApi.Profiles
{
    public class SessionProfile : Profile
    {
        public SessionProfile()
        {
            CreateMap<CreateSessionDto, Session>();
            CreateMap<Session, ReadSessionDto>();
        }
    }
}
