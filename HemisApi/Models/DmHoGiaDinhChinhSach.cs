using System;
using System.Collections.Generic;

namespace HemisApi.Models;

public partial class DmHoGiaDinhChinhSach
{
    public int IdHoGiaDinhChinhSach { get; set; }

    public string? HoGiaDinhChinhSach { get; set; }

    public virtual ICollection<TbNguoi> TbNguois { get; set; } = new List<TbNguoi>();
}
