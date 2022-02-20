using Person = Ass_9_1.Models.Person;
namespace Ass_9_1.Services;

public class PersonService : IPersonService
{
    private static List<Person> _people = new List<Person>
        {
            new Person
            {
                Id = 1,
                FirstName = "Phuong",
                LastName = "Nguyen Nam",
                Gender = "Male",
                DateOfBirth = new DateTime(2001, 1, 22),
                BirthPlace = "Phu Tho"
            },
            new Person
            {
                Id = 2,
                FirstName = "Nam",
                LastName = "Nguyen Thanh",
                Gender = "Male",
                DateOfBirth = new DateTime(2001, 1, 20),
                BirthPlace = "Ha Noi"
            },
            new Person
            {
                Id = 3,
                FirstName = "Son",
                LastName = "Do Hong",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 11, 6),
                BirthPlace = "Ha Noi"
            },
            new Person
            {
                Id = 4,
                FirstName = "Huy",
                LastName = "Nguyen Duc",
                Gender = "Male",
                DateOfBirth = new DateTime(1996, 1, 26),
                BirthPlace = "Ha Noi"
            },
            new Person
            {
                Id = 5,
                FirstName = "Hoang",
                LastName = "Phuong Viet",
                Gender = "Male",
                DateOfBirth = new DateTime(1999, 2, 5),
                BirthPlace = "Ha Noi"
            },
            new Person
            {
                Id = 6,
                FirstName = "Long",
                LastName = "Lai Quoc",
                Gender = "Male",
                DateOfBirth = new DateTime(1997, 5, 30),
                BirthPlace = "Bac Giang"
            },
            new Person
            {
                Id = 7,
                FirstName = "Thanh",
                LastName = "Tran Chi",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 9, 18),
                BirthPlace = "Ha Noi"
            },
            new Person
            {
                Id = 8,
                FirstName = "Manh",
                LastName = "Le Duc",
                Gender = "Male",
                DateOfBirth = new DateTime(2001,4, 22),
                BirthPlace = "Ha Noi"
            },
            new Person
            {
                Id = 9,
                FirstName = "Dung",
                LastName = "Dao Tan",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 12, 7),
                BirthPlace = "Hung Yen"
            }
        };
    public List<Person> GetAll()
    {
        return _people;
    }

    public Person? GetOne(int id)
    {
        return _people.FirstOrDefault(x => x.Id == id);
    }
    public Person Add(Person person)
    {
        _people.Add(person);
        return person;
    }


    public Person? Edit(Person person)
    {
        var current = _people.FirstOrDefault(x => x.Id == person.Id);
        if (current == null) return null;

        current.Id = person.Id;
        current.FirstName = person.FirstName;
        current.LastName = person.LastName;
        current.DateOfBirth = person.DateOfBirth;
        current.Gender = person.Gender;
        current.BirthPlace = person.BirthPlace;

        return current;
    }
    public void Remove(int id)
    {
        var current = _people.FirstOrDefault(x => x.Id == id);
        if (current != null)
        {
            _people.Remove(current);
        }
    }


    public bool Exists(int id)
    {
        return _people.Any(o => o.Id == id);
    }
    public List<Person>? GetName(string name)
    {
        var current = (from people in _people
                       where people.FullName.Contains(name)
                       select people).ToList();
        return current;
    }

    public List<Person>? GetGender(string gender)
    {
        var current = _people.Where(x => x.Gender.Equals(gender, StringComparison.CurrentCultureIgnoreCase)).ToList();
        return current;
    }

    public List<Person>? GetBirthPlace(string place)
    {
        var current = _people.Where(x => x.BirthPlace.Equals(place, StringComparison.CurrentCultureIgnoreCase)).ToList();
        return current;
    }


}