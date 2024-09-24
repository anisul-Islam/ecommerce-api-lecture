public class PaginatedResult<T>
{
  public int PageSize { get; set; } = 3;
  public int pageNumber { get; set; } = 1;
  public int TotalItems { get; set; }
  public string? SearchBy { get; set; } = null;
  public List<T> Items { get; set; }

}