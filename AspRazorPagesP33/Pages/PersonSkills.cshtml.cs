using AspRazorPagesP33.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspRazorPagesP33.Pages;

public class PersonSkillsModel(IPersonDataProvider dataProvider) : PageModel
{
    public Person Person { get; set; }
    public List<Skill> Skills { get; set; }

    public void OnGet(int id)
    {
        var person = dataProvider.GetById(id);
        Person = person;
        Skills = person.Skills;
    }
}

/*
 * Додати сторінки для створення та редагування навичок (Skills) для конкретної особи (Person).
 * 
 */ 