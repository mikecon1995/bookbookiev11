using bookbookiev11.Data;
using bookbookiev11.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Session;
using bookbookiev11.Repository;
using bookbookiev11.VeiwModels;
using bookbookiev11.Interface;

namespace bookbookiev11.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IBook _bookRepository;
        private readonly ShoppingCartRepo _shoppingCartRepo;
        
        public  CheckoutController(IBook bookRepository, ShoppingCartRepo shoppingCartRepo)
        {
            bookRepository = _bookRepository;
            shoppingCartRepo = _shoppingCartRepo;
        }
        
        public ViewResult Index()
        {
            //var items = _shoppingCartRepo.GetShoppingCartItems();
            //_shoppingCartRepo.ShoppingCartItems = items;

            //var sCVM = new ShoppingCartViewModel
            // {
            //ShoppingCart = _shoppingCartRepo,
            //ShoppingCartTotal = _shoppingCartRepo.GetShoppingCartTotal()
            //};
            //return View(sCVM);
            return View();
        }
        public RedirectToActionResult AddToShoppingCart(int bookId)
        {
            var selectedBook = _bookRepository.books.FirstOrDefault(p => p.Id == bookId);
            if (selectedBook != null)
            {
                _shoppingCartRepo.AddToCart(selectedBook, 1);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromShoppingCart(int bookId)
        {
            var selectedBook = _bookRepository.books.FirstOrDefault(p => p.Id == bookId);
            if(selectedBook != null)
            {
                _shoppingCartRepo.RemoveFromCart(selectedBook);
            }
            return RedirectToAction("Index");
        }
    }
}
