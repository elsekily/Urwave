﻿namespace Urwave.Core.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public DateTime CreatedOn { get; set; }
}
