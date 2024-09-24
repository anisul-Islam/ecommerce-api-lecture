

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IProductService, ProductService>();

var app = builder.Build();

app.MapGet("/", () => "Api running well");


app.UseHttpsRedirection();
app.MapControllers();
app.Run();






// MVC => Models, Views, Controllers

// Products API 
// step 1: Entity => Product
// Product Model => id, name, description, price, createdAt
// Product Dtos => CreateProductDto 

// GET => /api/products => Get all the products
// GET => /api/products/{id} => Get a single product by id
