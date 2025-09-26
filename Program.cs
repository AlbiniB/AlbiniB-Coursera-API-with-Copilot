var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var users = new List<User>();
var nextId = 1;

// GET all users
app.MapGet("/users", () => Results.Ok(users));

// GET user by ID
app.MapGet("/users/{id:int}", (int id) =>
{
    var user = users.FirstOrDefault(u => u.Id == id);
    return user is null ? Results.NotFound() : Results.Ok(user);
});

// POST create user
app.MapPost("/users", (User user) =>
{
    user.Id = nextId++;
    users.Add(user);
    return Results.Created($"/users/{user.Id}", user);
});

// PUT update user
app.MapPut("/users/{id:int}", (int id, User updatedUser) =>
{
    var user = users.FirstOrDefault(u => u.Id == id);
    if (user is null) return Results.NotFound();

    user.Username = updatedUser.Username;
    user.Email = updatedUser.Email;
    return Results.Ok(user);
});

// DELETE user
app.MapDelete("/users/{id:int}", (int id) =>
{
    var user = users.FirstOrDefault(u => u.Id == id);
    if (user is null) return Results.NotFound();

    users.Remove(user);
    return Results.NoContent();
});

app.Run();