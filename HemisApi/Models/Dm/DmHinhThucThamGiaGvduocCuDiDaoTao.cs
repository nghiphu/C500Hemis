﻿using System;
using System.Collections.Generic;

namespace HemisApi.Models;

public partial class DmHinhThucThamGiaGvduocCuDiDaoTao
{
    public int IdHinhThucThamGiaGvduocCuDiDaoTao { get; set; }

    public string? HinhThucThamGiaGvduocCuDiDaoTao { get; set; }

    public virtual ICollection<TbGvduocCuDiDaoTao> TbGvduocCuDiDaoTaos { get; set; } = new List<TbGvduocCuDiDaoTao>();
}
