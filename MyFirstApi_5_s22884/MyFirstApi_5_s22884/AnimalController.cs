using Microsoft.AspNetCore.Mvc;

namespace MyFirstApi_5_s22884;

[ApiController]
[Route("animals")]
public class AnimalController : ControllerBase
{
    private IAnimalDb _animalDb;

    public AnimalController(IAnimalDb animalDb)
    {
        _animalDb = animalDb;
    }

    [HttpGet]
    public IActionResult GetAllAnimals()
    {
        return Ok(_animalDb.GetAllAnimals());
    }

    [HttpGet("{id}")]
    public IActionResult GetAnimalById(int id)
    {
        var animal = _animalDb.GetAnimalById(id);
        if (animal is null) return NotFound();

        return Ok(animal);
    }

    [HttpPost]
    public IActionResult AddAnimal(Animal animal)
    {
        _animalDb.AddAnimal(animal);
        return Created();

    }

    [HttpPut]
    public IActionResult UpdateAnimal( Animal animal)
    {
        var animalupdate = _animalDb.UpdateAnimal(animal);
        return Ok(animalupdate);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAnimal(int id)
    {
        _animalDb.DeleteAnimal(id);

        return Created();

    }

}