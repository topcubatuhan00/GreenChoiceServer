﻿using GreenChoice.Domain.Core;

namespace GreenChoice.Domain.Entities;

public class Product : EntityBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public string BrandName { get; set; }
    public string Barcode { get; set; }
    public string PackageInformation { get; set; }
    public string ProductionProcessInformation { get; set; }
    public float SustainabilityScore { get; set; }
    public float AverageScore { get; set; }
}
