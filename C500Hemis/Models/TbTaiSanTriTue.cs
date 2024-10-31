using System;
using System.Collections.Generic;
<<<<<<< Updated upstream
using System.ComponentModel;
=======
>>>>>>> Stashed changes
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;
using Microsoft.Build.Framework;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;




namespace C500Hemis.Models;

public partial class TbTaiSanTriTue
{
<<<<<<< Updated upstream

    [DisplayName("ID")]
    [Required(ErrorMessage = "dữ liệu này không được để trống")]
    [Range(0, int.MaxValue, ErrorMessage = "Giá trị không thể là số âm.")]
    public int IdTaiSanTriTue { get; set; }//primary key

    [DisplayName("Nhiệm Vụ KHCN")]
    public int? IdNhiemVuKhcn { get; set; }

    [DisplayName("Loại Tài Sản Trí Tuệ")]
    public int? IdLoaiTaiSanTriTue { get; set; }

    [DisplayName("Mã Giải Pháp Sáng Chế")]

    public string? MaGiaiPhapSangChe { get; set; }
    [MaxLength(60)]
    [DisplayName("Tên Tài Sản Trí Tuệ")]
    public string? TenTaiSanTriTue { get; set; }
    [DisplayName("Tổ Chức Cấp Bằng Giấy Chứng Nhận")]
    public string? ToChucCapBangGiayChungNhan { get; set; }

    [DisplayName("Ngày Cấp Bằng Giấy Chứng Nhận")]
    //định dạng dd/MM/yyyy
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateOnly? NgayCapBangGiayChungNhan { get; set; }
    [DisplayName("Tổ Chức Cấp Bằng")]
    public string? ToChucCapBang { get; set; }
    [DisplayName("Số Bằng")]
    [Range(0, int.MaxValue, ErrorMessage = "Giá trị không thể là số âm.")]
    public int? SoBang { get; set; }
    [DisplayName("Ngày Cấp")]
    //định dạng dd/MM/yyyy
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateOnly? NgayCap { get; set; }
    [DisplayName("Số Đơn")]
    [Range(0, int.MaxValue, ErrorMessage = "Giá trị không thể là số âm.")]
    public int? SoDon { get; set; }
    [DisplayName("Ngày Nộp Đơn ")]
    //định dạng dd/MM/yyyy
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateOnly? NgayNopDon { get; set; }
    [DisplayName("Quyết Định Cấp Bằng Giấy Chứng Nhận")]
    public string? QuyetDinhCapBangGiayChungNhan { get; set; }
    [DisplayName("Công Bố Bằng")]
    public string? CongBoBang { get; set; }
    [DisplayName("IPC")]
    public string? Ipc { get; set; }
    [MaxLength(60)]
    [DisplayName("Chủ Sở Hữu")]
    public string? ChuSoHuu { get; set; }
    [DisplayName("Tác Giả Sáng Chế Giải Pháp")]
    public string? TacGiaSangCheGiaiPhap { get; set; }
    [DisplayName("Tóm Tắt Nội Dung Tài Sản Trí Tuệ")]
    public string? TomTatNoiDungTaiSanTriTue { get; set; }
    [DisplayName("Người Chủ Trì")]
=======
    [Display(Name = "ID Tài sản trí tuệ")]

    public int IdTaiSanTriTue { get; set; }

    [Display(Name = "ID Nhiệm vụ khoa học công nghệ")]
    public int? IdNhiemVuKhcn { get; set; }

    [Display(Name = "Mã giải pháp sáng chế")]
    [Required(ErrorMessage = "Mã giải pháp sáng chế không được bỏ trống")]

    public string? MaGiaiPhapSangChe { get; set; }

    [Display(Name = "Tên tài sản trí tuệ")]
    [Required(ErrorMessage = "Tên tài sản trí tuệ không được bỏ trống")]
    public string? TenTaiSanTriTue { get; set; }

    [Display(Name = "Tổ chức cấp bằng giấy chứng nhận")]

    public string? ToChucCapBangGiayChungNhan { get; set; }

    [Display(Name = "ID Loại tài sản trí tuệ")]
    public int? IdLoaiTaiSanTriTue { get; set; }

    [Display(Name = "Ngày cấp bằng giấy chứng nhận")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateOnly? NgayCapBangGiayChungNhan { get; set; }

    [Display(Name = "Tổ chức cấp bằng")]
    public string? ToChucCapBang { get; set; }

    [Display(Name = "Số bằng")]
    public int? SoBang { get; set; }

    [Display(Name = "Ngày cấp")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateOnly? NgayCap { get; set; }

    [Display(Name = "Số đơn")]
    public int? SoDon { get; set; }

    [Display(Name = "Ngày nộp đơn")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateOnly? NgayNopDon { get; set; }

    [Display(Name = "Quyết định cấp bằng giấy chứng nhận")]
    public string? QuyetDinhCapBangGiayChungNhan { get; set; }

    [Display(Name = "Công cố bằng")]
    public string? CongBoBang { get; set; }

    [Display(Name = "IPC")]
    public string? Ipc { get; set; }

    [Display(Name = "Chủ sở hữu")]
    public string? ChuSoHuu { get; set; }

    [Display(Name = "Tác giả sáng chế giải pháp")]
    public string? TacGiaSangCheGiaiPhap { get; set; }

    [Display(Name = "Tóm tắt nội dung tài sản trí tuệ")]
    public string? TomTatNoiDungTaiSanTriTue { get; set; }

    [Display(Name = "Người chủ trì")]
>>>>>>> Stashed changes
    public string? NguoiChuTri { get; set; }
    [DisplayName("Năm Được Chấp Nhận Đơn Hợp Lệ")]
    [Range(0, int.MaxValue, ErrorMessage = "Giá trị không thể là số âm.")]
    public int? NamDuocChapNhanDonHopLe { get; set; }

<<<<<<< Updated upstream
    [DisplayName("ID Loại Tài Sản Trí Tuệ Navigation")]

    public virtual DmLoaiTaiSanTriTue? IdLoaiTaiSanTriTueNavigation { get; set; }//foreign key

    [DisplayName("ID Nhiệm Vụ KHCN Navigation")]

    public virtual TbNhiemVuKhcn? IdNhiemVuKhcnNavigation { get; set; }//foreign key
=======
    [Display(Name = "Năm được chấp nhận đơn hợp lệ")]
    public string? NamDuocChapNhanDonHopLe { get; set; }

    [Display(Name = "Loại tài sản trí tuệ")]
    public virtual DmLoaiTaiSanTriTue? IdLoaiTaiSanTriTueNavigation { get; set; }

    [Display(Name = "Nhiệm vụ khoa học công nghệ")]
    public virtual TbNhiemVuKhcn? IdNhiemVuKhcnNavigation { get; set; }
>>>>>>> Stashed changes
}
