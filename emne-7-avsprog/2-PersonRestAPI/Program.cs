using PersonRestAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Lager vårt første endepunkt! Metode: GET, https://localhost:7215/persons/

app.MapGet("/persons", () =>
{ 
    var person = new Person { Age = 20, id = 1, FirstName = "Ola", LastName = "Normann" };
    return Results.Ok(person);
}).WithName("Persons")
    .WithOpenApi();

app.MapPost("/persons", (Person person) =>
    {
        return Results.Ok(new Person()
        {
            Age = person.Age + 1,
            FirstName = person.FirstName,
            Lastname = person.LastName,
            id = person.id
        });
    }).WithName("AddPersons")
    .WithOpenApi();

app.Run();

