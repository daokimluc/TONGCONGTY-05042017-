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
using System.Threading.Tasks;
using ERP.Web.Models.NewModels;
using ERP.Web.Models.BusinessModel;

namespace ERP.Web.Api.Kho
{
    public class Api_ChiTietKhoGiuHangController : ApiController
    {
        private ERP_DATABASEEntities db = new ERP_DATABASEEntities();
        XuLyNgayThang xlnt = new XuLyNgayThang();
        string mkh;
        // GET: api/Api_ChiTietKhoGiuHang
        [Route("api/Api_ChiTietKhoGiuHang/{ma_giu_kho}")]
        public List<Khogiuhang> GetKHO_CT_GIU_HANG(string ma_giu_kho)
        {
            var vData = (from t1 in db.KHO_GIU_HANG
                         join t2 in db.KHO_CT_GIU_HANG on t1.MA_GIU_KHO equals t2.MA_GIU_KHO
                         where t1.MA_GIU_KHO == ma_giu_kho
                         select new
                         {
                             t2.MA_HANG,
                             t2.SL_GIU,
                             t2.NGAY_XUAT,
                             t2.DA_XUAT,
                             t2.GHI_CHU
                         });
            var result = vData.ToList().Select(x => new Khogiuhang()
            {
                MA_HANG = x.MA_HANG,
                SL_GIU = x.SL_GIU,
                NGAY_XUAT = x.NGAY_XUAT.ToString(),
                DA_XUAT = x.DA_XUAT,
                GHI_CHU = x.GHI_CHU
            }).ToList();
            return result;
        }

        // GET: api/Api_ChiTietKhoGiuHang/5
        [ResponseType(typeof(KHO_CT_GIU_HANG))]
        public IHttpActionResult GetKHO_CT_GIU_HANG()
        {
            KHO_CT_GIU_HANG kHO_CT_GIU_HANG = db.KHO_CT_GIU_HANG.Find();
            if (kHO_CT_GIU_HANG == null)
            {
                return NotFound();
            }

            return Ok(kHO_CT_GIU_HANG);
        }

        // PUT: api/Api_ChiTietKhoGiuHang/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKHO_CT_GIU_HANG(int id, KHO_CT_GIU_HANG kHO_CT_GIU_HANG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kHO_CT_GIU_HANG.ID)
            {
                return BadRequest();
            }

            db.Entry(kHO_CT_GIU_HANG).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KHO_CT_GIU_HANGExists(id))
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

        [Route("api/Api_ChiTietKhoGiuHang/GetMaGiuHang")]
        public string GetMaGiuHang()
        {
            var query = db.Database.SqlQuery<string>("XL_LayMaGiuHangMoiNhat");


            if (query.Count() > 0)
            {
                mkh = query.FirstOrDefault();
            }
            return mkh;
        }

        // POST: api/Api_ChiTietKhoGiuHang
        //[HttpPost]
        //[Route("api/Api_ChiTietKhoGiuHang/{ma_giu_kho}")]
        //public async Task<IHttpActionResult> PostMultiKHO_CT_GIU_HANG(string ma_giu_kho, [FromBody] List<KHO_CT_GIU_HANG> giuhang)
        //{
        //    for (int i = 0; i < giuhang.Count(); i++)
        //    {
        //        //nH_NTTKs[i].ID = (index + i + 1).ToString();
        //        db.KHO_CT_GIU_HANG.Add(giuhang[i]);
        //    }
        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(ex.Message);
        //    }
        //    return Ok(giuhang);
        //}

        [ResponseType(typeof(KHO_CT_GIU_HANG))]
        public void PostKHO_CT_GIU_HANG(List<Khogiuhang> lh)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            foreach (var item in lh)
            {
                KHO_CT_GIU_HANG lienhe = new KHO_CT_GIU_HANG();
                lienhe.MA_GIU_KHO = item.MA_GIU_KHO;
                lienhe.MA_HANG = item.MA_HANG;
                lienhe.SL_GIU = item.SL_GIU;
                lienhe.DA_XUAT = item.DA_XUAT;
                lienhe.GHI_CHU = item.GHI_CHU;
                if (item.NGAY_XUAT != "")
                    lienhe.NGAY_XUAT = xlnt.Xulydatetime(item.NGAY_XUAT);
                db.KHO_CT_GIU_HANG.Add(lienhe);
                db.SaveChanges();
            }
        }

        // DELETE: api/Api_ChiTietKhoGiuHang/5
        [ResponseType(typeof(KHO_CT_GIU_HANG))]
        public IHttpActionResult DeleteKHO_CT_GIU_HANG(int id)
        {
            KHO_CT_GIU_HANG kHO_CT_GIU_HANG = db.KHO_CT_GIU_HANG.Find(id);
            if (kHO_CT_GIU_HANG == null)
            {
                return NotFound();
            }

            db.KHO_CT_GIU_HANG.Remove(kHO_CT_GIU_HANG);
            db.SaveChanges();

            return Ok(kHO_CT_GIU_HANG);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KHO_CT_GIU_HANGExists(int id)
        {
            return db.KHO_CT_GIU_HANG.Count(e => e.ID == id) > 0;
        }
    }
}