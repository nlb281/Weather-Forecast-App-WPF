using System.Windows;
using DotNetEnv;
using weatherApp.Services;
using weatherApp.ViewModels;

namespace weatherApp;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        Env.Load();
        
        var dbService = new DatabaseService();
        dbService.InitializeDatabase();
        
        string connectionString = dbService.GetConnectionString();

        var repository = new WeatherRepository(connectionString);
        
        string geoApiKey = Env.GetString("GEOCODE_API_KEY");
        string weatherApiKey = Env.GetString("WEATHER_API_KEY");

        var geocodingService = new GeocodingService(geoApiKey);
        var weatherService = new WeatherService(weatherApiKey);
        
        var viewModel = new MainWindowViewModel(
            geocodingService,
            weatherService,
            repository
        );
        
        var mainWindow = new MainWindow
        {
            DataContext = viewModel
        };
        
        mainWindow.Show();
    }
}