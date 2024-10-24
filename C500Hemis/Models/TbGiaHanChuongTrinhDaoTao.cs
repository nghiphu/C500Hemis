﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace C500Hemis.Models;

public partial class TbGiaHanChuongTrinhDaoTao
{
    [DisplayName(displayName: "Mã Chương Trình Đào Tạo")]
    public int IdGiaHanChuongTrinhDaoTao { get; set; }
    [DisplayName(displayName: "Tên Chương Trình Đào Tạo")]
    public int? IdChuongTrinhDaoTao { get; set; }
    [DisplayName(displayName: "Số Quyết Định Gia Hạn")]
    public string? SoQuyetDinhGiaHan { get; set; }
    [DisplayName(displayName: "Ngày Ban Hành Văn Bản Gia Hạn")]
    public DateOnly? NgayBanHanhVanBanGiaHan { get; set; }
    [DisplayName(displayName: "Số Lần Gia Hạn")]
    public int? GiaHanLanThu { get; set; }
    [DisplayName(displayName: "ID Chương Trình Đào Tạo")]
    public virtual TbChuongTrinhDaoTao? IdChuongTrinhDaoTaoNavigation { get; set; }
}