using System;
using System.Collections.Generic;

namespace TaskCode.Models;

public partial class CategoriaCredito
{
    public int Id { get; set; }

    public string Categoria { get; set; } = null!;

    public int DiasDesde { get; set; }

    public int DiasHasta { get; set; }

    public bool IsActive { get; set; } = true;
}
