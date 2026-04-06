using System.Configuration;
using System.Data;
using System.Windows;
using weatherApp.Services;

namespace weatherApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        var dbService = new DatabaseService();
        dbService.InitializeDatabase();
    }
}