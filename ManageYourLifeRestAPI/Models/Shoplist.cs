using System;
using System.Collections.Generic;

namespace ManageYourLifeRestAPI.Models;

public partial class Shoplist
{
    public int Id { get; set; }

    public string? Product { get; set; }

    public int? Unit { get; set; }

    public string? Info { get; set; }
}
