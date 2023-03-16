using System;
using System.Collections.Generic;

namespace ParcialBackend.Models;

public partial class Farmacium
{
    public int IdFarmacia { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Nit { get; set; }

    public virtual ICollection<Farmaco> Farmacos { get; } = new List<Farmaco>();
}
