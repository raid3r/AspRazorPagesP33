using AspRazorPagesP33.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace AspRazorPagesP33.Pages;

public class InfoModel(PersonDataProvider dataProvider) : PageModel
{
    public Person Person { get; set; }
    public List<Person> Persons { get; set; }

    public void OnGet(int id)
    {
        Persons = dataProvider.GetAll(); 
        Person = dataProvider.GetById(id);
    }
}

