using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using ShopLapTop.Areas.Admin.Models;
namespace ShopLapTop.Controllers
{
    public class ProductController : Controller
    {
        laptop lt = new laptop();
        // GET: Product
        [HttpGet]
        public ActionResult tim(string ten, int? page)
        {
            if (ten != null)
            {
                var kq = lt.Sanphams.Where(x => x.TenSP.Contains(ten)).
                OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                ViewBag.t = ten;
                ViewBag.kq = kq;
                return View(kq);
            }
            return View();
        }
        [HttpPost]
        public ActionResult tim(FormCollection form, int? page, int pagesize = 8)
        {
            var ten = form["txttim"];
            ViewBag.t = ten;
            var kq = lt.Sanphams.Where(x => x.TenSP.Contains(ten)).
                OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
            int dem = kq.TotalItemCount;
            ViewBag.dem = dem;
            ViewBag.kq = kq;
         
            return View(kq);
        }
        public ActionResult chitietsanpham(int id)
        {

            List<Sanpham> kq = lt.Sanphams.Where(x => x.MaSP == id).ToList();
            ViewBag.kq = kq;
            return View();
        }
        public class GiaTien
        {
            public string V { get; set; }
            public string D { get; set; }
        }
        public class Intel
        {
            public string V { get; set; }
            public string D { get; set; }
        }

        [HttpGet]
        public ActionResult timkiemnangcao(int? page, string tim, string gia,string cpu)
        {
            Intel cpu1 = new Intel() { V = "all", D = "Tất cả" };
            Intel cpu2 = new Intel() { V = "i3", D = "Core i3" };
            Intel cpu3 = new Intel() { V = "i5", D = "Core i5" };
            Intel cpu4 = new Intel() { V = "i7", D = "Core i7" };
            Intel cpu5 = new Intel() { V = "pen", D = "Pentinum" };
            Intel cpu6 = new Intel() { V = "adm", D = "ADM" };
            ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu1.V);

            GiaTien gt1 = new GiaTien() { V = "100", D = "Tất cả" };
            GiaTien gt2 = new GiaTien() { V = "10", D = "Dưới 10 triệu" };
            GiaTien gt3 = new GiaTien() { V = "15", D = "Dưới 15 triệu" };
            GiaTien gt4 = new GiaTien() { V = "20", D = "Dưới 20 triệu" };
            GiaTien gt5 = new GiaTien() { V = "25", D = "Dưới 25 triệu" };
            GiaTien gt6 = new GiaTien() { V = "26", D = "Trên 25 triệu" };
            ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gt1.V);

