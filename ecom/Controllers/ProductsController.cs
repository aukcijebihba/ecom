using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ecom.Models;
using ecom.Data;

namespace ecom.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductContext _context;

        public ProductsController(ProductContext context)
        {
            _context = context;
        }

        // GET: Products (by category)
        public async Task<IActionResult> Index(string category, string? subcategory)
        {
            if(subcategory == null)
            {
                ViewData["Category"] = await _context.Categories.Where(c => c.Name == category).FirstOrDefaultAsync();
                ViewData["Subcategories"] = await _context.SubCategories.Where(c => c.ParentCategoryName == category).ToListAsync();
                return View(await _context.Products.Where(c => c.Category.Name == category && c.AuctionStart < DateTime.Now && c.AuctionEnd > DateTime.Now).ToListAsync());
            }
            else
            {
                ViewData["Category"] = await _context.Categories.Where(c => c.Name == category).FirstOrDefaultAsync();;
                ViewData["Subcategory"] = await _context.SubCategories.Where(c => c.RouteName == subcategory).FirstOrDefaultAsync();;
                return View(await _context.Products.Where(c => c.Category.Name == category && c.SubCategory.RouteName == subcategory && c.AuctionStart < DateTime.Now && c.AuctionEnd > DateTime.Now).ToListAsync());
            }
        }

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

            product.ViewCount++; //additional logic might be needed
            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            string host = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/";
            ViewData["baseurl"] = host;
            PopulateCategories();
            return View();
        }

        private void PopulateCategories()
        {
            var categories = _context.Categories.ToList();
            ViewData["Categories"] = new SelectList(categories, "Id", "DisplayName", null);
        }

        [HttpPost, ActionName("GetSubCategories")]
        public JsonResult GetSubCategories(string categoryId)
        {
            int catId;
            List<SubCategory> subs = new List<SubCategory>();
            if (!string.IsNullOrEmpty(categoryId))
            {
                catId = Convert.ToInt32(categoryId);
                subs = _context.SubCategories.Where(s => s.CategoryId.Equals(catId)).ToList();
            }
            return Json(subs);
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
        [Bind("Name,StartingPrice,Description,AuctionStart,AuctionEnd,SubCategoryId,CategoryId,IsNew,IsHighlighted,"+
        "IsAdvertised,HasExtraPictures,"+
        "IsStartTimeAdjusted,IsEndTimeAdjusted")] 
        Product product)
        {//if modelstate isvalid
            try
            {
                product.SubCategory = _context.SubCategories.First(c => c.Id == product.SubCategoryId);
                product.Category = _context.Categories.First(c => c.Id == product.CategoryId); //moraš instancirat ovo dvoje!
                product.OfferCount = 0;
                product.CurrentPrice = product.StartingPrice;
                product.IsSold = false;
                product.TimeCreated = DateTime.Now;
                product.SellerId = 0;
                product.BuyerId = 0; //usermanager.getcurrentuser
                product.ImagesUrl = "";
                product.ViewCount = 0;
                product.FollowerCount = 0;
                product.IsSeeded = false;
                //product.SellerId = User.userid; headimageurl isseeded currentprice
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new{ category = product.Category.Name, subcategory = product.SubCategory.RouteName });
            }
            catch(DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " + 
                "Try again, and if the problem persists, contact your " + 
                "system administrator.");
            } 
            return View(product);
        }

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
