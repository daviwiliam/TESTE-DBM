using Microsoft.AspNetCore.Mvc;
using ApiCSharp.Data;
using ApiCSharp.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ApiCSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PessoaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("importar-csv")]
        public async Task<IActionResult> ImportarCsv(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Arquivo inválido");

            try
            {
                using var stream = new StreamReader(file.OpenReadStream());
                await stream.ReadLineAsync();

                var pessoas = new List<Pessoa>();

                string line;
                while ((line = await stream.ReadLineAsync()) != null)
                {
                    var data = line.Split(',');
                    if (data.Length < 5)
                        continue;

                    if (!int.TryParse(data[2], out int idade))
                        continue;

                    var pessoa = new Pessoa
                    {
                        Nome = data[1].Trim(),
                        Idade = idade,
                        Cidade = data[3].Trim(),
                        Profissao = data[4].Trim()
                    };

                    pessoas.Add(pessoa);
                }

                if (pessoas.Any())
                {
                    await _context.Pessoas.AddRangeAsync(pessoas);
                    await _context.SaveChangesAsync();
                    return Ok("Dados importados com sucesso!");
                }

                return BadRequest("Nenhum dado válido encontrado no arquivo.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao processar o arquivo: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPessoa(int id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            if (pessoa == null)
                return NotFound("Pessoa não encontrada");

            return Ok(pessoa);
        }
    }
}
