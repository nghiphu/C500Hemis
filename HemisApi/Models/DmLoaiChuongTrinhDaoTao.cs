﻿using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmLoaiChuongTrinhDaoTao
{
    public int IdLoaiChuongTrinhDaoTao { get; set; }

    public string? LoaiChuongTrinhDaoTao { get; set; }

    public virtual ICollection<TbChuongTrinhDaoTao> TbChuongTrinhDaoTaos { get; set; } = new List<TbChuongTrinhDaoTao>();
}
