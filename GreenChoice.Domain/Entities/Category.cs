﻿using GreenChoice.Domain.Core;

namespace GreenChoice.Domain.Entities;

public class Category : EntityBase
{
    public string Name { get; set; }
    public string Description { get; set; }
}
