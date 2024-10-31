using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbDoanhNghiepKhcn
{
    [DisplayName("ID")]  
    [Required(ErrorMessage = "  ID không được để trống.")]  
    [Range(0, int.MaxValue, ErrorMessage = "  ID không được âm.")]  
    public int IdDoanhNghiepKhcn { get; set; }  
    [DisplayName("Mã Doanh Nghiệp")]
    public string? MaDoanhNghiep { get; set; }
    [DisplayName("Tên Doanh Nghiệp")]
    public string? TenDoanhNghiep { get; set; }
    [DisplayName("ID Hình Thức Doanh NGhiệp KCKH")]
    public int? IdHinhThucDoanhNghiepKhcn { get; set; }
    [DisplayName("Địa Điểm Thành Lập")]
    public string? DiaDiemThanhLap { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "Giá trị phải không được  âm.")]
    [DisplayName("Quy Mô Đầu Tư")]

    public int? QuyMoDauTu { get; set; }
    [DisplayName("Kinh Phí Góp Vốn Từ Tài Sản Trí Tuệ")]
    [Range(0, int.MaxValue, ErrorMessage = "   Giá trị phải không được  âm.")]
    public string? KinhPhiGopVonTuTaiSanTriTue { get; set; }
    [DisplayName("Tỷ Lệ Góp Vốn ")]

    public int? TyLeGopVonCuaCsgddh { get; set; }

    [DisplayName("Hình Thức Doanh Nghiệp")]
    public virtual DmHinhThucDoanhNghiepKhcn? IdHinhThucDoanhNghiepKhcnNavigation { get; set; }
}
