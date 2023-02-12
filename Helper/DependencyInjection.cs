namespace Helper
{
    public static class DependencyInjection
    {
        public static IServiceCollection WatchDogServices(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.GetConnectionString("SampleDbConnection");
            services.AddWatchDogServices(option =>
            {
                option.IsAutoClear = false;
                //İhtiyaç olursa temizleme işlemini otomatik yapmak için.
                //opt.ClearTimeSchedule = WatchDogAutoClearScheduleEnum.Monthly;
                option.SetExternalDbConnString = settings;
                option.SqlDriverOption = WatchDogSqlDriverEnum.MSSQL;
            });
            return services;
        }
    }
}
