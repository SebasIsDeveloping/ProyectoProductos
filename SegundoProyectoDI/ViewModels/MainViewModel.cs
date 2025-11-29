using CommunityToolkit.Mvvm.ComponentModel;
using SegundoProyectoDI.Services;

namespace SegundoProyectoDI.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private string _greeting = "Welcome to Avalonia!";
    [ObservableProperty]
    private NavigationService navigationService = new();
}