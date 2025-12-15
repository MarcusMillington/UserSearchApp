using API.DataAccess;
using API.Handlers.CreateUser;
using API.Handlers.UserDetail;
using API.Handlers.UserSearch;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:56277")
                            .AllowAnyMethod()
                            .SetIsOriginAllowed(pol => true)
                            .AllowAnyHeader()
                            .AllowCredentials();
                      });
});

// Map interfaces to their implementations.
builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
builder.Services.AddScoped(typeof(IUserSearchHandler), typeof(UserSearchHandler));
builder.Services.AddScoped(typeof(ICreateUserHandler), typeof(CreateUserHandler));
builder.Services.AddScoped(typeof(IUserDetailHandler), typeof(UserDetailHandler));

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Set the db connection string for the API.
builder.Services.AddDbContext<UserSearchDbContext>
(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
