using SegundoProyectoDI.Services;

namespace SegundoProyectoDI.ViewModels;

public class LoginViewModel : ViewModelBase
{
    private NavigationService navigationService;
    public LoginViewModel (NavigationService navigationService) { this.navigationService = navigationService; }
    public LoginViewModel () { }
    
    
    
}