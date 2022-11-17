using NoMoreAlone.Infra;
using NoMoreAlone.Infra.Contracts;
using NoMoreAlone.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//Add dependency injection
builder.Services.AddScoped<IConnection, ConnectionSQLite>();
builder.Services.AddScoped<ICaronaRepository, CaronaRepository>();
builder.Services.AddScoped<IAgglomerationRepository, AgglomerationRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();



builder.Services.AddControllers();
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

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
