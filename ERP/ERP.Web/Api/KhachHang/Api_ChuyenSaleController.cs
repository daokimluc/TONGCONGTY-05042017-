﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ERP.Web.Models.Database;
using ERP.Web.Models.NewModels;

namespace ERP.Web.Api.KhachHang
{
    public class Api_ChuyenSaleController : ApiController
    {
        private ERP_DATABASEEntities db = new ERP_DATABASEEntities();
        int id;
        // GET: api/Api_ChuyenSale
        public List<ChuyenSale> GetKH_CHUYEN_SALES()
        {
            var query = db.Database.SqlQuery<ChuyenSale>("XL_CHUYEN_SALES");
            var result = query.ToList().Select(x => new ChuyenSale {
                MA_KHACH_HANG = x.MA_KHACH_HANG,
                TEN_CONG_TY = x.TEN_CONG_TY,
                VAN_PHONG_GIAO_DICH = x.VAN_PHONG_GIAO_DICH,
                DIA_CHI_XUAT_HOA_DON = x.DIA_CHI_XUAT_HOA_DON,
                TINH = x.TINH,
                QUOC_GIA = x.QUOC_GIA,
                SALE_SAP_CHUYEN = x.SALE_SAP_CHUYEN,
                SALE_HIEN_THOI = x.SALE_HIEN_THOI,
                SALE_CU_2 = x.SALE_CU_2,
                SALE_CU = x.SALE_CU,
                HO_VA_TEN = x.TEN_SALE_HIEN_THOI,

            }).ToList();
            //var vData = (from t1 in db.KHs
            //             join t2 in db.KH_CHUYEN_SALES on t1.MA_KHACH_HANG equals t2.MA_KHACH_HANG
            //             join t3 in db.HT_NGUOI_DUNG on t2.SALE_HIEN_THOI equals t3.USERNAME
            //             select new
            //             {
            //                 t1.MA_KHACH_HANG,t1.TEN_CONG_TY,t1.VAN_PHONG_GIAO_DICH,t1.DIA_CHI_XUAT_HOA_DON,t1.TINH,t1.QUOC_GIA,t2.SALE_CU,t2.SALE_CU_2,t2.SALE_HIEN_THOI,t2.SALE_SAP_CHUYEN,t3.HO_VA_TEN
            //             });
            //var result = vData.ToList().Select(x => new ChuyenSale()
            //{
            //    MA_KHACH_HANG = x.MA_KHACH_HANG,
            //    TEN_CONG_TY = x.TEN_CONG_TY,
            //    VAN_PHONG_GIAO_DICH = x.VAN_PHONG_GIAO_DICH,
            //    DIA_CHI_XUAT_HOA_DON = x.DIA_CHI_XUAT_HOA_DON,
            //    TINH = x.TINH,
            //    QUOC_GIA = x.QUOC_GIA,
            //    SALE_SAP_CHUYEN = x.SALE_SAP_CHUYEN,
            //    SALE_HIEN_THOI = x.SALE_HIEN_THOI,
            //    SALE_CU_2 = x.SALE_CU_2,
            //    SALE_CU = x.SALE_CU,
            //    HO_VA_TEN = x.HO_VA_TEN,
            //}).ToList();
            return result;
        }

        // GET: api/Api_ChuyenSale/5
        [ResponseType(typeof(KH_CHUYEN_SALES))]
        public IHttpActionResult GetKH_CHUYEN_SALES(int id)
        {
            KH_CHUYEN_SALES kH_CHUYEN_SALES = db.KH_CHUYEN_SALES.Find(id);
            if (kH_CHUYEN_SALES == null)
            {
                return NotFound();
            }

            return Ok(kH_CHUYEN_SALES);
        }

        // PUT: api/Api_ChuyenSale/5
        [ResponseType(typeof(void))]
        [Route("api/Api_ChuyenSale/{makh}")]
        public IHttpActionResult PutKH_CHUYEN_SALES(string makh, KH_CHUYEN_SALES kH_CHUYEN_SALES)
        {
         
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if (makh != kH_CHUYEN_SALES.MA_KHACH_HANG)
            {
                return BadRequest();
            }

            var query = db.KH_CHUYEN_SALES.Where(x => x.MA_KHACH_HANG == makh).FirstOrDefault();
            if (query != null)
            {
                query.SALE_HIEN_THOI = kH_CHUYEN_SALES.SALE_HIEN_THOI;
                query.SALE_SAP_CHUYEN = kH_CHUYEN_SALES.SALE_SAP_CHUYEN;
                query.SALE_CU = kH_CHUYEN_SALES.SALE_CU;
                query.SALE_CU_2 = kH_CHUYEN_SALES.SALE_CU_2;
            }
            
          //  db.Entry(kH_CHUYEN_SALES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KH_CHUYEN_SALESExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Api_ChuyenSale
        [ResponseType(typeof(KH_CHUYEN_SALES))]
        public IHttpActionResult PostKH_CHUYEN_SALES(KH_CHUYEN_SALES kH_CHUYEN_SALES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KH_CHUYEN_SALES.Add(kH_CHUYEN_SALES);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kH_CHUYEN_SALES.ID }, kH_CHUYEN_SALES);
        }

        // DELETE: api/Api_ChuyenSale/5
        [ResponseType(typeof(KH_CHUYEN_SALES))]
        public IHttpActionResult DeleteKH_CHUYEN_SALES(int id)
        {
            KH_CHUYEN_SALES kH_CHUYEN_SALES = db.KH_CHUYEN_SALES.Find(id);
            if (kH_CHUYEN_SALES == null)
            {
                return NotFound();
            }

            db.KH_CHUYEN_SALES.Remove(kH_CHUYEN_SALES);
            db.SaveChanges();

            return Ok(kH_CHUYEN_SALES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KH_CHUYEN_SALESExists(int id)
        {
            return db.KH_CHUYEN_SALES.Count(e => e.ID == id) > 0;
        }
    }
}