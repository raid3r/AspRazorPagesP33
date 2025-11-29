using AspRazorPagesP33.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspRazorPagesP33.Pages;

public class PersonsModel(IPersonDataProvider dataProvider) : PageModel
{
    public List<Person> Persons { get; set; }

    public void OnGet()
    {
        Persons = dataProvider.GetAll();
    }
}
