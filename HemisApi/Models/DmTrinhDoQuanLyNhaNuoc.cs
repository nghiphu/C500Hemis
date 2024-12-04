using System;
using System.Collections.Generic;

namespace HemisApi.Models;

public partial class DmTrinhDoQuanLyNhaNuoc
{
    public int IdTrinhDoQuanLyNhaNuoc { get; set; }

    public string? TrinhDoQuanLyNhaNuoc { get; set; }

    public virtual ICollection<TbNguoi> TbNguois { get; set; } = new List<TbNguoi>();
}
