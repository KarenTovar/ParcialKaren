using System;
using System.Collections.Generic;

namespace ParcialBackend.Models;

public partial class Farmaco
{
    public int IdFarmacos { get; set; }

    public string? Nombre { get; set; }

    public string? Precio { get; set; }

    public int? Stock { get; set; }

    public int? IdFarmacia { get; set; }

    public int? IdCliente { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Farmacium? IdFarmaciaNavigation { get; set; }
}
