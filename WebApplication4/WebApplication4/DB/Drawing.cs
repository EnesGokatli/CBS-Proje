using System;
using System.Collections.Generic;

namespace WebApplication4.DB;

public partial class Drawing
{
    public int Id { get; set; }

    public string ObjectType { get; set; } = null!;

    public string? ObjectData { get; set; }
}
