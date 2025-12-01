using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManageYourLifeRestAPI.Models;

public partial class Shoplist
{
    [Key]
    public int Id { get; set; }

    public string? Product { get; set; }

    public int? Unit { get; set; }

    public string? Info { get; set; }
}
