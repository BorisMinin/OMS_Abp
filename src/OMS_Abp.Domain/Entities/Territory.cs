#nullable enable
using System.Collections.Generic;

namespace OMS_Abp.Domain.Entities;

public class Territory
{
    public string TerritoryId { get; set; } = null!;

    public string TerritoryDescription { get; set; } = null!;

    public int RegionId { get; set; }

    public virtual ICollection<EmployeeTerritory> EmployeeTerritories { get; set; } = new List<EmployeeTerritory>();

    public virtual Region Region { get; set; } = null!;
}