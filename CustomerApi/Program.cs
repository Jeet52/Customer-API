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

// Enable Swagger UI at root URL
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer API V1");
    c.RoutePrefix = string.Empty;
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
