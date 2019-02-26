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
using Livraria.Application.Livros.Queries.GetLivros;
using Livraria.Application.Common.Models;
using Livraria.Application.Livros.Commands.EditarLivro;
using Livraria.Application.Livros.Commands.DeletarLivro;

namespace Livraria.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ICriarLivroCommand _criarLivroCommand;
        private readonly IGetLivroQuery _getLivroQuery;
        private readonly IGetLivrosQuery _getLivrosQuery;
        private readonly IEditarLivroCommand _editarLivroCommand;
        private readonly IDeletarLivroCommand _deletarLivroCommand;

        public LivrosController(ICriarLivroCommand criarLivroCommand, IGetLivroQuery getLivroQuery, IGetLivrosQuery getLivrosQuery, IEditarLivroCommand editarLivroCommand, IDeletarLivroCommand deletarLivroCommand)
        {
            _criarLivroCommand = criarLivroCommand;
            _getLivroQuery = getLivroQuery;
            _getLivrosQuery = getLivrosQuery;
            _editarLivroCommand = editarLivroCommand;
            _deletarLivroCommand = deletarLivroCommand;
        }


        // GET: api/Livros
        [HttpGet]
        public ActionResult<RetornoConsulta<LivroModel>> GetLivro([FromQuery] LivroBuscaModel livroModelConsulta)
        {
            return _getLivrosQuery.Execute(livroModelConsulta);
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

        // PUT: api/Livros/5
        [HttpPut("{ISBN}")]
        public async Task<ActionResult<LivroModel>> PutLivro(string ISBN, LivroInputModel livro)
        {
            var retorno = await _editarLivroCommand.Execute(ISBN, livro);

            if (retorno)
            {
                return await _getLivroQuery.Execute(ISBN);
            }

            return NotFound();
        }

        // POST: api/Livros
        [HttpPost]
        public async Task<ActionResult<LivroModel>> PostLivro([FromForm] LivroInputModel livro, IFormFile ImagemCapa)
        {
            byte[] capaBytes;
            using (var ms = new MemoryStream())
            {
                ImagemCapa.CopyTo(ms);
                capaBytes = ms.ToArray();
            }

            var retorno = await _criarLivroCommand.Execute(livro, capaBytes);

            if (retorno)
            {
                return CreatedAtAction("GetLivro", new { ISBN = livro.ISBN }, livro);
            }

            return NoContent();
        }

        // DELETE: api/Livros/5
        [HttpDelete("{ISBN}")]
        public async Task<ActionResult<LivroModel>> DeleteLivro(string ISBN)
        {
            var livro = await _getLivroQuery.Execute(ISBN);
            var retorno = await _deletarLivroCommand.Execute(ISBN);

            if (retorno)
            {
                return livro;
            }

            return NotFound();
        }

    }
}
