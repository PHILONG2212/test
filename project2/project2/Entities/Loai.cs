﻿using System;
using System.Collections.Generic;

namespace project2.Entities;

public partial class Loai
{
    public int MaLoai { get; set; }

    public string TenLoai { get; set; } = null!;

    public string? MoTa { get; set; }

    public string? Hinh { get; set; }

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
}
