using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksApi.Models;

namespace ParksApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class NationalParksController : ControllerBase
  {
    private readonly ParksApiContext _db;

    public NationalParksController(ParksApiContext db)
    {
      _db = db;
    }

    // GET api/national parks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<NationalPark>>> Get()
    {
      return await _db.NationalParks.ToListAsync();
    }

    // GET: api/NationalParks/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<NationalPark>> GetNationalPark(int id)
    {
      NationalPark nationalpark = await _db.NationalParks.FindAsync(id);

      if (nationalpark == null)
      {
        return NotFound();
      }

      return nationalpark;
    }
  }
}