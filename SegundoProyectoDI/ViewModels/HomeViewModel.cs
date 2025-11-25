using SegundoProyectoDI.Services;

namespace SegundoProyectoDI.ViewModels;

public class HomeViewModel : ViewModelBase
{
    private NavigationService navigationService;
    public HomeViewModel (NavigationService navigationService) { this.navigationService = navigationService; }
    public HomeViewModel () { }

}