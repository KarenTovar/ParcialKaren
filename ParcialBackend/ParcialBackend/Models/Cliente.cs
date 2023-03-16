using System;
using System.Collections.Generic;

namespace ParcialBackend.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Nombre { get; set; }

    public int? Telefono { get; set; }

    public string? Direccion { get; set; }

    public int? Documento { get; set; }

    public virtual ICollection<Farmaco> Farmacos { get; } = new List<Farmaco>();
}
