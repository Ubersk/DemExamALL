using System;
using System.Collections.Generic;

namespace v0._1.Models;

public partial class MaterialType
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public double DefectedPercent { get; set; }

    public virtual ICollection<Material> Materials { get; } = new List<Material>();
}
