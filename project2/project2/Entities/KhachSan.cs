using System;
using System.Collections.Generic;

namespace project2.Entities;

public partial class KhachSan
{
    public int MaKhachSan { get; set; }

    public string TenKhachSan { get; set; } = null!;

    public string? Logo { get; set; }

    public string? NguoiLienLac { get; set; }

    public string Email { get; set; } = null!;

    public string? DienThoai { get; set; }

    public string? DiaChi { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
}
