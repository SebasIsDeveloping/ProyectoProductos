using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using SegundoProyectoDI.ViewModels.Dialogs;

namespace SegundoProyectoDI.Views.Dialogs;

public partial class DeleteDialog : UserControl
{
    public DeleteDialog()
    {
        InitializeComponent();
        DataContext = new DeleteDialogModel();
    }
}