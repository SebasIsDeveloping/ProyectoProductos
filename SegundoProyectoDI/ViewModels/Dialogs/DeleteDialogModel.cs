using CommunityToolkit.Mvvm.Input;
using DialogHostAvalonia;
using SegundoProyectoDI.Services;

namespace SegundoProyectoDI.ViewModels.Dialogs;

public partial class DeleteDialogModel : ViewModelBase
{

    DeleteDialogModel()
    {
        
    }
    
    [RelayCommand]
    public void CloseDeleteDialog()
    {
        DialogHost.Close("DeleteDialog");
    }
}