using System;
using System.Collections.Generic;

namespace HemisApi.Models;

public partial class DmLoaiKyLuat
{
    public int IdLoaiKyLuat { get; set; }

    public string? LoaiKyLuat { get; set; }

    public virtual ICollection<TbKyLuatCanBo> TbKyLuatCanBos { get; set; } = new List<TbKyLuatCanBo>();

    public virtual ICollection<TbKyLuatNguoiHoc> TbKyLuatNguoiHocs { get; set; } = new List<TbKyLuatNguoiHoc>();
}
