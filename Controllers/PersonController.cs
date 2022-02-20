using Ass_9_1.Models;
using Ass_9_1.Services;
using Microsoft.AspNetCore.Mvc;
using Person = Ass_9_1.Models.Person;

namespace Ass_9_1.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{

    private readonly ILogger<PersonController> _logger;
    private readonly IPersonService _personService;

    public PersonController(ILogger<PersonController> logger, IPersonService personService)
    {
        _logger = logger;
        _personService = personService;
    }

    [HttpGet]
    public IEnumerable<Person> GetAll()
    {
        return _personService.GetAll().AsEnumerable();

    }

    [HttpPost]
    public Person Add(Person person)
    {
        var newPerson = new Person
        {
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName,
            DateOfBirth = person.DateOfBirth,
            Gender = person.Gender,
            BirthPlace = person.BirthPlace
        };
        return _personService.Add(newPerson);
    }
    [HttpPut]
    [Route("{id:int}")]
    public IActionResult Edit(int id, PersonUpdateModel model)
    {
        var person = _personService.GetOne(id);
        if (person == null) return NotFound();

        person.FirstName = model.FirstName;
        person.LastName = model.LastName;
        person.DateOfBirth = model.DateOfBirth;
        person.Gender = model.Gender;
        person.BirthPlace = model.BirthPlace;

        var result = _personService.Edit(person);
        return new JsonResult(result);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public IActionResult Delete(int id)
    {
        if (!_personService.Exists(id)) return NotFound();

        _personService.Remove(id);
        return Ok();
    }
    [HttpGet]
    [Route("GetGender")]
    public IEnumerable<Person> GenGender(string gender)
    {

        return _personService.GetGender(gender).AsEnumerable();

    }
    [HttpGet]
    [Route("GetBirthPlace")]
    public IEnumerable<Person> GetBirthPlace(string place)
    {
        return _personService.GetBirthPlace(place).AsEnumerable();
    }
    [HttpGet]
    [Route("GetName")]
    public IEnumerable<Person> GetName(string name)
    {
        return _personService.GetName(name).AsEnumerable();
    }

}
