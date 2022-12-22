using WatchDog;
using WatchDog.src.Enums;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Service k�sm� i�in a�a��daki kodlar� yaz�yoruz; otomatik temizleme ve Veritaban� ba�lant�s� i�in yaz�yoruz
builder.Services.AddWatchDogServices(opt =>
{
    opt.IsAutoClear = false;
    opt.SetExternalDbConnString = builder.Configuration.GetConnectionString(name: "SampleDbConnection");
    opt.SqlDriverOption = WatchDogSqlDriverEnum.MSSQL;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Inject into the middleware b�l�m�
app.UseWatchDogExceptionLogger();

//Login bilgileri
app.UseWatchDog(opt =>
{
    opt.WatchPageUsername = "admin";
    opt.WatchPagePassword = "12345678";
});

app.Run();
