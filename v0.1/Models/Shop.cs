using System;
using System.Collections.Generic;

namespace v0._1.Models;

public partial class Shop
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Address { get; set; }

    public int AgentId { get; set; }

    public virtual Agent Agent { get; set; } = null!;
}
