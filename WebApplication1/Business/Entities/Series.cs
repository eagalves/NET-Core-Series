
namespace SeriesApp.Business.Entities
{
    public class Series
    {
        public int Codigo { get; set; }
        public string Genero { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Ano { get; set; }
        public bool Excluido { get; set; }

    }
}
