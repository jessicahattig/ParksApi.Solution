using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksApi.Models;

namespace ParksApisApi.Controllers
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
    public async Task<List<StatePark>> Get(string name, string location, string description)
    {
      IQueryable<StatePark> query = _db.StateParks.AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }

      if (location != null)
      {
        query = query.Where(entry => entry.Location == location);
      }

      if (description != null)
      {
        query = query.Where(entry => entry.Description == description);
      }

      return await query.ToListAsync();
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

    // POST api/stateparks
    [HttpPost]
    public async Task<ActionResult<StatePark>> Post(StatePark statepark)
    {
      _db.StateParks.Add(statepark);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetStatePark), new { id = statepark.StateParkId }, statepark);
    }

    // PUT: api/StateParks/4
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, StatePark statepark)
    {
      if (id != statepark.StateParkId)
      {
        return BadRequest();
      }

      _db.StateParks.Update(statepark);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!StateParkExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // DELETE: api/StateParks/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStatePark(int id)
    {
      StatePark statepark = await _db.StateParks.FindAsync(id);
      if (statepark == null)
      {
        return NotFound();
      }

      _db.StateParks.Remove(statepark);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool StateParkExists(int id)
    {
      return _db.StateParks.Any(e => e.StateParkId == id);
    }
  }
}