            //ViewBag.ten = tim;
            //ViewBag.tien = gia;
            //ViewBag.cpu = cpu;
            if (tim != null)
            {
                if (gia == gt1.V && cpu == cpu1.V)
                {
                    var kq = lt.Sanphams.Where(x => x.TenSP.Contains(tim)).OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                    ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                    ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                    ViewBag.ten = tim;
                    ViewBag.tien = gia;
                    ViewBag.cpu = cpu;
                    return View(kq);
                }

                if (cpu == cpu1.V)
                {
                    if (gia == gt1.V)
                    {
                        var kq = lt.Sanphams.Where(x => x.TenSP.ToLower().Contains(tim.ToLower()))
                            .OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8).OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                        ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                        ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                        ViewBag.ten = tim;
                        ViewBag.tien = gia;
                        ViewBag.cpu = cpu;
                        return View(kq);
                    }
                    if (gia == gt2.V)
                    {
                        var kq = lt.Sanphams.Where(x => x.TenSP.Contains(tim) && x.Giaban < 10000000).
                            OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                        ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                        ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                        ViewBag.ten = tim;
                        ViewBag.tien = gia;
                        ViewBag.cpu = cpu;
                        return View(kq);
                    }
                    if (gia == gt3.V)
                    {
                        var kq = lt.Sanphams.Where(x => x.TenSP.Contains(tim) && x.Giaban >= 10000000 && x.Giaban < 15000000).
                            OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                        ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                        ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                        ViewBag.ten = tim;
                        ViewBag.tien = gia;
                        ViewBag.cpu = cpu;
                        return View(kq);
                    }
                    if (gia == gt4.V)
                    {
                        var kq = lt.Sanphams.Where(x => x.TenSP.Contains(tim) && x.Giaban >= 15000000 && x.Giaban < 20000000).
                            OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                        ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                        ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                        ViewBag.ten = tim;
                        ViewBag.tien = gia;
                        ViewBag.cpu = cpu;
                        return View(kq);
                    }
                    if (gia == gt5.V)
                    {
                        var kq = lt.Sanphams.Where(x => x.TenSP.Contains(tim) && x.Giaban >= 20000000 && x.Giaban < 25000000).
                            OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                        ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                        ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                        ViewBag.ten = tim;
                        ViewBag.tien = gia;
                        ViewBag.cpu = cpu;
                        return View(kq);
                    }
                    if (gia == gt6.V)
                    {
                        var kq = lt.Sanphams.Where(x => x.TenSP.Contains(tim) && x.Giaban >= 25000000).
                            OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                        ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                        ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                        ViewBag.ten = tim;
                        ViewBag.tien = gia;
                        ViewBag.cpu = cpu;
                        return View(kq);
                    }
                }
                if (gia == gt1.V)
                {
                    var kq = lt.Sanphams.Where(x => x.TenSP.ToLower().Contains(tim.ToLower())
                    && x.cpu.ToLower().Contains(cpu.ToLower())).OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                    ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                    ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                    ViewBag.ten = tim;
                    ViewBag.tien = gia;
                    ViewBag.cpu = cpu;
                    return View(kq);
                }
                if (gia == gt2.V)
                {
                    var kq = lt.Sanphams.Where(x => x.TenSP.Contains(tim) && x.cpu.Contains(cpu) && x.Giaban < 10000000).
                        OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                    ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                    ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                    ViewBag.ten = tim;
                    ViewBag.tien = gia;
                    ViewBag.cpu = cpu;
                    return View(kq);
                }
                if (gia == gt3.V)
                {
                    var kq = lt.Sanphams.Where(x => x.TenSP.Contains(tim) && x.cpu.Contains(cpu) && x.Giaban >= 10000000 && x.Giaban < 15000000).
                        OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                    ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                    ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                    ViewBag.ten = tim;
                    ViewBag.tien = gia;
                    ViewBag.cpu = cpu;
                    return View(kq);
                }
                if (gia == gt4.V)
                {
                    var kq = lt.Sanphams.Where(x => x.TenSP.Contains(tim) && x.cpu.Contains(cpu) && x.Giaban >= 15000000 && x.Giaban < 20000000).
                        OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                    ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                    ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                    ViewBag.ten = tim;
                    ViewBag.tien = gia;
                    ViewBag.cpu = cpu;
                    return View(kq);
                }
                if (gia == gt5.V)
                {
                    var kq = lt.Sanphams.Where(x => x.TenSP.Contains(tim) && x.cpu.Contains(cpu) && x.Giaban >= 20000000 && x.Giaban < 25000000).
                        OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                    ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                    ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                    ViewBag.ten = tim;
                    ViewBag.tien = gia;
                    ViewBag.cpu = cpu;
                    return View(kq);
                }
                if (gia == gt6.V)
                {
                    var kq = lt.Sanphams.Where(x => x.TenSP.Contains(tim) && x.cpu.Contains(cpu) && x.Giaban >= 25000000).
                        OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                    ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                    ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                    ViewBag.ten = tim;
                    ViewBag.tien = gia;
                    ViewBag.cpu = cpu;
                    return View(kq);
                }
            }
            else if (string.IsNullOrEmpty(tim))
            {
                if (gia == gt1.V && cpu == cpu1.V)
                {
                    var kq = lt.Sanphams.OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                    ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                    ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                    ViewBag.ten = tim;
                    ViewBag.tien = gia;
                    return View(kq);
                }
                if (cpu == cpu1.V)
                {
                    if (gia == gt1.V)
                    {
                        var kq = lt.Sanphams .OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                        ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                        ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                        ViewBag.ten = tim;
                        ViewBag.tien = gia;
                        ViewBag.cpu = cpu;
                        return View(kq);
                    }
                    if (gia == gt2.V)
                    {
                        var kq = lt.Sanphams.Where(x=> x.Giaban < 10000000).
                            OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                        ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                        ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                        ViewBag.ten = tim;
                        ViewBag.tien = gia;
                        ViewBag.cpu = cpu;
                        return View(kq);
                    }
                    if (gia == gt3.V)
                    {
                        var kq = lt.Sanphams.Where(x => x.Giaban >= 10000000 && x.Giaban < 15000000).
                            OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                        ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                        ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                        ViewBag.ten = tim;
                        ViewBag.tien = gia;
                        ViewBag.cpu = cpu;
                        return View(kq);
                    }
                    if (gia == gt4.V)
                    {
                        var kq = lt.Sanphams.Where(x => x.Giaban >= 15000000 && x.Giaban < 20000000).
                            OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                        ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                        ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                        ViewBag.ten = tim;
                        ViewBag.tien = gia;
                        ViewBag.cpu = cpu;
                        return View(kq);
                    }
                    if (gia == gt5.V)
                    {
                        var kq = lt.Sanphams.Where(x => x.Giaban >= 20000000
                        && x.Giaban < 25000000).
                            OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                        ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                        ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                        ViewBag.ten = tim;
                        ViewBag.tien = gia;
                        ViewBag.cpu = cpu;
                        return View(kq);
                    }
                    if (gia == gt6.V)
                    {
                        var kq = lt.Sanphams.Where(x => x.Giaban >= 25000000).
                            OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                        ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                        ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                        ViewBag.ten = tim;
                        ViewBag.tien = gia;
                        ViewBag.cpu = cpu;
                        return View(kq);
                    }
                }
                if (gia == gt1.V)
                {
                    var kq = lt.Sanphams.Where(x => x.cpu.ToLower().Contains(cpu.ToLower()))
                        .OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                    ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                    ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                    ViewBag.ten = tim;
                    ViewBag.tien = gia;
                    ViewBag.cpu = cpu;
                    return View(kq);
                }

                if (gia == gt2.V)
                {
                    var kq = lt.Sanphams.Where(x => x.Giaban < 10000000 && x.cpu.Contains(cpu)).
                        OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                    ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                    ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                    ViewBag.ten = tim;
                    ViewBag.tien = gia;
                    ViewBag.cpu = cpu;
                    return View(kq);
                }
                if (gia == gt3.V)
                {
                    var kq = lt.Sanphams.Where(x => x.Giaban >= 10000000 && x.Giaban < 15000000 && x.cpu.Contains(cpu)).
                        OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                    ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                    ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                    ViewBag.ten = tim;
                    ViewBag.tien = gia;
                    ViewBag.cpu = cpu;
                    return View(kq);
                }
                if (gia == gt4.V)
                {
                    var kq = lt.Sanphams.Where(x => x.Giaban >= 15000000 && x.Giaban < 20000000 && x.cpu.Contains(cpu)).
                        OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                    ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                    ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                    ViewBag.ten = tim;
                    ViewBag.tien = gia;
                    ViewBag.cpu = cpu;
                    return View(kq);
                }
                if (gia == gt5.V)
                {
                    var kq = lt.Sanphams.Where(x => x.Giaban >= 20000000 && x.Giaban < 25000000 && x.cpu.Contains(cpu)).
                        OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                    ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                    ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                    ViewBag.ten = tim;
                    ViewBag.tien = gia;
                    ViewBag.cpu = cpu;
                    return View(kq);
                }
                if (gia == gt6.V)
                {
                    var kq = lt.Sanphams.Where(x => x.Giaban >= 25000000 && x.cpu.Contains(cpu)).
                        OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                    ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                    ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                    ViewBag.ten = tim;
                    ViewBag.tien = gia;
                    ViewBag.cpu = cpu;
                    return View(kq);
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult timkiemnangcao(FormCollection form, int? page, int? pagesize)
        {
            var tim = form["ten"];
            var gia = form["gia"];
            var cpu = form["core"];
            GiaTien gt1 = new GiaTien() { V = "100", D = "Tất cả" };
            GiaTien gt2 = new GiaTien() { V = "10", D = "Dưới 10 triệu" };
            GiaTien gt3 = new GiaTien() { V = "15", D = "Dưới 15 triệu" };
            GiaTien gt4 = new GiaTien() { V = "20", D = "Dưới 20 triệu" };
            GiaTien gt5 = new GiaTien() { V = "25", D = "Dưới 25 triệu" };
            GiaTien gt6 = new GiaTien() { V = "26", D = "Trên 25 triệu" };
            ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gt4.V);

            Intel cpu1 = new Intel() { V = "all", D = "Tất cả" };
            Intel cpu2 = new Intel() { V = "i3", D = "Core i3" };
            Intel cpu3 = new Intel() { V = "i5", D = "Core i5" };
            Intel cpu4 = new Intel() { V = "i7", D = "Core i7" };
            Intel cpu5 = new Intel() { V = "pen", D = "Pentinum" };
            Intel cpu6 = new Intel() { V = "adm", D = "ADM" };
            ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu1.V);

            if (tim.Count() == 0 && gia.Count() > 0)
            {
                if (form["gia"] == gt1.V && form["core"] == cpu1.V)
                {
                    var kq = lt.Sanphams.OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                    ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                    ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                    ViewBag.ten = tim;
                    ViewBag.tien = gia;
                    ViewBag.cpu = cpu;
                    return View(kq);
                }
                if (form["core"] == cpu1.V)
                {
                    if (form["gia"] == gt1.V)
                    {
                        var kq = lt.Sanphams
                            .OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                        ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                        ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                        ViewBag.ten = tim;
                        ViewBag.tien = gia;
                        ViewBag.cpu = cpu;
                        return View(kq);
                    }
                    if (form["gia"] == gt2.V)
                    {
                        var kq = lt.Sanphams.Where(x => x.Giaban < 10000000).
                            OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                        ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                        ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                        ViewBag.ten = tim;
                        ViewBag.tien = gia;
                        ViewBag.cpu = cpu;
                        return View(kq);
                    }
                    if (form["gia"] == gt3.V)
                    {
                        var kq = lt.Sanphams.Where(x => x.Giaban >= 10000000 && x.Giaban < 15000000).
                            OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                        ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                        ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                        ViewBag.ten = tim;
                        ViewBag.tien = gia;
                        ViewBag.cpu = cpu;
                        return View(kq);
                    }
                    if (form["gia"] == gt4.V)
                    {
                        var kq = lt.Sanphams.Where(x => x.Giaban >= 15000000 && x.Giaban < 20000000).
                            OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                        ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                        ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                        ViewBag.ten = tim;
                        ViewBag.tien = gia;
                        ViewBag.cpu = cpu;
                        return View(kq);
                    }
                    if (form["gia"] == gt5.V)
                    {
                        var kq = lt.Sanphams.Where(x => x.Giaban >= 20000000 && x.Giaban < 25000000).
                            OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                        ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                        ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                        ViewBag.ten = tim;
                        ViewBag.tien = gia;
                        ViewBag.cpu = cpu;
                        return View(kq);
                    }
                    if (form["gia"] == gt6.V)
                    {
                        var kq = lt.Sanphams.Where(x =>  x.Giaban >= 25000000).
                            OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                        ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                        ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                        ViewBag.ten = tim;
                        ViewBag.tien = gia;
                        ViewBag.cpu = cpu;
                        return View(kq);
                    }
                }
                if (form["gia"] == gt1.V)
                {
                    var kq = lt.Sanphams.Where(x => x.cpu.ToLower().Contains(cpu.ToLower()))
                        .OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                    ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                    ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                    ViewBag.ten = tim;
                    ViewBag.tien = gia;
                    ViewBag.cpu = cpu;
                    return View(kq);
                }
                if (form["gia"] == gt2.V)
                {
                    var kq = lt.Sanphams.Where(x => x.Giaban < 10000000 && x.cpu.Contains(cpu)).OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                    ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                    ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                    ViewBag.ten = tim;
                    ViewBag.tien = gia;
                    ViewBag.cpu = cpu;
                    return View(kq);
                }
                if (form["gia"] == gt3.V)
                {
                    var kq = lt.Sanphams.Where(x => x.Giaban >= 10000000
                    && x.Giaban < 15000000 && x.cpu.Contains(cpu)).
                        OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                    ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                    ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                    ViewBag.ten = tim;
                    ViewBag.tien = gia;
                    ViewBag.cpu = cpu;
                    return View(kq);
                }
                if (form["gia"] == gt4.V)
                {
                    var kq = lt.Sanphams.Where(x => x.Giaban >= 15000000
                    && x.Giaban < 20000000 && x.cpu.Contains(cpu))
                        .OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                    ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                    ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                    ViewBag.ten = tim;
                    ViewBag.tien = gia;
                    ViewBag.cpu = cpu;
                    return View(kq);
                }
                if (form["gia"] == gt5.V)
                {
                    var kq = lt.Sanphams.Where(x => x.Giaban >= 20000000
                    && x.Giaban < 25000000 && x.cpu.Contains(cpu))
                        .OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                    ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                    ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                    ViewBag.ten = tim;
                    ViewBag.tien = gia;
                    ViewBag.cpu = cpu;
                    return View(kq);
                }
                if (form["gia"] == gt6.V)
                {
                    var kq = lt.Sanphams.Where(x => x.Giaban >= 25000000 && x.cpu.Contains(cpu))
                        .OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                    ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                    ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                    ViewBag.ten = tim;
                    ViewBag.tien = gia;
                    ViewBag.cpu = cpu;
                    return View(kq);
                }

            }
            else if (tim.Count() > 0)
            {
                if (form["gia"] == gt1.V && form["core"] == cpu1.V)
                {
                    var kq = lt.Sanphams.Where(x => x.TenSP.Contains(tim)).OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                    ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                    ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                    ViewBag.ten = tim;
                    ViewBag.tien = gia;
                    ViewBag.cpu = cpu;
                    return View(kq);
                }
                if (form["core"] == cpu1.V)
                {
                    if (form["gia"] == gt1.V)
                    {
                        var kq = lt.Sanphams.Where(x => x.TenSP.ToLower().Contains(tim.ToLower()))
                            .OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                        ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                        ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                        ViewBag.ten = tim;
                        ViewBag.tien = gia;
                        ViewBag.cpu = cpu;
                        return View(kq);
                    }
                    if (form["gia"] == gt2.V)
                    {
                        var kq = lt.Sanphams.Where(x => x.TenSP.Contains(tim) && x.Giaban < 10000000).
                            OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                        ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                        ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                        ViewBag.ten = tim;
                        ViewBag.tien = gia;
                        ViewBag.cpu = cpu;
                        return View(kq);
                    }
                    if (form["gia"] == gt3.V)
                    {
                        var kq = lt.Sanphams.Where(x => x.TenSP.Contains(tim) && x.Giaban >= 10000000 && x.Giaban < 15000000).
                            OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                        ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                        ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                        ViewBag.ten = tim;
                        ViewBag.tien = gia;
                        ViewBag.cpu = cpu;
                        return View(kq);
                    }
                    if (form["gia"] == gt4.V)
                    {
                        var kq = lt.Sanphams.Where(x => x.TenSP.Contains(tim) && x.Giaban >= 15000000 && x.Giaban < 20000000).
                            OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                        ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                        ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                        ViewBag.ten = tim;
                        ViewBag.tien = gia;
                        ViewBag.cpu = cpu;
                        return View(kq);
                    }
                    if (form["gia"] == gt5.V)
                    {
                        var kq = lt.Sanphams.Where(x => x.TenSP.Contains(tim) && x.Giaban >= 20000000 && x.Giaban < 25000000).
                            OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                        ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                        ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                        ViewBag.ten = tim;
                        ViewBag.tien = gia;
                        ViewBag.cpu = cpu;
                        return View(kq);
                    }
                    if (form["gia"] == gt6.V)
                    {
                        var kq = lt.Sanphams.Where(x => x.TenSP.Contains(tim) && x.Giaban >= 25000000).
                            OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                        ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                        ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                        ViewBag.ten = tim;
                        ViewBag.tien = gia;
                        ViewBag.cpu = cpu;
                        return View(kq);
                    }
                }
                if (form["gia"] == gt1.V)
                {
                    var kq = lt.Sanphams.Where(x => x.TenSP.ToLower().Contains(tim.ToLower())
                    && x.cpu.ToLower().Contains(cpu.ToLower())).OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                    ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                    ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                    ViewBag.ten = tim;
                    ViewBag.tien = gia;
                    ViewBag.cpu = cpu;
                    return View(kq);
                }
                if (form["gia"] == gt2.V)
                {
                    var kq = lt.Sanphams.Where(x => x.TenSP.Contains(tim) && x.cpu.Contains(cpu) && x.Giaban < 10000000)
                        .OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                    ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                    ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                    ViewBag.ten = tim;
                    ViewBag.tien = gia;
                    ViewBag.cpu = cpu;
                    return View(kq);
                }
                if (form["gia"] == gt3.V)
                {
                    var kq = lt.Sanphams.Where(x => x.TenSP.Contains(tim) && x.cpu.Contains(cpu) && x.Giaban >= 10000000 && x.Giaban < 15000000)
                        .OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                    ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                    ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                    ViewBag.ten = tim;
                    ViewBag.tien = gia;
                    ViewBag.cpu = cpu;
                    return View(kq);
                }
                if (form["gia"] == gt4.V)
                {
                    var kq = lt.Sanphams.Where(x => x.TenSP.Contains(tim)
                    && x.cpu.Contains(cpu) && x.Giaban >= 15000000 && x.Giaban < 20000000)
                        .OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                    ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                    ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                    ViewBag.ten = tim;
                    ViewBag.tien = gia;
                    ViewBag.cpu = cpu;
                    return View(kq);
                }
                if (form["gia"] == gt5.V)
                {
                    var kq = lt.Sanphams.Where(x => x.TenSP.Contains(tim) && x.cpu.Contains(cpu)
                    && x.Giaban >= 20000000 && x.Giaban < 25000000)
                        .OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                    ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                    ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                    ViewBag.ten = tim;
                    ViewBag.tien = gia;
                    ViewBag.cpu = cpu;
                    return View(kq);
                }
                if (form["gia"] == gt6.V)
                {
                    var kq = lt.Sanphams.Where(x => x.TenSP.Contains(tim) && x.cpu.Contains(cpu) && x.Giaban >= 25000000)
                        .OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                    ViewBag.Gia = new SelectList(new List<GiaTien> { gt1, gt2, gt3, gt4, gt5, gt6 }, "V", "D", gia);
                    ViewBag.core = new SelectList(new List<Intel> { cpu1, cpu2, cpu3, cpu4, cpu5, cpu6 }, "V", "D", cpu);
                    ViewBag.ten = tim;
                    ViewBag.tien = gia;
                    ViewBag.cpu = cpu;
                    return View(kq);
                }

            }
            return View();

        }
        [HttpGet]
        public ActionResult asus(int id)
        {
            List<Loai> loai = lt.Loais.Where(x => x.Maloai == id).ToList();
            ViewBag.loai = loai;
            return View();
        }
        [HttpPost]
        public ActionResult asus()
        {
            return View();
        }
    }
}