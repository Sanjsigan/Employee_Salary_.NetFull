using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee_Salary.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Salary.Controllers
{
    public class NetToGross : Controller
    {
        public IActionResult Net()
        {
            return View(new salary());
        }


        [HttpPost]
        public IActionResult Net(salary s)
        { 
            s.tot_persantage = 5 + 5 + 5;

            if (s.price <= 200000)
            {
                s.total_price = (s.price / (100 - s.tot_persantage)) * 100;

                s.minus = s.total_price - s.price;
                s.tax = s.total_price * 5 / 100;
                s.medical = s.total_price * 5 / 100;
                s.travel = s.total_price * 5 / 100;

            }
            else if (s.price >= 200000 && s.price <= 400000)
            {
                s.total_price = ((100 * s.price )- 1000000 )/ 80;


            }
            else if (s.price >= 400000 && s.price <= 800000 &&s.price<= 330000)
            {

                s.total_price = (((100 * s.price) - 3000000) / 70 )- 28571.4285714285;
               /* s.extra = s.price - 400000;
                s.finaltax1 = (s.price - 200000) * 5 / 100;
                s.finaltax2 = s.extra * 10 / 100;
                s.minus = (s.tax + s.travel + s.medical + s.finaltax1 + s.finaltax2);
                s.total_price = s.price + s.minus;*/

            }
            else if (s.price >= 610000 && s.price <= 810000)
            {

                s.total_price =(((100 * s.price) - 13000000) / 50)-160000;
                /* s.extra = s.price - 800000;
                 s.finaltax1 = (s.price - 200000) * 5 / 100;
                 s.finaltax2 = (s.price - 400000) * 10 / 100;
                 s.finaltax3 = s.extra * 20 / 100;

                 s.minus = (s.tax + s.travel + s.medical + s.finaltax1 + s.finaltax2 + s.finaltax3);
                 s.total_price = s.price + s.minus;*/
            }
            else
            {
                s.extra = s.price - 1200000;
                s.finaltax1 = (s.price - 200000) * 5 / 100;
                s.finaltax2 = (s.price - 400000) * 10 / 100;
                s.finaltax3 = (s.price - 800000) * 20 / 100;
                s.finaltax4 = s.extra * 25 / 100;

                s.minus = (s.tax + s.travel + s.medical + s.finaltax1 + s.finaltax2 + s.finaltax3 + s.finaltax4);
                s.total_price = s.price + s.minus;
            }
            return View(s);
        }

    }
}

