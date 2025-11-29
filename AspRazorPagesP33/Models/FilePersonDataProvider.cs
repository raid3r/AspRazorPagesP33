namespace AspRazorPagesP33.Models;

public class FilePersonDataProvider: IPersonDataProvider
{
    public FilePersonDataProvider()
    {
        LoadFromFile();
    }

    private readonly string filename = "persons.json";

    private List<Person> persons = [];

    private void LoadFromFile()
    {
        if (File.Exists(filename))
        {
            var json = File.ReadAllText(filename);
            persons = System.Text.Json.JsonSerializer.Deserialize<List<Person>>(json) ?? [];
        }
    }

    private void SaveToFile()
    {
        var json = System.Text.Json.JsonSerializer.Serialize(persons);
        File.WriteAllText(filename, json);
    }


    public List<Person> GetAll()
    {
        return persons;
    }
    public Person GetById(int id)
    {
        return persons.First(p => p.Id == id);
    }

    public void Add(Person person)
    {
        // Додати логіку для генерації унікального Id, якщо потрібно
        var maxId = persons.Count > 0 ? persons.Max(p => p.Id) : 0;
        person.Id = maxId + 1;
        persons.Add(person);
    }

    public void SaveChanges()
    {
        SaveToFile();
    }
}
