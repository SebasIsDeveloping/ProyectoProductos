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
    [ObservableProperty] public ObservableCollection<string> listaCategorias;
    [ObservableProperty] public FilmModel film = new ();
    [ObservableProperty] public FilmModel selectedFilm = new ();
    [ObservableProperty] public string mensaje = string.Empty;


    public ProductsViewModel(NavigationService navigationService)
    {
        this.navigationService = navigationService;
        CargarCategorias();
        _ = InitializeAsync(); 
    }
    public ProductsViewModel() {  
        CargarCategorias();
        _ = InitializeAsync(); 
    }

    private void CargarCategorias()
    {
        ListaCategorias = new ObservableCollection<string>()
        {
            "Terror"
            ,"Acción"
            ,"Comedia"
            ,"Drama"
            ,"Ciencia Ficción"
            ,"Fantasía"
            ,"Romance"
            ,"Animación"
            ,"Misterio"
            ,"Aventura"
            ,"Thriller"
        };
    }
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
    
        #region       // EDIT
            [RelayCommand]
            public void OpenEditDialog(FilmModel film)
            {
                SelectedFilm = film;
                DialogHost.Show(new EditDialog(),"EditDialog");
            }
            
            [RelayCommand]
            public async Task EditProduct()
            {  
                //validaciones
                if (string.IsNullOrWhiteSpace(SelectedFilm.CodBarras)) { Mensaje = "Debes indicar un codigo de barras"; return; }
                if (string.IsNullOrWhiteSpace(SelectedFilm.Nombre)) { Mensaje = "Debes indicar un nombre de pelicula"; return; }
                if (string.IsNullOrWhiteSpace(SelectedFilm.Categoria)) { Mensaje = "Debes indicar una categoria"; return; }
                if (string.IsNullOrWhiteSpace(SelectedFilm.Descripcion)) { Mensaje = "Debes indicar una descripcion"; return; }
                if (!FechasCorrectas()) return;
                Mensaje = String.Empty;
                
                bool success = await apiService.ModificarProducto(SelectedFilm);
                if (success) GetFilmsAsync();
                
                CloseEditDialog();
            }
            public bool FechasCorrectas()
            {
                if (SelectedFilm.Fecha > DateTime.Now)
                {
                    Mensaje = "La fecha de publicación no puede ser superior a la fecha de hoy";
                    return false;
                }
                else
                {
                    return true;
                }
            }

            [RelayCommand]
            public void CloseEditDialog()
            {
                DialogHost.Close("EditDialog");
            }
        #endregion
        
        #region     // DELETE
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
        
    #endregion

}