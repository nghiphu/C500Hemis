﻿using System;
using System.Collections.Generic;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbDonViLienKetDaoTaoGiaoDuc
{
    public int IdDonViLienKetDaoTaoGiaoDuc { get; set; }

    public int? IdCoSoGiaoDuc { get; set; }

    public string? DiaChi { get; set; }

    public string? DienThoai { get; set; }

    public int? IdLoaiLienKet { get; set; }

    public virtual TbCoSoGiaoDuc? IdCoSoGiaoDucNavigation { get; set; }

    public virtual DmLoaiLienKet? IdLoaiLienKetNavigation { get; set; }
}
