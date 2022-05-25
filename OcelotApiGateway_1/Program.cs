using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// [jcj] setting Ocelot
builder.Configuration.AddJsonFile("ocelot.configuration.json");
builder.Services.AddOcelot();

builder.Services.AddMvc(option => option.EnableEndpointRouting = false).AddNewtonsoftJson();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
} else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseMvc();

app.UseOcelot();

app.UseAuthorization();

app.MapControllers();

app.Run();
