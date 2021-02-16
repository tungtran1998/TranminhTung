
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DangBang_1621050884.Models.MyProcess;

namespace DangBang_1621050884.Controllers
{
    public class BaitapController : Controller
    {
        XuLy xl = new XuLy();
        public ActionResult Bai1(string HeSoa, string HeSob, string HeSoc)
        {
            double a, b, c;
            a = Convert.ToDouble(HeSoa);
            b = Convert.ToDouble(HeSob);
            c = Convert.ToDouble(HeSoc);
            double delta = b * b - 4 * a * c;
            double X1, X2;
            if (delta > 0)
            {
                X1 = (-b + Math.Sqrt(delta)) / (2 * a);
                X2 = (-b - Math.Sqrt(delta)) / (2 * a);
                ViewBag.Ketqua = "Phương trình có hai nghiệm phân biệt:";
                ViewBag.Value = "x1 = " + X1 + ", x2 = " + X2;
            }
            else if (delta == 0)
            {
                X1 = X2 = -b / (2 * a);
                ViewBag.Ketqua = "Phương trình có nghiệm kép:";
                ViewBag.Value = "x1 = x2 = " + X2;
            }
            else
            {
                ViewBag.Ketqua = "Phương trình vô nghiệm";
            }
            return View();

        }
        public ActionResult Bai2(string son)
        {
            int n;
            double s = 0;
            n = Convert.ToInt32(son);
            for (double i = 1; i <= n; i++)
            {
                s = s + 1 / i;
            }
            ViewBag.Ketqua = "Tổng là :" + s;
            return View();
        }
        [HttpPost]
        public ActionResult Bai3(string sox)
        {
            double n;
            int tong = 0;
            n = Convert.ToDouble(sox);
            List<int> soNguyenTo = new List<int>();
            for (int i = 1; i < n; i++)
            {
                if (kiemtrasonguyento(i)) 
                {
                    soNguyenTo.Add(i); 
                }
            }

            foreach (int z in soNguyenTo) 
            {
                int check = tong + z;
                if (check <= 100)
                {
                    tong += z;
                }
            }

            ViewBag.Tong = tong;
            return View();
        }

        bool kiemtrasonguyento(int number)
        {
            int bien_dem = 0;
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    bien_dem++;
                }
            }
            if (bien_dem == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpPost]
        public ActionResult Bai4(string sox)
        {
            int n;
            int tong = 0;
            n = Convert.ToInt32(sox);
            List<int> soNguyenTo = new List<int>();

            if (xl.kiemtraSNT(n))
            {
                ViewBag.snt = n + " là số nguyên tố";
            }
            for (int i = 1; i < n; i++)
            {
                if (xl.kiemtraSNT(i))
                {
                    soNguyenTo.Add(i);
                }
            }

            foreach (int z in soNguyenTo)
            {
                int check = tong + z;
                if (check <= 100)
                {
                    tong += z;
                }
            }

            ViewBag.Tong = "Tổng các số nguyên tố nhỏ hơn " + n + " là: " + tong;
            return View();
        }
    }
}