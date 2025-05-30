using System;
using System.Collections.Generic;

namespace CRUD.Models;

public partial class Locale
{
    public int Id { get; set; }

    public string? NombreDelLocal { get; set; }

    public string? Direccion { get; set; }

    public int? NumeroDeTelefono { get; set; }
}
