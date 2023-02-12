namespace Helper
{
    public static class Configuration
    {
        public static WebApplication WatchDogAppSettings(this WebApplication application, IConfiguration configuration)
        {
            var userName = configuration.GetValue<string>("WatchDog:UserName");
            var password = configuration.GetValue<string>("WatchDog:Password");
            application.UseWatchDog(option =>
            {
                option.WatchPageUsername = userName;
                option.WatchPagePassword = password;
                option.Blacklist = "";
            });
            return application;
        }
    }
}