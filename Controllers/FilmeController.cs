using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController] // Para controlar a API
    [Route("[controller]")] // A route de forma generica vai ser "controler" que faz referencia a classe FilmeController
    public class FilmeController : Controller //Vai Herdar propriedades da classe base Controller
    {
        private FilmeContext _context;

        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        [HttpPost] //Verbo http da ação
        public IActionResult AdicionaFilmes([FromBody] Filme filme) //IActionResult porque é o tipo de retorno, uma ação
        {
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { id = filme.Id }, filme); //Criar uma ação no Header da API, tal como caminho e o filme(id)
        }

        [HttpGet] //Para pegar informação
        public IEnumerable<Filme> RecuperaFilmes() //IActionResult porque é o tipo de retorno, uma ação
        {
            return _context.Filmes; //Vai dar um Status de OK
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id) //IActionResult porque é o tipo de retorno, uma ação
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id); //Primeiro id == Id vai retornar um Ok, senão um NotFound
            if (filme != null)
            {
                return Ok(filme);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] Filme filmeNovo)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            filme.Titulo = filmeNovo.Titulo;
            filme.Genero = filmeNovo.Genero;
            filme.Duracao = filmeNovo.Duracao;
            filme.Diretor = filmeNovo.Diretor;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
