namespace TaskCode.DTOs
{
    public class CategriaCreditoDTO
    {
        public int Id { get; set; }
        public string Categoria { get; set; } = null!;
        public int DiasDesde { get; set; }
        public int DiasHasta { get; set; }
        public bool IsActive { get; set; }
    }
}
