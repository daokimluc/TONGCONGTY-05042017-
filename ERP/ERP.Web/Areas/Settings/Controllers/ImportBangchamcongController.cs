﻿using ERP.Web.Models.BusinessModel;
using ERP.Web.Models.Database;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Web.Areas.Settings.Controllers
{
    public class ImportBangchamcongController : Controller
    {

        XuLyNgayThang xulydate = new XuLyNgayThang();
        int so_dong_thanh_cong;
        int dong;
        string thangchamcong, username, ghichu;
        int ngaychuan;
        double giodimuon, giovesom, tangcangaythuong, tangcangayle, solanquencham, songaynghi, congthucte;
        decimal vaytindung, ungluong;
        ERP_DATABASEEntities db = new ERP_DATABASEEntities();
        // GET: HopLong/ImportExcel

        #region "Import Bảng chấm công"
        public ActionResult Import_Bangchamcong()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Import_Bangchamcong(FormCollection formCollection)
        {
            try
            {
                if (Request != null)
                {
                    HttpPostedFileBase file = Request.Files["UploadedFile"];
                    if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                    {
                        string fileName = file.FileName;
                        string fileContentType = file.ContentType;
                        byte[] fileBytes = new byte[file.ContentLength];
                        var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                        //var usersList = new List<Users>();
                        using (var package = new ExcelPackage(file.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                thangchamcong = workSheet.Cells[rowIterator, 15].Value.ToString();
                                username = workSheet.Cells[rowIterator, 3].Value.ToString();
                                ngaychuan = Convert.ToInt32(workSheet.Cells[rowIterator, 4].Value);
                                giodimuon = Convert.ToDouble(workSheet.Cells[rowIterator, 5].Value);
                                giovesom = Convert.ToDouble(workSheet.Cells[rowIterator, 6].Value);
                                tangcangaythuong = Convert.ToDouble(workSheet.Cells[rowIterator, 7].Value);
                                tangcangayle = Convert.ToDouble(workSheet.Cells[rowIterator, 8].Value);
                                solanquencham = Convert.ToDouble(workSheet.Cells[rowIterator, 9].Value);
                                songaynghi = Convert.ToDouble(workSheet.Cells[rowIterator, 10].Value);
                                congthucte = Convert.ToDouble(workSheet.Cells[rowIterator, 11].Value);
                                vaytindung = Convert.ToDecimal(workSheet.Cells[rowIterator, 12].Value);
                                ungluong = Convert.ToDecimal(workSheet.Cells[rowIterator, 13].Value);
                                if (workSheet.Cells[rowIterator, 14].Value != null)
                                   ghichu = workSheet.Cells[rowIterator, 14].Value.ToString();





                                CCTC_BANG_CHAM_CONG bcc = new CCTC_BANG_CHAM_CONG();
                                bcc.THANG_CHAM_CONG = thangchamcong;
                                bcc.USERNAME = username;
                                bcc.NGAY_CHUAN = ngaychuan;
                                bcc.GIO_DI_MUON = giodimuon;
                                bcc.GIO_VE_SOM = giovesom;
                                bcc.TANG_CA_NGAY_THUONG = tangcangaythuong;
                                bcc.TANG_CA_NGAY_LE = tangcangayle;
                                bcc.SO_LAN_QUEN_CHAM = solanquencham;
                                bcc.SO_NGAY_NGHI = songaynghi;
                                bcc.CONG_THUC_TE = congthucte;
                                bcc.VAY_TIN_DUNG = vaytindung;
                                bcc.UNG_LUONG = ungluong;
                                bcc.GHI_CHU = ghichu;

                                CCTC_BANG_LUONG bangluong = new CCTC_BANG_LUONG();
                                var querytinhluong = db.NV_TINH_LUONG.Where(x => x.USERNAME == username).FirstOrDefault();
                                if(querytinhluong != null)
                                {
                                    bangluong.USERNAME = username;
                                    bangluong.THANG_LUONG = thangchamcong;
                                    bangluong.LUONG_CO_BAN = querytinhluong.LUONG_CO_BAN;
                                    bangluong.LUONG_BAO_HIEM = querytinhluong.LUONG_BAO_HIEM;
                                    bangluong.PHU_CAP_AN_TRUA = querytinhluong.PHU_CAP_AN_TRUA;
                                    bangluong.PHU_CAP_DI_LAI_DIEN_THOAI = querytinhluong.PHU_CAP_DI_LAI_DIEN_THOAI;
                                    bangluong.PHU_CAP_THUONG_DOANH_SO = querytinhluong.PHU_CAP_DI_LAI_DIEN_THOAI;
                                    bangluong.PHU_CAP_TRACH_NHIEM = querytinhluong.PHU_CAP_TRACH_NHIEM;
                                    bangluong.CONG_CO_BAN = ngaychuan;
                                    bangluong.LUONG_CO_BAN_NGAY = (querytinhluong.LUONG_CO_BAN/ngaychuan);
                                    bangluong.LUONG_CO_BAN_GIO = (bangluong.LUONG_CO_BAN_NGAY / 8);
                                    bangluong.BAO_HIEM_CONG_TY_DONG = (querytinhluong.LUONG_BAO_HIEM * Convert.ToDecimal(0.22));
                                    bangluong.BAO_HIEM_NHAN_VIEN_DONG = (querytinhluong.LUONG_BAO_HIEM * Convert.ToDecimal(0.105));
                                    bangluong.LUONG_THUC_TE_CONG_LAM_THUC = congthucte;
                                    bangluong.LUONG_THUC_TE_SO_TIEN = (Convert.ToDecimal(congthucte) * bangluong.LUONG_CO_BAN_NGAY);
                                    bangluong.LUONG_LAM_THEM_CONG_NGAY_THUONG = tangcangaythuong;
                                    bangluong.LUONG_LAM_THEM_TIEN_CONG_NGAY_THUONG = bangluong.LUONG_CO_BAN_GIO * Convert.ToDecimal(bangluong.LUONG_LAM_THEM_CONG_NGAY_THUONG * 1.5);
                                    bangluong.LUONG_LAM_THEM_CONG_NGAY_NGHI = 0;
                                    bangluong.LUONG_LAM_THEM_TIEN_CONG_NGAY_NGHI = bangluong.LUONG_CO_BAN_GIO * Convert.ToDecimal(bangluong.LUONG_LAM_THEM_CONG_NGAY_NGHI * 2);
                                    bangluong.LUONG_LAM_THEM_CONG_NGAY_LE = tangcangayle;
                                    bangluong.LUONG_LAM_THEM_TIEN_CONG_NGAY_LE = bangluong.LUONG_CO_BAN_GIO * Convert.ToDecimal(bangluong.LUONG_LAM_THEM_CONG_NGAY_LE * 3);
                                    bangluong.TONG_THU_NHAP = bangluong.PHU_CAP_AN_TRUA + bangluong.PHU_CAP_DI_LAI_DIEN_THOAI + bangluong.PHU_CAP_THUONG_DOANH_SO + bangluong.PHU_CAP_TRACH_NHIEM + bangluong.LUONG_THUC_TE_SO_TIEN + bangluong.LUONG_LAM_THEM_TIEN_CONG_NGAY_THUONG + bangluong.LUONG_LAM_THEM_TIEN_CONG_NGAY_NGHI + bangluong.LUONG_LAM_THEM_TIEN_CONG_NGAY_LE;
                                    bangluong.TAM_UNG = ungluong;
                                    bangluong.VAY_TIN_DUNG = vaytindung;
                                    bangluong.GIO_DI_TRE = giodimuon + giovesom;
                                    bangluong.PHAT_DI_TRE = Convert.ToDecimal(bangluong.GIO_DI_TRE) * bangluong.LUONG_CO_BAN_GIO * 2;
                                    bangluong.CONG_DOAN = querytinhluong.LUONG_CO_BAN * Convert.ToDecimal(0.02);
                                    bangluong.LUONG_LAO_CONG = querytinhluong.LUONG_LAO_CONG;
                                    //bangluong.THUC_LINH = 
                                }

                                   




                                db.CCTC_BANG_CHAM_CONG.Add(bcc);
                                db.SaveChanges();
                                so_dong_thanh_cong++;
                                dong = rowIterator;
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                ViewBag.Error = " Đã xảy ra lỗi, Liên hệ ngay với admin. " + Environment.NewLine + " Thông tin chi tiết về lỗi:" + Environment.NewLine + Ex;
                ViewBag.Information = "Lỗi tại dòng thứ: " + dong;

            }
            finally
            {
                ViewBag.Message = "Đã import thành công " + so_dong_thanh_cong + " dòng";
            }
            return View("Import_Bangchamcong");
        }
        #endregion
    }
}