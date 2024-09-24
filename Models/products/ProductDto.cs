using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public record ProductDto
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    // public string Description { get; set; }
}
