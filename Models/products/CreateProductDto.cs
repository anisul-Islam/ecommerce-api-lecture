// Dto
public record CreateProductDto
{
  public string Name { get; set; }
  public decimal Price { get; set; }
  public string Description { get; set; }
}