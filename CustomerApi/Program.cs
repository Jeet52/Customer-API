using CustomerApi.Models;
using CustomerApi.Data;  // Your EF Core DbContext namespace
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext with SQL Server connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Customer API", Version = "v1" });
});

var app = builder.Build();

// Serve a nice custom HTML page at root "/"
app.MapGet("/", () => Results.Content(@"
<!DOCTYPE html>
<html lang='en'>
<head>
<meta charset='UTF-8' />
<meta name='viewport' content='width=device-width, initial-scale=1' />
<title>Welcome to Customer API</title>
<style>
  body { font-family: Arial, sans-serif; background: #f0f4f8; text-align: center; padding: 50px; }
  h1 { color: #2a9df4; }
  p { font-size: 18px; color: #555; }
  a.button {
    display: inline-block;
    margin-top: 20px;
    padding: 12px 25px;
    font-size: 18px;
    color: white;
    background-color: #2a9df4;
    border-radius: 6px;
    text-decoration: none;
  }
  a.button:hover {
    background-color: #1c7ed6;
  }
</style>
</head>
<body>
  <h1>Welcome to Customer API</h1>
  <p>This API lets you manage customers with ease.</p>
  <a href='/swagger' class='button'>View API Documentation</a>
</body>
</html>", "text/html"));

// Enable Swagger UI at "/swagger"
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer API V1");
    c.RoutePrefix = "swagger";  // Swagger UI is at /swagger now
});

// CRUD endpoints for Customers using EF Core

app.MapGet("/customers", async (AppDbContext db) =>
    await db.Customers.ToListAsync());

app.MapGet("/customers/{id}", async (int id, AppDbContext db) =>
{
    var customer = await db.Customers.FindAsync(id);
    return customer is not null ? Results.Ok(customer) : Results.NotFound();
});

app.MapPost("/customers", async (Customer newCustomer, AppDbContext db) =>
{
    db.Customers.Add(newCustomer);
    await db.SaveChangesAsync();
    return Results.Created($"/customers/{newCustomer.Id}", newCustomer);
});

app.MapPut("/customers/{id}", async (int id, Customer updatedCustomer, AppDbContext db) =>
{
    var existing = await db.Customers.FindAsync(id);
    if (existing is null) return Results.NotFound();

    existing.Name = updatedCustomer.Name;
    existing.Email = updatedCustomer.Email;
    existing.Phone = updatedCustomer.Phone;
    await db.SaveChangesAsync();

    return Results.Ok(existing);
});

app.MapDelete("/customers/{id}", async (int id, AppDbContext db) =>
{
    var customer = await db.Customers.FindAsync(id);
    if (customer is null) return Results.NotFound();

    db.Customers.Remove(customer);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();
