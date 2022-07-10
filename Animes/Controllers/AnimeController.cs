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

        public FrutaController(FrutaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaFruta([FromBody] CreateFrutaDto frutaDto)
        {
            Fruta fruta = _mapper.Map<Fruta>(frutaDto);

            _context.Frutas.Add(fruta);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFrutasPorId), new { Id = fruta.Id }, fruta);
        }

        [HttpGet]
        public IEnumerable<Fruta> RecuperaFrutas()
        {
            return _context.Frutas;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFrutasPorId(int id)
        {
            Fruta fruta = _context.Frutas.FirstOrDefault(fruta => fruta.Id == id);
            if (fruta != null)
            {
                ReadFrutaDto frutaDto = _mapper.Map<ReadFrutaDto>(fruta);
                return Ok(frutaDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFruta(int id, [FromBody] UpdateFrutaDto frutaDto)
        {
            Fruta fruta = _context.Frutas.FirstOrDefault(fruta => fruta.Id == id);
            if (fruta == null)
            {
                return NotFound();
            }
            _mapper.Map(frutaDto, fruta);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFruta(int id)
        {
            Fruta fruta = _context.Frutas.First(fruta => fruta.Id == id);
            if (fruta == null)
            {
                return NotFound();
            }
            _context.Remove(fruta);
            _context.SaveChanges();
            return NoContent();
        }
}
