using FineWineApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
namespace FineWineApp.Web.Services;

public class WineService
{
    static List<Wine> wines = new()
    {
        new Wine()
        {
            Id = 1, 
            Name = "Haggan Pet Nat", 
            WineMaker = "Xavier Weisskopf", 
            Price = 235, 
            Type = "Sparkling", 
            Country = "France", 
            Year = 2021, 
            AlcPercentage = 12, 
            Description = "Fruktig, mycket frisk smak med inslag av gula plommon, torkade örter, bivax, röda äpplen och citron.", 
            ImagePath = "HagganPetNat.jpg"
        },
        new Wine()
        {
            Id = 2, 
            Name = "Flora", 
            WineMaker = "Weingut Michel Gindlf", 
            Price = 227,
            Type = "White",
            Country = "Austria",
            Year = 2022,
            AlcPercentage = 11.5f,
            Description = "Nyanserad, något kryddig, druvig, mycket frisk smak med inslag av vinteräpplen, jasminblommor, aprikos, mineral och mandarin.",
            ImagePath = "Flora.jpg"
        },
        new Wine()
        {
            Id = 3, 
            Name = "Cherrydelica", 
            WineMaker = "Fruktstereo", 
            Price = 152,
            Type = "Cider",
            Country = "Sweden",
            Year = 2020,
            AlcPercentage = 6,
            Description = "Fruktig, pärlande, påtagligt frisk smak med tydlig karaktär av körsbär, inslag av röda äpplen, äppelcidervinäger och blodgrapefrukt.",
            ImagePath = "Cherrydelica.jpg"
        },
        new Wine()
        {
            Id = 4, 
            Name = "Arndorfer", 
            WineMaker = "Weingut Arndorfer", 
            Price = 249,
            Type = "Orange",
            Country = "Austria",
            Year = 2020,
            AlcPercentage = 12,
            Description = "Karaktärsfull, nyanserad, mycket frisk smak med inslag av torkade aprikoser, mimosablommor, halm, havtorn och bergamott.",
            ImagePath = "Arndorfer.jpg"
        },

    };

    //Retrieves information about all wines from List<Wine> wines.
    public Wine[] GetAllWines() => wines 
        .OrderBy(w => w.Price)
        .ToArray();

    //Retrieves info about a specific wine by Id.
    public Wine GetWineById(int wineId)
    {
        Wine wine = wines
            .SingleOrDefault(w => w.Id == wineId);
        return wine;
    }

    //Adds a new wine to the existing list of wines.
    public void AddWine(Wine newWine)
    {
        newWine.Id = wines.Count == 0 ? 1 : wines.Max(w => w.Id) + 1;
        wines.Add(newWine);
    }

  
}
