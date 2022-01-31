using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class CsninvestController : BaseApiController
    {
        private readonly DataContext _context;
        
        public CsninvestController(DataContext context)
        {
            _context = context;
        }
        
        [HttpPost("login")]
        public async Task<ActionResult<CsnLoginDto>> Login(CsnSenhaDto csnSenhaDto)
        {
            var cotista = await _context.CsnivSenha.FirstOrDefaultAsync(x => 
                x.NumCotista == csnSenhaDto.NumCotista);

            if (cotista == null) return Unauthorized("Numero Cotista invalido");

            if (csnSenhaDto.Senha != cotista.Senha) return Unauthorized("Senha invalida");

            var login = new CsnLoginDto
            {
                NumCotista = cotista.NumCotista,
                DataAlt = cotista.DataAlt
            };
            
            return login;
        }
    }
}