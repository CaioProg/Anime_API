using Animes.Data;
using Animes.Data.Dtos;
using Animes.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace Animes.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AnimeController : ControllerBase
    {
        private AnimeContext _context;
        private IMapper _mapper;

        public AnimeController(AnimeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaAnime([FromBody] CreateAnimeDto animeDto)
        {
            Anime anime = _mapper.Map<Anime>(animeDto);

            _context.Animes.Add(anime);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaAnimesPorId), new { Id = anime.Id }, anime);
        }

        [HttpGet]
        public IEnumerable<Anime> RecuperaAnimes()
        {
            return _context.Animes;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaAnimesPorId(int id)
        {
            Anime anime = _context.Animes.FirstOrDefault(anime => anime.Id == id);
            if (anime != null)
            {
                ReadAnimeDto animeDto = _mapper.Map<ReadAnimeDto>(anime);
                return Ok(animeDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaAnime(int id, [FromBody] UpdateAnimeDto animeDto)
        {
            Anime anime = _context.Animes.FirstOrDefault(anime => anime.Id == id);
            if (anime == null)
            {
                return NotFound();
            }
            _mapper.Map(animeDto, anime);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaAnime(int id)
        {
            Anime anime = _context.Animes.First(anime => anime.Id == id);
            if (anime == null)
            {
                return NotFound();
            }
            _context.Remove(anime);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
