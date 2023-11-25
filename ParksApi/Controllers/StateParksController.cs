using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksApi.Models;

namespace ParksApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StateParksController : ControllerBase
  {
    private readonly ParksApiContext _db;

    public StateParksController(ParksApiContext db)
    {
      _db = db;
    }

    // GET api/state parks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StatePark>>> Get()
    {
      return await _db.StateParks.ToListAsync();
    }

    // GET: api/StateParks/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<StatePark>> GetStatePark(int id)
    {
      StatePark statepark = await _db.StateParks.FindAsync(id);

      if (statepark == null)
      {
        return NotFound();
      }

      return statepark;
    }
  }
}