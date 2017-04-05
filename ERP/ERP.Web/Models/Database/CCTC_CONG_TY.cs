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
    
    public partial class CCTC_CONG_TY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CCTC_CONG_TY()
        {
            this.BH_DON_HANG_DU_KIEN = new HashSet<BH_DON_HANG_DU_KIEN>();
            this.XL_DANG_KY_PHE_DUYET = new HashSet<XL_DANG_KY_PHE_DUYET>();
            this.CN_NHOM_NGHIEP_VU = new HashSet<CN_NHOM_NGHIEP_VU>();
            this.DM_CHUNG_TU = new HashSet<DM_CHUNG_TU>();
            this.KHs = new HashSet<KH>();
            this.DM_KHO = new HashSet<DM_KHO>();
            this.DM_TK_NGAN_HANG_NOI_BO = new HashSet<DM_TK_NGAN_HANG_NOI_BO>();
            this.HT_NGUOI_DUNG = new HashSet<HT_NGUOI_DUNG>();
            this.KHO_DNXH = new HashSet<KHO_DNXH>();
            this.KHO_GIU_HANG = new HashSet<KHO_GIU_HANG>();
            this.KHO_NHAP_KHO = new HashSet<KHO_NHAP_KHO>();
            this.KHO_XUAT_KHO = new HashSet<KHO_XUAT_KHO>();
            this.CCTC_CONG_TY1 = new HashSet<CCTC_CONG_TY>();
            this.CCTC_PHONG_BAN = new HashSet<CCTC_PHONG_BAN>();
            this.NH_CHUYEN_TIEN_NOI_BO = new HashSet<NH_CHUYEN_TIEN_NOI_BO>();
            this.NH_NTTK = new HashSet<NH_NTTK>();
            this.NH_UNC = new HashSet<NH_UNC>();
            this.QUY_PHIEU_CHI = new HashSet<QUY_PHIEU_CHI>();
            this.QUY_PHIEU_THU = new HashSet<QUY_PHIEU_THU>();
            this.CN_NGHIEP_VU = new HashSet<CN_NGHIEP_VU>();
            this.DM_DOI_TUONG = new HashSet<DM_DOI_TUONG>();
        }
    
        public string MA_CONG_TY { get; set; }
        public string TEN_CONG_TY { get; set; }
        public Nullable<System.DateTime> NGAY_THANH_LAP { get; set; }
        public string EMAIL { get; set; }
        public string FAX { get; set; }
        public string SDT { get; set; }
        public string MST { get; set; }
        public string LOGO { get; set; }
        public string DIA_CHI { get; set; }
        public string DIA_CHI_XUAT_HOA_DON { get; set; }
        public string CONG_TY_ME { get; set; }
        public string CAP_TO_CHUC { get; set; }
        public string GHI_CHU { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BH_DON_HANG_DU_KIEN> BH_DON_HANG_DU_KIEN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XL_DANG_KY_PHE_DUYET> XL_DANG_KY_PHE_DUYET { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CN_NHOM_NGHIEP_VU> CN_NHOM_NGHIEP_VU { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DM_CHUNG_TU> DM_CHUNG_TU { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KH> KHs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DM_KHO> DM_KHO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DM_TK_NGAN_HANG_NOI_BO> DM_TK_NGAN_HANG_NOI_BO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HT_NGUOI_DUNG> HT_NGUOI_DUNG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHO_DNXH> KHO_DNXH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHO_GIU_HANG> KHO_GIU_HANG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHO_NHAP_KHO> KHO_NHAP_KHO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHO_XUAT_KHO> KHO_XUAT_KHO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CCTC_CONG_TY> CCTC_CONG_TY1 { get; set; }
        public virtual CCTC_CONG_TY CCTC_CONG_TY2 { get; set; }
        public virtual CCTC_MO_HINH_CONG_TY CCTC_MO_HINH_CONG_TY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CCTC_PHONG_BAN> CCTC_PHONG_BAN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NH_CHUYEN_TIEN_NOI_BO> NH_CHUYEN_TIEN_NOI_BO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NH_NTTK> NH_NTTK { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NH_UNC> NH_UNC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QUY_PHIEU_CHI> QUY_PHIEU_CHI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QUY_PHIEU_THU> QUY_PHIEU_THU { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CN_NGHIEP_VU> CN_NGHIEP_VU { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DM_DOI_TUONG> DM_DOI_TUONG { get; set; }
    }
}
