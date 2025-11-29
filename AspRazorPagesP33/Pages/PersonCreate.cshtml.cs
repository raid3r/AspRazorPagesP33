using AspRazorPagesP33.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspRazorPagesP33.Pages;

public class PersonCreateModel(IPersonDataProvider dataProvider) : PageModel
{
    [BindProperty]
    public Person Person { get; set; } = new Person();

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

        dataProvider.Add(Person);
        dataProvider.SaveChanges();
        return RedirectToPage("Persons");
    }
}
