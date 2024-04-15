using AutoMapper;

namespace MovieApi.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<Cinema, ReadCinemaDto>().ForMember(cinemaDto =>
                cinemaDto.ReadAddressDto, opt => opt.MapFrom(cinema => cinema.Address));
            CreateMap<UpdateCinemaDto, Cinema>();
        }
    }
}
