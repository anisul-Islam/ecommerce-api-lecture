public static class ProductValidation
{
  public static bool isValidName(string name) 
  {
    return !string.IsNullOrEmpty(name); 
  }
  public static bool isValidPrice(decimal price) 
  {
    return price > 0;
  }
}