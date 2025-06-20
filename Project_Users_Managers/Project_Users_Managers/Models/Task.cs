using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project_Users_Managers.Models;

public partial class UserTask
{
    [Key]
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public TimeOnly TimeSpent { get; set; }

    public string Executor { get; set; } = null!;

    public DateOnly Date { get; set; }
}
