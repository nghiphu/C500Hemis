using System;
using System.Collections.Generic;

namespace HemisApi.Models;

public partial class DmDoiTuongUuTien
{
    public int IdDoiTuongUuTien { get; set; }

    public string? DoiTuongUuTien { get; set; }

    public virtual ICollection<TbDuLieuTrungTuyen> TbDuLieuTrungTuyens { get; set; } = new List<TbDuLieuTrungTuyen>();
}
