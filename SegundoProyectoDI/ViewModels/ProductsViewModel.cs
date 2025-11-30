using System;
using System.Collections.ObjectModel;
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
    [ObservableProperty] public ObservableCollection<FilmModel> listaLibros = new();
    public ProductsViewModel (NavigationService navigationService) { this.navigationService = navigationService; }

    public ProductsViewModel()
    {
        GetFilms();
    }

    private void GetFilms()
    {
        FilmModel film = new()
        {
            Nombre = "Primera",
            Descripcion = "Cualquier uso inadecuado o abusivo de herramientas de inteligencia artificial (por ejemplo, fragmentos de código de procedencia dudosa o expresiones que no se correspondan con el nivel esperado) podrá derivar en la realización de un cuestionario de verificación sobre el funcionamiento y la autoría del código presentado. ",
            Categoria = "Terror",
            Fecha = DateTime.Today,
            Bluray = false,
            Cantidad = 0,
        };
        ListaLibros.Add(film);
        ListaLibros.Add(film);
        ListaLibros.Add(film);
        ListaLibros.Add(film);
        ListaLibros.Add(film);
        ListaLibros.Add(film);
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
    public void OpenDeleteDialog()
    {
        DialogHost.Show(new DeleteDialog(),"DeleteDialog");
    }   
    [RelayCommand]
     public void DeleteProduct()
     {
         DialogHost.Show(new DeleteDialog(),"DeleteDialog");
     }
    [RelayCommand]
    public void CloseDeleteDialog()
    {
        DialogHost.Close("DeleteDialog");
    }
    
    #endregion

}