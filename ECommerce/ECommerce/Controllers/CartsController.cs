using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Models.Interfaces;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    public class CartsController : Controller
    {
        private readonly StoreDbContext _context;
        private readonly ICart _cart;

        public CartsController(ICart cart, StoreDbContext context)
        {
            _context = context;
            _cart = cart;
        }

        // GET: Carts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cart.ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetCartItems()
        {
            return await _cart.GetCartItems();
        }

        [HttpPost("{cartId}/products/{productId}")]
        public async Task AddToCart(int cartId, int productId)
        {
            await _cart.AddToCart(cartId, productId);
        }

        //// GET: Carts/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cart = await _context.Cart
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (cart == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(cart);
        //}

        // GET: Carts/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Carts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,ProductId,Quantity,DateAdded")] Cart cart)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(cart);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(cart);
        //}

        //// GET: Carts/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cart = await _context.Cart.FindAsync(id);
        //    if (cart == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(cart);
        //}

        //// POST: Carts/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,Quantity,DateAdded")] Cart cart)
        //{
        //    if (id != cart.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(cart);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CartExists(cart.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(cart);
        //}

        //// GET: Carts/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cart = await _context.Cart
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (cart == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(cart);
        //}

        //// POST: Carts/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var cart = await _context.Cart.FindAsync(id);
        //    _context.Cart.Remove(cart);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CartExists(int id)
        //{
        //    return _context.Cart.Any(e => e.Id == id);
        //}
    }
}