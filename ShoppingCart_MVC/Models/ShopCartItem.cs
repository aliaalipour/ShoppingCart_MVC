using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart_MVC.Models
{

    //قرار دادن شماره و تعداد محصولات در سیشن
    public class ShopCartItem
    {
        public int ProductID { get; set; }
        public int Count { get; set; }

    }

   //نمایش کامل سبد خرید
   public class ShopCartViewModel
    {
        public int ProductID { get; set; }
        public string Title { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public string ImageName { get; set; }
        public int Sum { get; set; }
    }

}