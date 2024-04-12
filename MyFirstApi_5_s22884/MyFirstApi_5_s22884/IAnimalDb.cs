namespace MyFirstApi_5_s22884;

public interface IAnimalDb
{
    public ICollection<Animal> GetAllAnimals();

    public Animal? GetAnimalById(int id);

    public void AddAnimal(Animal animal);

    public Animal? UpdateAnimal(Animal animal);
    public void DeleteAnimal(int id);
}

public class AnimalDb : IAnimalDb
{
    private ICollection<Animal> _animals;

    public AnimalDb()
    {
        _animals = new List<Animal>
        {
            new Animal { Id = 1, Name = "Bob", Category = "Dog", Mass = 30, ColorPelage = "White" },
            new Animal { Id = 2, Name = "Lari", Category = "Cat", Mass = 15, ColorPelage = "Silver" },
            new Animal { Id = 3, Name = "Sirko", Category = "Chicken", Mass = 3, ColorPelage = "Black" }
        };
    }


    public ICollection<Animal> GetAllAnimals()
    {
        return _animals;
    }

    public Animal? GetAnimalById(int id)
    {
        return _animals.FirstOrDefault(animal => animal.Id == id);
    }

    public void AddAnimal(Animal animal)
    {
        _animals.Add(animal);
    }

    public Animal? UpdateAnimal(Animal updateAnimal)
    {
        var animaltoUpdate = _animals.FirstOrDefault(a => a.Id == updateAnimal.Id);
        if (animaltoUpdate != null)
        {
            animaltoUpdate.Id = updateAnimal.Id;
            animaltoUpdate.Name = updateAnimal.Name;
            animaltoUpdate.Category = updateAnimal.Category;
            animaltoUpdate.Mass = updateAnimal.Mass;
            animaltoUpdate.ColorPelage = updateAnimal.ColorPelage;
        }
        else
        {
            new Exception("Not Found 404");
        }

        return animaltoUpdate;

    }

    public void DeleteAnimal(int id)
    {
        var animaltoDelete = _animals.FirstOrDefault(a => a.Id == id);

        _animals.Remove(animaltoDelete);
    }
}