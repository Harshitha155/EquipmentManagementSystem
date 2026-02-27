namespace EquipmentManagementSystem.Models;

public class Equipment
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string SerialNumber { get; set; } = string.Empty;

    public bool IsAvailable { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}