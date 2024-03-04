using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ecom.Models;
using ecom.Data;
using Microsoft.EntityFrameworkCore;

namespace ecom.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
        private readonly ProductContext _context;

    public HomeController(ILogger<HomeController> logger, ProductContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Products.Where(c => c.AuctionStart < DateTime.Now && c.AuctionEnd > DateTime.Now).ToListAsync());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
