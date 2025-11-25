using SegundoProyectoDI.Services;

namespace SegundoProyectoDI.ViewModels;

public class ProductsViewModel : ViewModelBase
{
    private NavigationService navigationService;
    public ProductsViewModel (NavigationService navigationService) { this.navigationService = navigationService; }
    public ProductsViewModel () { }

}