using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using weatherApp.Services;

namespace weatherApp.ViewModels;

public partial class FavoriteCitiesViewModel : ObservableObject 
{
    private readonly WeatherRepository _repository;
    
    [ObservableProperty]
    private ObservableCollection<string> favoriteCities = new();
    
    public FavoriteCitiesViewModel(WeatherRepository repository)
    {
        _repository = repository;
        
        List<string> cities = _repository.GetFavoriteCities();
        
        foreach (string city in cities)
        {
            FavoriteCities.Add(city);
        }
    }
}