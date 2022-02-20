using Person = Ass_9_1.Models.Person;

namespace Ass_9_1.Services;

public interface IPersonService
{
    List<Person> GetAll();
    Person? GetOne(int id);
    Person Add(Person person);
    Person? Edit(Person person);
    void Remove(int id);
    bool Exists(int id);
    List<Person>? GetName(string name);
    List<Person>? GetGender(string gender);
    List<Person>? GetBirthPlace(string place);

}