using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart_MVC.Models;

namespace ShoppingCart_MVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        // GET: ShoppingCart
        public ActionResult Index()
        {
            List<ShopCartViewModel> list = new List<ShopCartViewModel>();
            //آیا سیشنی وجود دارد
            if (Session["ShopCart"] != null)
            {
                List<ShopCartItem> cart = Session["ShopCart"] as List<ShopCartItem>;

                foreach (var shopCartItem in cart)
                {
                    var product = db.Products.Find(shopCartItem.ProductID);

                    list.Add(new ShopCartViewModel()
                    {
                        ProductID = shopCartItem.ProductID,
                        Count = shopCartItem.Count,

                        Title = product.Title,
                        Price = product.Price,
                        Sum = shopCartItem.Count * product.Price,
                        ImageName = product.ImageName

                    });
                }
            }

            return View(list);
        }


        //تعداد اقلام موجود در سبد خرید
        public int AddToCart(int id)
        {
            List<ShopCartItem> cart = new List<ShopCartItem>();

            //اگر از قبل خرید داشته کارت رو پر کن
            if (Session["ShopCart"] != null)
            {
                cart = (List<ShopCartItem>)Session["ShopCart"];
            }

            //بیش از یک بار روی محصول کلیک کرده
            if (cart.Any(p => p.ProductID == id))
            {
                //اول باید در لیست ایندکس محصول رو پیدا کنی 
                int index = cart.FindIndex(p => p.ProductID == id);
                cart[index].Count += 1;

            }

            //اولین بار هست که به سبد خریدش اضافه میشه
            else
            {
                cart.Add(new ShopCartItem()
                {
                    ProductID = id,
                    Count = 1
                });
            }
            //مقادیر رو به سیشن اضافه کن
            Session["ShopCart"] = cart;


            //جمع تعداد محصول رو برگردون
            return cart.Sum(p => p.Count);
        }


        //حذف یک قلم در سیشن
        public ActionResult RemoveFromCart(int id)
        {
            List<ShopCartItem> cart = Session["ShopCart"] as List<ShopCartItem>;
            //پیدا کردن ایندکس
            int index = cart.FindIndex(p => p.ProductID == id);
            cart.RemoveAt(index);
            Session["ShopCart"] = cart;

            return RedirectToAction("Index");
        }

        public int ShopCountCart()
        {
            int count = 0;

            //اگر سیشن خالی نبود
            if (Session["ShopCart"] != null)
            {
                List<ShopCartItem> cart = Session["ShopCart"] as List<ShopCartItem>;

                count = cart.Sum(p => p.Count);
            }
            return count;
        }
    }
}