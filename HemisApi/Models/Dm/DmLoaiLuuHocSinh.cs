using System;
using System.Collections.Generic;

namespace HemisApi.Models;

public partial class DmLoaiLuuHocSinh
{
    public int IdLoaiLuuHocSinh { get; set; }

    public string? LoaiLuuHocSinh { get; set; }

    public virtual ICollection<TbLuuHocSinhSinhVienNn> TbLuuHocSinhSinhVienNns { get; set; } = new List<TbLuuHocSinhSinhVienNn>();
}
