using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstApi_5_s22884;


[ApiController]
[Route("visits")]
public class VisitController : ControllerBase
{

    private IVisitDb _visitDb;

    public VisitController(IVisitDb visitDb)
    {
        _visitDb = visitDb;
    }
    
    [HttpGet()]
    public IActionResult GetAllVisits()
    {
        return Ok(_visitDb.GetAllVisit());
    }
    
    
    [HttpGet("/visits/vistsbyanimalid")]
    public IEnumerable<Visit> GetVisitsByAnimalId(int animalId)
    {
        return _visitDb.GetVisitsByAnimalId(animalId);
    }

    [HttpPost("/addVisit")]
    public IActionResult AddVisit([FromBody] Visit visit)
    {
        _visitDb.AddVisit(visit);
        return Created($"/animals/visits/{visit.DateVisit}", visit);

    }

}