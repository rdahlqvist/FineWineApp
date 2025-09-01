using Microsoft.AspNetCore.Mvc.Formatters;
using System.ComponentModel.DataAnnotations;

namespace FineWineApp.Web.Models;

public class Wine
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string WineMaker { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public int Year { get; set; }

    [Required]
    public string Country { get; set; }

    [Required]
    public float AlcPercentage { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public string Type { get; set; }

    public string ImagePath { get; set; }

    public IFormFile ImageFile { get; set; }

}
