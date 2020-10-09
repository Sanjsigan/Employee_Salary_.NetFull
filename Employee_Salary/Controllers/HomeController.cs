using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Employee_Salary.Models;

namespace Employee_Salary.Controllers
{

    
    public class HomeController : Controller
    {
  
        public IActionResult Index()
        {
            return View(new salary());
        }

        [HttpPost]
        public IActionResult Index(salary s)
        {
            s.tax = s.price * 5 / 100;
            s.travel = s.price * 5 / 100;
            s.medical = s.price * 5 / 100;
            if (s.price < 200000)
            {
               
                s.minus = (s.tax + s.travel + s.medical);

                s.total_price = s.price - s.minus;
            }
            else if(s.price>=200000 && s.price <= 400000)
            {
                s.extra = s.price - 200000;
                s.finaltax1 = s.extra * 5 / 100;
                s.minus = (s.tax + s.medical + s.travel + s.finaltax1);
                s.total_price = s.price - s.minus;

            }
            else if(s.price>=400000 && s.price <= 800000)
            {
                s.extra = s.price - 400000;
                s.finaltax1 = (s.price - 200000) * 5 / 100;
                s.finaltax2 = s.extra * 10 / 100;
                s.minus = (s.tax + s.travel + s.medical + s.finaltax1 + s.finaltax2);
                s.total_price = s.price - s.minus;

            }
            else if(s.price>=800000 && s.price <= 1200000)
            {
                s.extra = s.price - 800000;
                s.finaltax1 = (s.price - 200000) * 5 / 100;
                s.finaltax2= (s.price - 400000) * 10/ 100;
                s.finaltax3 = s.extra * 20 / 100;

                s.minus = (s.tax + s.travel + s.medical + s.finaltax1 + s.finaltax2+s.finaltax3);
                s.total_price = s.price - s.minus;
            }
            else
            {
                s.extra = s.price - 1200000;
                s.finaltax1 = (s.price - 200000) * 5 / 100;
                s.finaltax2 = (s.price - 400000) * 10 / 100;
                s.finaltax3 = (s.price - 800000) * 20 / 100;
                s.finaltax4 = s.extra * 25 / 100;

                s.minus = (s.tax + s.travel + s.medical + s.finaltax1 + s.finaltax2 + s.finaltax3+s.finaltax4);
                s.total_price = s.price - s.minus;
            }
            return View(s);
        }
        
    }
}
