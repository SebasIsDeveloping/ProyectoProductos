using CommunityToolkit.Mvvm.ComponentModel;
using examen2025.Services;

namespace examen2025.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    
    [ObservableProperty]
    private NavigationService navigationService = new();
}