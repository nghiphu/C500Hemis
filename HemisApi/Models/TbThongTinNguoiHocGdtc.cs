﻿using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class TbThongTinNguoiHocGdtc
{
    public int IdThongTinNguoiHocGdtc { get; set; }

    public int? IdHocVien { get; set; }

    public string? KetQuaHocTap { get; set; }

    public string? TieuChuanDanhGiaXepLoaiTheLuc { get; set; }

    public virtual TbHocVien? IdHocVienNavigation { get; set; }
}