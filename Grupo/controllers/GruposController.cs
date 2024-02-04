using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sl.GrupoAPI.Data;
using Sl.GrupoAPI.Data.Dtos;
using Sl.GrupoAPI.Models;

namespace Sl.GrupoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GruposController : ControllerBase
    {
        private GrupoContext _context;
        private IMapper _mapper;
        public GruposController(GrupoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGrupoPorId(int id)
        {
            Grupo grupo = _context.Grupos.FirstOrDefault(grupo => grupo.Id == id);
            if (grupo != null)
            {
                ReadGrupoDto dto = _mapper.Map<ReadGrupoDto>(grupo);
                return Ok(dto);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AdicionaGrupo([FromBody] CreateGrupoDto dto)
        {
            Grupo grupo = _mapper.Map<Grupo>(dto);
            _context.Grupos.Add(grupo);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperaGrupoPorId), new { Id = grupo.Id }, grupo);
        }


        [HttpGet]
        public IEnumerable<ReadGrupoDto> RecuperaGrupos([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _mapper.Map<ICollection<ReadGrupoDto>>(_context.Grupos.Skip(skip).Take(take).ToList());
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaGrupo(int id)
        {
            Grupo grupo = _context.Grupos.FirstOrDefault(grupo => grupo.Id == id);
            if (grupo == null) return NotFound();
            _context.Remove(grupo);
            _context.SaveChanges();

            return NoContent();
        }


    }
}
