using EquipmentManagementSystem.Data;
using EquipmentManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EquipmentManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EquipmentController : ControllerBase
{
    private readonly AppDbContext _context;

    public EquipmentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _context.Equipments.ToListAsync();
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var equipment = await _context.Equipments.FindAsync(id);
        if (equipment == null)
            return NotFound();

        return Ok(equipment);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Equipment equipment)
    {
        _context.Equipments.Add(equipment);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = equipment.Id }, equipment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Equipment updated)
    {
        var equipment = await _context.Equipments.FindAsync(id);
        if (equipment == null)
            return NotFound();

        equipment.Name = updated.Name;
        equipment.SerialNumber = updated.SerialNumber;
        equipment.IsAvailable = updated.IsAvailable;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var equipment = await _context.Equipments.FindAsync(id);
        if (equipment == null)
            return NotFound();

        _context.Equipments.Remove(equipment);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}