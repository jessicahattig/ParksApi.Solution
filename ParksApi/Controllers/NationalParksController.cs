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

    // GET api/nationalparks
    [HttpGet]
    public async Task<List<NationalPark>> Get(string name, string location, string description)
    {
      IQueryable<NationalPark> query = _db.NationalParks.AsQueryable();

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

    // GET: api/NationalParks/4
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

    // POST api/nationalparks
    [HttpPost]
    public async Task<ActionResult<NationalPark>> Post(NationalPark nationalpark)
    {
      _db.NationalParks.Add(nationalpark);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetNationalPark), new { id = nationalpark.NationalParkId }, nationalpark);
    }

    // PUT: api/NationalParks/4
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, NationalPark nationalpark)
    {
      if (id != nationalpark.NationalParkId)
      {
        return BadRequest();
      }

      _db.NationalParks.Update(nationalpark);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!NationalParkExists(id))
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

    // DELETE: api/NationalParks/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNationalPark(int id)
    {
      NationalPark nationalpark = await _db.NationalParks.FindAsync(id);
      if (nationalpark == null)
      {
        return NotFound();
      }

      _db.NationalParks.Remove(nationalpark);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool NationalParkExists(int id)
    {
      return _db.NationalParks.Any(e => e.NationalParkId == id);
    }
  }
}