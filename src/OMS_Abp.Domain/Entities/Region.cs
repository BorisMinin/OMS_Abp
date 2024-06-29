﻿#nullable enable
using System.Collections.Generic;

namespace OMS_Abp.Domain.Entities;

public class Region
{
    public int RegionId { get; set; }

    public string RegionDescription { get; set; } = null!;

    public virtual ICollection<Territory> Territories { get; set; } = new List<Territory>();
}