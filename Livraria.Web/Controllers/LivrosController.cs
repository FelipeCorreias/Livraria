using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Livraria.Application.Livros.Models;
using Livraria.Application.Livros.Commands.CriarLivro;
using Livraria.Application.Livros.Queries.GetLivro;
using System.IO;

namespace Livraria.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ICriarLivroCommand _criarLivroCommand;
        private readonly IGetLivroQuery _getLivroQuery;

        public LivrosController(ICriarLivroCommand criarLivroCommand, IGetLivroQuery getLivroQuery)
        {
            _criarLivroCommand = criarLivroCommand;
            _getLivroQuery = getLivroQuery;
        }

        // GET: api/Livros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LivroModel>>> GetLivro([FromQuery] LivroModelConsulta livroModelConsulta)
        {
            return Ok();
        }

        // GET: api/Livros/5
        [HttpGet("{ISBN}")]
        public async Task<ActionResult<LivroModel>> GetLivro(string ISBN)
        {
            var livro = await _getLivroQuery.Execute(ISBN);

            if (livro == null)
            {
                return NotFound();
            }

            return livro;
        }

        //// PUT: api/Livros/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutLivro(string id, Livro livro)
        //{
        //    if (id != livro.ISBN)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(livro).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!LivroExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Livros
        [HttpPost]
        public async Task<ActionResult<LivroModel>> PostLivro([FromForm] LivroModel livro, IFormFile ImagemCapa)
        {
            byte[] capaBytes;
            using (var ms = new MemoryStream())
            {
                ImagemCapa.CopyTo(ms);
                capaBytes = ms.ToArray();
            }
            livro.Capa = capaBytes;
            var retorno = await _criarLivroCommand.Execute(livro);

            if (retorno)
            {
                return CreatedAtAction("GetLivro", new { ISBN = livro.ISBN }, livro);
            }

            return NotFound();
        }

        // DELETE: api/Livros/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Livro>> DeleteLivro(string id)
        //{
        //    var livro = await _context.Livro.FindAsync(id);
        //    if (livro == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Livro.Remove(livro);
        //    await _context.SaveChangesAsync();

        //    return livro;
        //}

        //private bool LivroExists(string id)
        //{
        //    return _context.Livro.Any(e => e.ISBN == id);
        //}
    }
}
