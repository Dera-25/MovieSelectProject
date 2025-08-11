using Microsoft.AspNetCore.Mvc;
using MovieSelect.API.Models;

namespace MovieApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenresController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Genre>> GetAll() => Ok(InMemoryDatabase.Genres);

    [HttpGet("{id}")]
    public ActionResult<Genre> Get(int id)
    {
        var genre = InMemoryDatabase.Genres.FirstOrDefault(g => g.Id == id);
        if (genre == null) return NotFound();
        return Ok(genre);
    }

    [HttpPost]
    public ActionResult<Genre> Create(Genre genre)
    {
        genre.Id = InMemoryDatabase.Genres.Count > 0
            ? InMemoryDatabase.Genres.Max(g => g.Id) + 1
            : 1;
        InMemoryDatabase.Genres.Add(genre);
        return CreatedAtAction(nameof(Get), new { id = genre.Id }, genre);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Genre updatedGenre)
    {
        var genre = InMemoryDatabase.Genres.FirstOrDefault(g => g.Id == id);
        if (genre == null) return NotFound();

        genre.Name = updatedGenre.Name;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var genre = InMemoryDatabase.Genres.FirstOrDefault(g => g.Id == id);
        if (genre == null) return NotFound();

        InMemoryDatabase.Genres.Remove(genre);
        return NoContent();
    }
}
