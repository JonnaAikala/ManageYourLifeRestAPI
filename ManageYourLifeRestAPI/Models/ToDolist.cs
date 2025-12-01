using System;
using System.Collections.Generic;

namespace ManageYourLifeRestAPI.Models;

public partial class ToDolist
{
    public int Id { get; set; }

    public string? Task { get; set; }

    public string? Date { get; set; }

    public string? Info { get; set; }

    public string? Completed { get; set; }
}
