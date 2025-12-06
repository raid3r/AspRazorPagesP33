using AspRazorPagesP33.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace AspRazorPagesP33.Pages;

public class PersonCreateModel(IPersonDataProvider dataProvider, IWebHostEnvironment environment) : PageModel
{
    [BindProperty]
    public Person Person { get; set; } = new Person();

    [BindProperty]
    [Display(Name = "Аватарка")]
    public IFormFile? AvatartImage { get; set; }

    // GET /PersonCreate
    public IActionResult OnGet()
    {
        return Page();
    }

    // POST /PersonCreate
    public IActionResult OnPost()
    {
        // Перевірка валідності моделі
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (AvatartImage != null)
        {
            // Завантаженння картинки (аватарки) якщо вона 

            var uploadDir = Path.Combine(environment.WebRootPath, "uploads", "avatars");
            // Створення директорії якщо її не існує
            if (!Directory.Exists(uploadDir))
            {
                Directory.CreateDirectory(uploadDir);
            }
            // Генерація унікального імені файлу
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(AvatartImage.FileName)}";
            // Повний шлях до файлу
            var filePath = Path.Combine(uploadDir, fileName);

            // Збереження файлу
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                AvatartImage.CopyTo(fileStream);
            }
            // Встановлення шляху до аватарки в модель Person
            Person.AvatarImageSrc = $"/uploads/avatars/{fileName}";
        }
        
        dataProvider.Add(Person);
        dataProvider.SaveChanges();
        return RedirectToPage("Persons");
    }
}
