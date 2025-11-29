namespace AspRazorPagesP33.Models;

public interface IPersonDataProvider
{
    public List<Person> GetAll();

    public Person GetById(int id);
}
