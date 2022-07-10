using Animes.Data.Dtos;
using Animes.Models;
using AutoMapper;

namespace Animes.Profiles
{
    public class AnimeProfile : Profile
    {
        public AnimeProfile()
        {
            CreateMap<CreateAnimeDto, Anime>();
            CreateMap<Anime, ReadAnimeDto>();
            CreateMap<UpdateAnimeDto, Anime>();
        }
    }
}
