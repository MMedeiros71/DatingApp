using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class CsnSenhaDto
    {
        [Required]
        public string NumCotista { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}