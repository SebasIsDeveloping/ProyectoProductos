using SegundoProyectoDI.Services;

namespace SegundoProyectoDI.ViewModels;

public class NewProductViewModel : ViewModelBase
{
    private NavigationService navigationService;
    public NewProductViewModel (NavigationService navigationService) { this.navigationService = navigationService; }
    public NewProductViewModel () { }

}