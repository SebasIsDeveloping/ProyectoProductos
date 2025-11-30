using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SegundoProyectoDI.Models;
using SegundoProyectoDI.Services;

namespace SegundoProyectoDI.ViewModels;

public partial class NewProductViewModel : ViewModelBase
{
    private APIService apiService { get; set; } = new();
    [ObservableProperty] public FilmModel film = new ();
    private NavigationService navigationService;
    public NewProductViewModel (NavigationService navigationService) { this.navigationService = navigationService; }
    public NewProductViewModel () { }
    
    [RelayCommand]
    public async Task SaveProduct()
    {   
        if (!CheckDate()) return; 
        
        if (Film.Validar())
        {
             await apiService.CrearProducto(Film);
            Film = new FilmModel();
        }
    }
    public bool CheckDate()
    {
        if (Film.Fecha > DateTime.Today) return false; 
        else return true;
    }
    
    [RelayCommand]
    public void GoBack(string tagView)
    {
        navigationService.NavigateTo(tagView);
    }
}