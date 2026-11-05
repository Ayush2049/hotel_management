
using HMT.API.Mapping;
using HMT.Repositories.Common;
using HMT.Repositories.Customer;
using HMT.Services.Customer;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// 1. Register Controllers
builder.Services.AddControllers();

// 2. Register Swagger
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    // Sort API tags: Health Check first, Customer APIs afterwards
    options.TagActionsBy(api =>
    {
        if (api.RelativePath == "api/health/database")
        {
            return new[] { "A - Health Check" };
        }

        return new[]
        {
            api.GroupName ?? api.ActionDescriptor.RouteValues["controller"] ?? "Other"
        };
    });

    // Sort operations inside Swagger
    options.OrderActionsBy(api =>
        api.RelativePath == "api/health/database"
            ? "0"
            : "1" + api.RelativePath
    );
});

// 3. Register AutoMapper
builder.Services.AddAutoMapper(
    cfg => { },
    typeof(CustomerMappingProfile).Assembly
);

// 4. Register Database Connection Factory
builder.Services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

// 5. Register Repository Layer
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

// 6. Register Service Layer
builder.Services.AddScoped<ICustomerService, CustomerService>();

// 7. Build Application
var app = builder.Build();

// 8. Configure Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 9. Configure Middleware
app.UseHttpsRedirection();
app.UseAuthorization();

// 10. Database Connection Health Check API
app.MapGet("/api/health/database", async (
    IDbConnectionFactory connectionFactory) =>
{
    try
    {
        using var connection =
            (SqlConnection)connectionFactory.CreateConnection();

        await connection.OpenAsync();

        return Results.Ok(new
        {
            Status = "Connected",
            Database = connection.Database,
            Server = connection.DataSource
        });
    }
    catch (Exception)
    {
        return Results.Problem(
            title: "Database connection failed",
            detail: "Unable to establish a connection with SQL Server.",
            statusCode: 500
        );
    }
})
.WithName("DatabaseHealthCheck")
.WithTags("A - Health Check");

// 11. Map Controller Routes
app.MapControllers();

// 12. Run Application
app.Run();
