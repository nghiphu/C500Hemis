using System;
using System.Collections.Generic;

namespace HemisApi.Models;

public partial class DmLoaiNhiemVu
{
    public int IdLoaiNhiemVu { get; set; }

    public string? LoaiNhiemVu { get; set; }

    public virtual ICollection<TbNhiemVuKhcn> TbNhiemVuKhcns { get; set; } = new List<TbNhiemVuKhcn>();
}
