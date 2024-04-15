using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MovieApi.Data;
using MovieApi.Dtos;
using MovieApi.Models;

namespace MovieApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {

        private MovieContext _context;
        private IMapper _mapper;

        public SessionController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddSession(CreateSessionDto dto)
        {
            Session session = _mapper.Map<Session>(dto);
            _context.Sessions.Add(session);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSessionsById),
                new {movieId = session.MovieId, cinemaId = session.CinemaId }, session);
        }

        [HttpGet]
        public IEnumerable<ReadSessionDto> GetSessions()
        {
            return _mapper.Map<List<ReadSessionDto>>(_context.Sessions.ToList());
        }

        [HttpGet("{movieId}/{cinemaId}")]
        public IActionResult GetSessionsById(int movieId, int cinemaId)
        {
            Session sessao = _context.Sessions.FirstOrDefault(sessao => sessao.MovieId == movieId && 
            sessao.CinemaId == cinemaId)!;

            if (sessao != null)
            {
                ReadSessionDto sessaoDto = _mapper.Map<ReadSessionDto>(sessao);

                return Ok(sessaoDto);
            }
            return NotFound();
        }
    }
}
