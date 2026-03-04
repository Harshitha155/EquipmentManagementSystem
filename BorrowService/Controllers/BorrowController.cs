
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BorrowService.Data;
using BorrowService.Models;
namespace BorrowService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BorrowController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BorrowController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Borrow(Borrow borrow)
        {
            borrow.BorrowDate = DateTime.UtcNow;
            borrow.Status = "BORROWED";

            _context.Borrows.Add(borrow);
            await _context.SaveChangesAsync();

            return Ok(borrow);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Borrows.ToListAsync());
        }

        [HttpPut("return/{id}")]
        public async Task<IActionResult> Return(int id)
        {
            var borrow = await _context.Borrows.FindAsync(id);
            if (borrow == null) return NotFound();

            borrow.Status = "RETURNED";
            await _context.SaveChangesAsync();

            return Ok(borrow);
        }
    }
}

