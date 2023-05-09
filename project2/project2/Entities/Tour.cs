using System;
using System.Collections.Generic;

namespace project2.Entities;

public partial class Tour
{
    public int MaTour { get; set; }

    public string TenTour { get; set; } = null!;

    public int MaLoai { get; set; }

    public double? DonGia { get; set; }

    public string? Hinh { get; set; }

    public DateTime NgayKhoiHanh { get; set; }

    public double? GiamGia { get; set; }

    public int? SoLanXem { get; set; }

    public string? MoTa { get; set; }

    public int? MaKhachSan { get; set; }

    public virtual ICollection<ChiTietHd> ChiTietHds { get; set; } = new List<ChiTietHd>();

    public virtual KhachSan? MaKhachSanNavigation { get; set; }

    public virtual Loai MaLoaiNavigation { get; set; } = null!;

    public virtual ICollection<YeuThich> YeuThiches { get; set; } = new List<YeuThich>();
}
