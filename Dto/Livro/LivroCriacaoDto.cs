using WebApi_Livros.Models;

namespace WebApi_Livros.Dto.Livro
{
    public class LivroCriacaoDto
    {
        public string Titulo { get; set; }
        public Vinculo.AutorVinculoDto Autor { get; set; }
    }
}
