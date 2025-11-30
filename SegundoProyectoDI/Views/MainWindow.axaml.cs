using Avalonia.Controls;
using SegundoProyectoDI.ViewModels;

namespace SegundoProyectoDI.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}