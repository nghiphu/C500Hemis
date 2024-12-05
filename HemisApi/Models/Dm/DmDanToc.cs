using System;
using System.Collections.Generic;

namespace HemisApi.Models;

public partial class DmDanToc
{
    public int IdDanToc { get; set; }

    public string? DanToc { get; set; }

    public virtual ICollection<TbNguoi> TbNguois { get; set; } = new List<TbNguoi>();
}
