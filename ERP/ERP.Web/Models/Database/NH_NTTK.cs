//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERP.Web.Models.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class NH_NTTK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NH_NTTK()
        {
            this.NH_CT_NTTK = new HashSet<NH_CT_NTTK>();
            this.NH_CT_UNC = new HashSet<NH_CT_UNC>();
        }
    
        public string SO_CHUNG_TU { get; set; }
        public System.DateTime NGAY_HACH_TOAN { get; set; }
        public System.DateTime NGAY_CHUNG_TU { get; set; }
        public string MA_DOI_TUONG { get; set; }
        public string NOP_VAO_TAI_KHOAN { get; set; }
        public string LY_DO_THU { get; set; }
        public string DIEN_GIAI_LY_DO_THU { get; set; }
        public string NHAN_VIEN_THU { get; set; }
        public decimal TONG_TIEN { get; set; }
        public string NGUOI_LAP_BIEU { get; set; }
        public string TRUC_THUOC { get; set; }
    
        public virtual CCTC_CONG_TY CCTC_CONG_TY { get; set; }
        public virtual DM_DOI_TUONG DM_DOI_TUONG { get; set; }
        public virtual DM_TK_NGAN_HANG_NOI_BO DM_TK_NGAN_HANG_NOI_BO { get; set; }
        public virtual HT_NGUOI_DUNG HT_NGUOI_DUNG { get; set; }
        public virtual HT_NGUOI_DUNG HT_NGUOI_DUNG1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NH_CT_NTTK> NH_CT_NTTK { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NH_CT_UNC> NH_CT_UNC { get; set; }
    }
}
