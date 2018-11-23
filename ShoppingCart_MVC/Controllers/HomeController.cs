using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart_MVC.Models;

namespace ShoppingCart_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Product> Products = CreateDatabase();

            return View(Products);
        }


        //اگر محصولات در پایگاه داده ما وجود نداشت این متد اجرا میشه
        public List<Product> CreateDatabase()
        {
            DatabaseContext db = new DatabaseContext();

            //اگر محصولی در جدول نبود، این محصولات را به پایگاه داده اضافه کن
            if (!db.Products.Any())
            {
                //محصول اول 
                db.Products.Add(new Product()
                {
                    Title = "گوجه",
                    Price = 5000,
                    ImageName = "1.jpg",
                });

                //محصول دوم 
                db.Products.Add(new Product()
                {
                    Title = "خامه",
                    Price = 7000,
                    ImageName = "2.jpg",
                });

                //محصول سوم 
                db.Products.Add(new Product()
                {
                    Title = "پیاز",
                    Price = 4000,
                    ImageName = "3.jpg",
                });

                //محصول چهارم 
                db.Products.Add(new Product()
                {
                    Title = "شکلات",
                    Price = 50000,
                    ImageName = "4.jpg",
                });

                //ذخیره در دیتابیس
                db.SaveChanges();

            }

            //تمام محصولات را نشان بده
            return db.Products.ToList();

        }
    }
}