﻿using System;
using System.Collections.Generic;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbTrinhDoTiengDanToc
{
    public int IdTrinhDoTiengDanToc { get; set; }

    public int? IdCanBo { get; set; }

    public int? IdTiengDanToc { get; set; }

    public int? IdKhungNangLucNgoaiNgu { get; set; }

    public virtual TbCanBo? IdCanBoNavigation { get; set; }

    public virtual DmKhungNangLucNgoaiNgu? IdKhungNangLucNgoaiNguNavigation { get; set; }

    public virtual DmTiengDanToc? IdTiengDanTocNavigation { get; set; }
}
