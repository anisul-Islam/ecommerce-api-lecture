// Model
public record Product
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public decimal Price { get; set; }
  public string Description { get; set; }
  public DateTime CreatedAt { get; set; }

}