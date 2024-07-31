
namespace Servicios.Core.DTOs
{

    public class Ocultas
    {
        public string nombre_habilidades { get; set; }
                
    }
    public class Habilidades
    {
        public IList<Ocultas> ocultas { get; set; }
       

    }

    public class PokemonDto
    {
        public string response { get; set; }
        public string error { get; set; }
        public Habilidades habilidades { get; set; }

        public string nombre_pokemon { get; set; }
    }
  

}
