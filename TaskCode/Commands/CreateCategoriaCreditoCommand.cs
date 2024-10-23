namespace TaskCode.Commands
{
    public class CreateCategoriaCreditoCommand
    {
        public string Categoria { get; set; } = null!;
        public int DiasDesde { get; set; }
        public int DiasHasta {  get; set; }
    }
}
