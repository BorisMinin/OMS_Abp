#nullable enable
namespace OMS_Abp.Domain.Entities;

public class EmployeeTerritory
{
    public int EmployeeId { get; set; }

    public string TerritoryId { get; set; } = null!;

    public Employee Employee { get; set; } = null!;

    public Territory Territory { get; set; } = null!;
}