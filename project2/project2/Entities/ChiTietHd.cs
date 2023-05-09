using System;
using System.Collections.Generic;

namespace project2.Entities;

public partial class ChiTietHd
{
    public int MaCt { get; set; }

    public int MaHd { get; set; }

    public int MaTour { get; set; }

    public double DonGia { get; set; }

    public int SoLuong { get; set; }

    public double GiamGia { get; set; }

    public virtual HoaDon MaHdNavigation { get; set; } = null!;

    public virtual Tour MaTourNavigation { get; set; } = null!;
}
