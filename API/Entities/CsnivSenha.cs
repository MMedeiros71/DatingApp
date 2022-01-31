using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.Entities
{
    public partial class CsnivSenha
    {
        public string NumCotista { get; set; }
        public string Senha { get; set; }
        public DateTime? DataAlt { get; set; }
    }
}
