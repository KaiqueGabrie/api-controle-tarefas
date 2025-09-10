namespace APIservico.Models.Dtos
{
    public class ChamadoDto // criado para aparecer somente titulo e descrição, sem id
    {
        public required string Titulo { get; set; }
        public required string Descricao {  get; set; }
    }
}
