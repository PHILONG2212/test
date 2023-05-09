using System;
using System.Collections.Generic;

namespace project2.Entities;

public partial class YeuThich
{
    public int MaYt { get; set; }

    public int? MaTour { get; set; }

    public string? MaKh { get; set; }

    public DateTime? NgayChon { get; set; }

    public string? MoTa { get; set; }

    public virtual KhachHang? MaKhNavigation { get; set; }

    public virtual Tour? MaTourNavigation { get; set; }
}
