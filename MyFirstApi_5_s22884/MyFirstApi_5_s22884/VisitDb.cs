namespace MyFirstApi_5_s22884;

public interface IVisitDb
{
    public IEnumerable<Visit> GetVisitsByAnimalId(int animalId);

    public void AddVisit(Visit visit);
    
    public ICollection<Visit> GetAllVisit();
}



public class VisitDb:IVisitDb

{
    public ICollection<Visit> _visits;

    public ICollection<Animal> _animals;

    public VisitDb()
    {
        _visits = new List<Visit>()
        {
            new Visit(){DateVisit = new DateTime(2023,10,15),animalId = 1,
                Description = "this is Description for visit with 1 animal",Price = 3000},
            new Visit(){DateVisit = new DateTime(2024,03,10),animalId = 2,
            Description = "this is Description for visit with 2 animal",Price = 3000},
            new Visit(){DateVisit = new DateTime(2020,03,10),animalId = 2,
                Description = "this is Description for visit with 2 animal",Price = 3500},
            new Visit(){DateVisit = new DateTime(2023,10,15),animalId = 3,
                Description = "this is Description for visit with 3 animal",Price = 4000}
        };
    }

    // public ICollection<Visit> GetAllVisitByAnimalId(int id)
    // {
    //     var visits = _visits.Where(a => a.Animal.Id == id).ToList();
    //     return visits;
    // }
    
    public IEnumerable<Visit> GetVisitsByAnimalId(int animalId)
    {
        return _visits.Where(v => v.animalId == animalId);
    }

    public void AddVisit(Visit visit)
    {
        _visits.Add(visit);
    }

    public ICollection<Visit> GetAllVisit()
    {
        return _visits;
    }
}