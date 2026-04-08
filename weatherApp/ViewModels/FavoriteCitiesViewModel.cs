using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

        LoadFavoriteCities();
    }

    public void LoadFavoriteCities()
    {
        List<string> cities = _repository.GetFavoriteCities();
        
        FavoriteCities.Clear();
        
        foreach (string city in cities)
        {
            FavoriteCities.Add(city);
        }
    }
    
    [RelayCommand]
    public void RemoveFromFavorites(string city)
    {
        if (string.IsNullOrWhiteSpace(city))
        {
            Console.WriteLine("City is empty");
            return;
        }

        FavoriteCities.Remove(city);
        _repository.RemoveFavoriteCity(city);
        LoadFavoriteCities();
    }
}