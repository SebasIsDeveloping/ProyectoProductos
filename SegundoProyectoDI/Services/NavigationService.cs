using System.Collections.ObjectModel;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using FluentAvalonia.UI.Controls;
using SegundoProyectoDI.ViewModels;
using SegundoProyectoDI.Views;

namespace SegundoProyectoDI.Services;

public partial class NavigationService: ObservableObject
{
    public const string LOGIN_VIEW = "login";
    public const string HOME_VIEW = "home";
    public const string NEWPRODUCT_VIEW = "newproduct";
    public const string PRODUCTS_VIEW = "products";
    
    [ObservableProperty]
    private ContentControl currentView;
    
    [ObservableProperty]
    private NavigationViewItem selectedMenuItem;
    
    [ObservableProperty]
    private ObservableCollection<NavigationViewItem> menuItems=new();

    private NavigationViewItem loginItem;
    private NavigationViewItem homeItem;
    private NavigationViewItem newProductItem;
    private NavigationViewItem productsItem;

    public NavigationService()
    {
        loginItem = new NavigationViewItem
        {
            Content="Login",
            Tag=LOGIN_VIEW,
            IconSource = new SymbolIconSource{Symbol = Symbol.Home}
        };
        
        homeItem = new NavigationViewItem
        {
            Content="Home",
            Tag=HOME_VIEW,
            IconSource = new SymbolIconSource{Symbol = Symbol.Shop}
        };
        
        newProductItem = new NavigationViewItem
        {
            Content="Nuevo producto",
            Tag=NEWPRODUCT_VIEW,
            IconSource = new SymbolIconSource{Symbol = Symbol.Help}
        };        
        
        productsItem = new NavigationViewItem
        {
            Content="Lista de productos",
            Tag=PRODUCTS_VIEW,
            IconSource = new SymbolIconSource{Symbol = Symbol.Help}
        };
        
        MenuItems.Add(loginItem);
        MenuItems.Add(homeItem);
        MenuItems.Add(newProductItem);
        MenuItems.Add(productsItem);

        NavigateTo(HOME_VIEW);
    }
    
    partial void OnSelectedMenuItemChanged(NavigationViewItem item)
    {
        NavigateTo(item.Tag.ToString()); 
    }
    
    public void NavigateTo(string tag)
    {
        if (tag.Equals(LOGIN_VIEW))
        {
            LoginView loginView = new LoginView();
            loginView.DataContext = new LoginViewModel(this);
            CurrentView = loginView;
            SelectedMenuItem = loginItem;
        } 
        else if (tag.Equals(HOME_VIEW))
        {
            HomeView homeView = new HomeView();
            homeView.DataContext = new HomeViewModel(this);
            CurrentView = homeView;
            SelectedMenuItem = homeItem;
        }
        else if (tag.Equals(NEWPRODUCT_VIEW))
        {
            NewProductView newproductView = new NewProductView();
            newproductView.DataContext = new NewProductViewModel(this);
            CurrentView = newproductView;
            SelectedMenuItem = newProductItem;
        }
        else if (tag.Equals(PRODUCTS_VIEW))
        {
            ProductsView productsView = new ProductsView();
            productsView.DataContext = new ProductsViewModel(this);
            CurrentView = productsView;
            SelectedMenuItem = productsItem;
        }
    }
}