using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Avalonia.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SegundoProyectoDI.Models;
using DialogHostAvalonia;
using SegundoProyectoDI.Services;
using SegundoProyectoDI.Views.Dialogs;

namespace SegundoProyectoDI.ViewModels;

public partial class ProductsViewModel : ViewModelBase
{
    private NavigationService navigationService;    
    private APIService apiService { get; set; } = new();
    [ObservableProperty] public ObservableCollection<FilmModel> listaLibros = new();
    [ObservableProperty] public FilmModel film = new ();
    [ObservableProperty] public FilmModel selectedFilm = new ();


    public ProductsViewModel(NavigationService navigationService)
    {
        this.navigationService = navigationService;
        
        _ = InitializeAsync(); 
    }
    public ProductsViewModel() { }

    
    private async Task InitializeAsync()
    {
        await GetFilmsAsync(); 
    }

    public async Task GetFilmsAsync()
    {
        ListaLibros =  await apiService.ObtenerProductos();
    }

    [RelayCommand]
    public void SetSelectedFilm(FilmModel film)
    {
        SelectedFilm = film;
    }
    
        
    [RelayCommand]
    public void GoBack(string tagView)
    {
        navigationService.NavigateTo(tagView);
    }
        
    #region //DIALOGHOST
        // EDIT
    [RelayCommand]
    public void OpenEditDialog()
    {
        DialogHost.Show(new EditDialog(),"EditDialog");
    }
    [RelayCommand]
    public void CloseEditDialog()
    {
        DialogHost.Close("EditDialog");
    }
    
        // DELETE
    [RelayCommand]
    public void OpenDeleteDialog(FilmModel film)
    {
        SelectedFilm = film;
        DialogHost.Show(new DeleteDialog(),"DeleteDialog");
    }   
    
    [RelayCommand]
    public async Task DeleteProduct()
    {  
        bool success = await apiService.EliminarProducto(SelectedFilm);
        if (success) GetFilmsAsync();
        CloseDeleteDialog();
    }
    [RelayCommand]
    public void CloseDeleteDialog() 
    {
        DialogHost.Close("DeleteDialog");
    }
    
    #endregion

}