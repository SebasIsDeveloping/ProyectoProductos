using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using SegundoProyectoDI.ViewModels;

namespace SegundoProyectoDI.Views;

public partial class ProductsView : UserControl
{
    public ProductsView()
    {
        InitializeComponent();
        DataContext = new ProductsViewModel();
    }
}