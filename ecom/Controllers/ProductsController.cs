using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ecom.Models;
using ecom.Data;

namespace ecom.Controllers
{
    [Route("predmeti")]
    public class ProductsController : Controller
    {
        private readonly ProductContext _context;

        public ProductsController(ProductContext context)
        {
            _context = context;
        }

        // GET: Products (by category)
        [Route("{category?}/{subcategory?}")]
        public async Task<IActionResult> Index(string? category, string? subcategory)
        {
            if(category == null && subcategory == null)
            {
                return View(await _context.Products.ToListAsync());
            }
            if(subcategory == null)
            {
                return View(await _context.Products.Where(c => c.Category.Name == category).ToListAsync());
            }
            else
            {
                return View(await _context.Products.Where(c => c.Category.Name == category && c.SubCategory.Name == subcategory).ToListAsync());
            }
        }

        [Route("detalji/{id?}")]
        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [Route("dodavanje")]
        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("dodavanje")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
        [Bind("Name,StartingPrice,Description,AuctionStart,AuctionEnd,CategoryId,SubCategoryId,IsNew,IsHighlighted,IsAdvertised,HasExtraPictures,IsStartTimeAdjusted,IsEndTimeAdjusted")] 
        Product product)
        {
            /* if (ModelState.IsValid)
            { */
            try{
                product.OfferCount = 0;
                product.IsSold = false;
                product.SellerId = 0;
                product.BuyerId = 0;
                product.ImagesUrl = "";
                product.IsSeeded = false;
                product.CurrentPrice = 0;
                //product.SellerId = User.userid; headimageurl isseeded currentprice
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch(DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " + 
                "Try again, and if the problem persists, contact your " + 
                "system administrator.");
            } 
            /* } */
            ModelState.AddModelError("", "Please choose a valid image file and writer for the article.");
            return View(product);
        }

        [Route("izmjena/{id?}")]
        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        [Route("brisanje/{id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
