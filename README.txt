https://localhost:7149/swagger/index.html adresinden execute etti�imizde (localhost de�eri de�i�kendir)
https://localhost:7149/watchdog adresinde login i�lemini yapmadan g�r�nt�leme sa�layam�yoruz

WatchDog.NET paketini NuGet �zerinden projemize kuruyoruz

A�a��daki s�ralama sadece Program.cs �zerinde daha �nce yap�lan k�s�m, katmanlara ayr��t�r�ld� proje!
/*
Program.cs dosyam�za:
//Service k�sm� i�in a�a��daki kodlar� yaz�yoruz; otomatik temizleme ve Veritaban� ba�lant�s� i�in yaz�yoruz
builder.Services.AddWatchDogServices(opt =>
{    
    opt.IsAutoClear = false; 
    opt.SetExternalDbConnString = builder.Configuration.GetConnectionString(name: "SampleDbConnection");
    opt.SqlDriverOption = WatchDogSqlDriverEnum.MSSQL;
});

//Inject into the middleware b�l�m�
app.UseWatchDogExceptionLogger();

//Login bilgileri
app.UseWatchDog(opt =>
{
    opt.WatchPageUsername = "admin";
    opt.WatchPagePassword = "12345678";
});
*/

/*
//appsettings.json dosyam�zda veritaban� ba�lant�s� i�in ConnectionStrings ekliyoruz, ismini ve yerel SQL bilgilerimizi giriyoruz(ya da kullanmak istedi�imiz veritaban� bilgileri)
"ConnectionStrings": {
    "SampleDbConnection":"Server=DESKTOP-0VT0IBJ\\MSSQLSERVER1; Database=SampleLogDbApp; Trusted_Connection= True;"
*/

/*
//Get metodumuzun i�erisinde hata mesaj� kontrol� i�in (istersek post,put metotlar�nda da kullanabiliriz) return i�leminden �nce a�a��daki kod blo�unu yazabiliriz(_logger.LogInformation yerine WatchLogger.Log kullanmal�y�z):
    //_logger.LogInformation(message:"Bu sadece bir g�nl�k kayd�");
    WatchLogger.Log(message: "Bu sadece bir g�nl�k kayd�");
    //throw new Exception(message:"Her �ey yolunda, WatchDog paketini test ediyorum");
*/