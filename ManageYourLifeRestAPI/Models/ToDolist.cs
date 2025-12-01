using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManageYourLifeRestAPI.Models;

public partial class ToDolist
{
    [Key]
    public int Id { get; set; }

    public string? Task { get; set; }

    public string? Date { get; set; }

    public string? Info { get; set; }

    public string? Completed { get; set; }
}
