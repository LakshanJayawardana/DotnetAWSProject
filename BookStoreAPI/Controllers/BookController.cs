using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreAPI.Models;
using BookStoreAPI.Models.Dto;
using BookStoreAPI.Data;
using AutoMapper;

namespace BookStoreAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly BookStoreDbContext _context;
    private ResponseDto _response;
    private IMapper _mapper;

    public BookController(BookStoreDbContext bookStoreDbContext,IMapper mapper)
    {
        _context = bookStoreDbContext;
        _response = new ResponseDto();
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        try
            {
                var books = await _context.Books.ToListAsync();
                _response.Result = _mapper.Map<List<BooksDto>>(books);
                _response.Message = "Books retrieved successfully";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return Ok(_response);
    }
}