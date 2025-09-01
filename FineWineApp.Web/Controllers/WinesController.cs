using FineWineApp.Web.Services;
using Microsoft.AspNetCore.Mvc;
using FineWineApp.Web.Models;

namespace FineWineApp.Web.Controllers;
public class WinesController : Controller
{
    WineService wineService = new WineService();

    [Route("")]
    public IActionResult Index()
    {
        Wine[] wines = wineService.GetAllWines();
        return View(wines);
    }

    [Route("wines/{wineId}")]
    public IActionResult Info(int wineId)
    {
        Wine wine = wineService.GetWineById(wineId);
        return View(wine);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(Wine wine, IFormFile ImageFile)
    {
        if (ImageFile != null && ImageFile.Length > 0)
        {
            var fileName = Path.GetFileName(ImageFile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await ImageFile.CopyToAsync(stream);
            }

            // Spara bara filnamnet i objektet
            wine.ImagePath = fileName;
        }

        // Generera Id (eftersom vi inte har DB som gör det åt oss)
        wineService.AddWine(wine);

        return RedirectToAction("Index");
    }
}
