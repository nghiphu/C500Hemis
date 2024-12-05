using System;
using System.Collections.Generic;

namespace HemisApi.Models;

public partial class DmXepHangQ
{
    public int IdXepHangQ { get; set; }

    public string? XepHangQ { get; set; }

    public virtual ICollection<TbBaiBaoKhdaCongBo> TbBaiBaoKhdaCongBos { get; set; } = new List<TbBaiBaoKhdaCongBo>();
}
