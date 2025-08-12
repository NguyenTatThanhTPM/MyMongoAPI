using Microsoft.AspNetCore.Mvc;
using MyMongoApi.Models;
using MyMongoApi.Services;

namespace MyMongoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly BookService _bookService;

    public BookController(BookService bookService) =>
        _bookService = bookService;

    [HttpGet]
    public async Task<List<Book>> Get() =>
        await _bookService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Book>> Get(string id)
    {
        var book = await _bookService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        return book;
    }

  [HttpPost]
public async Task<IActionResult> Post(BookDto newBook)
{
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
    }
    var book = new Book
    {
        Title = newBook.Title,
        Author = newBook.Author,
        Detail = newBook.Detail
    
    };

    await _bookService.CreateAsync(book);

    return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
}


[HttpPut("{id:length(24)}")]
public async Task<IActionResult> Update(string id, BookDto updatedDto)
{
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
    }
    var book = await _bookService.GetAsync(id);

    if (book is null)
    {
        return NotFound();
    }

    book.Title = updatedDto.Title;
    book.Author = updatedDto.Author;
        book.Detail = updatedDto.Detail;

    await _bookService.UpdateAsync(id, book);

    return NoContent();
}


    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var book = await _bookService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        await _bookService.RemoveAsync(id);

        return NoContent();
    }
}
