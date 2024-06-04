using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ecom.Models;
using ecom.Data;
using System;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ecom.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductContext _context;
        private readonly UserManager<Writer> _userManager;
        private readonly SignInManager<Writer> _signInManager;

        public ProductsController(ProductContext context, UserManager<Writer> userManager, SignInManager<Writer> signInManager) 
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
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

        // GET: Products/Details/Guid
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.Include(c => c.Writer).Include(c => c.Category).Include(c => c.SubCategory)
                .FirstOrDefaultAsync(m => m.ProdGuid == id);
            if (product == null)
            {
                return NotFound();
            }

            //product.ViewCount++; //additional logic might be needed
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

        private void PopulateCategories(object? selectedCategory = null)
        {
            var categories = _context.Categories.ToList();
            ViewData["Categories"] = new SelectList(categories, "Id", "DisplayName", selectedCategory);
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

        private void PopulateSubCategories(int? selectedCategory, int? selectedSubCategory) //izbriši
        {
            var subs = _context.SubCategories.Where(c => c.CategoryId.Equals(selectedCategory));
            ViewBag.SubCategories = new SelectList(subs, "Id", "Name");
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
        [Bind("Name,StartingPrice,Description,AuctionStart,AuctionEnd,SubCategoryId,CategoryId,ProdGuid")] 
        Product product, List<IFormFile> files)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var currentUser = await _userManager.GetUserAsync(User);
                    if(currentUser == null) // || (!currentUser.isModerator && !currentUser.isAdmin))
                    {
                        return Forbid();
                    }
                    
                    string webp = "";
                    if(files.Count > 6)
                    {
                        return Forbid(); // promijeni
                    }

                    Account account = new Account("dsjavparg", "351856923196787", "rANgXE5HEDwuyV3QThqfJiRs8Zg");
                    Cloudinary cloudinary = new Cloudinary(account);
                    int i = 0;
                    foreach(var file in files)
                    {
                        string ext = file.FileName;
                        string pth = Path.GetTempFileName(); i++;
                        string guid = product.ProdGuid.ToString(); 
                        if(files.Count > 1) webp = webp + guid + i.ToString() + ".webp,"; //pazi ako probaju druge fileove uploadat
                        else webp += guid + i.ToString() + ".webp";

                        using(var stream = System.IO.File.Create(pth))
                        {
                            await file.CopyToAsync(stream);
                        }

                        ImageUploadParams uploadParams = new ImageUploadParams()
                        {
                            File = new FileDescription(pth), 
                            PublicId = guid + i.ToString(),
                            Format = "webp"
                        };

                        ImageUploadResult uploadResult = cloudinary.Upload(uploadParams);
                    }
                    string wbp = webp;
                    if(files.Count > 1) { wbp = webp.Remove(webp.Length - 1); }
                    product.ImagesUrl = wbp;

                    product.Writer = currentUser;
                    product.SubCategory = _context.SubCategories.First(c => c.Id == product.SubCategoryId);
                    product.Category = _context.Categories.First(c => c.Id == product.CategoryId); //moraš instancirat ovo troje!
                    product.OfferCount = 0;
                    product.CurrentPrice = product.StartingPrice;
                    product.IsSold = false;
                    product.TimeCreated = DateTime.Now;
                    product.BuyerId = 0; //usermanager.getcurrentuser
                    product.ViewCount = 0;
                    product.FollowerCount = 0;
                    product.IsSeeded = false;
                    if(_context.Products.Where(c => c.ProdGuid == product.ProdGuid).Count() == 0)
                    {await _context.AddAsync(product);
                    await _context.SaveChangesAsync();}
                    return RedirectToAction(nameof(Index), new{ category = product.Category.Name, subcategory = product.SubCategory.RouteName });
                }
                catch(DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " + 
                    "Try again, and if the problem persists, contact your " + 
                    "system administrator.");
                } 
            }
            else{ ModelState.AddModelError("Unable to save changes", "");}
            return View();
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
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
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Price")] Product product)
        {
            if (id != product.ProdGuid)
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
                    if (!ProductExists(product.ProdGuid))
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
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProdGuid == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(Guid id)
        {
            return _context.Products.Any(e => e.ProdGuid == id);
        }
    }
}
