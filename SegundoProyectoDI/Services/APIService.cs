using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Collections;
using Newtonsoft.Json;
using SegundoProyectoDI.Models;

namespace SegundoProyectoDI.Services;

public class APIService
{
    private HttpClient client;

    public APIService()
    {
        client = new HttpClient();
        client.BaseAddress = new Uri("http://192.160.50.31:7000/");
        client.DefaultRequestHeaders.Add("apikey",
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyAgCiAgICAicm9sZSI6ICJhbm9uIiwKICAgICJpc3MiOiAic3VwYWJhc2UtZGVtbyIsCiAgICAiaWF0IjogMTY0MTc2OTIwMCwKICAgICJleHAiOiAxNzk5NTM1NjAwCn0.dc_X5iR_VP_qT0zsiyj_I_OZ2T9FtRU2BBNWN8Bu4GE");
    }

    public async Task<ObservableCollection<FilmModel>> ObtenerProductos()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "rest/v1/filmsDB");
        var response = await client.SendAsync(request);
        var listaString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<ObservableCollection<FilmModel>>(listaString);
    }
    
    public async Task CrearProducto(FilmModel film)
    {
        var jsonProduct = JsonConvert.SerializeObject(film);
        var request = new HttpRequestMessage(HttpMethod.Post, "rest/v1/filmsDB")
        {
            Content = new StringContent(jsonProduct, Encoding.UTF8, "application/json")
        };
        var response = await client.SendAsync(request);
    }
    
    public async Task<bool> ModificarProducto (FilmModel film )
    {
        var jsonProduct = JsonConvert.SerializeObject(film);    
        var request = new HttpRequestMessage(HttpMethod.Patch, "rest/v1/filmsDB?id=eq." + film.Id)
        {
            Content = new StringContent(jsonProduct, Encoding.UTF8, "application/json")
        };
        
        request.Headers.Add("Prefer", "return=representation");
        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("error al actualizar" + response.StatusCode.ToString());
        }
        
        var body = await response.Content.ReadAsStringAsync();

        if (String.IsNullOrWhiteSpace(body))
        {
            throw new Exception("error al actualizar" + response.StatusCode.ToString());
        }

        return true;
    }
    
    public async Task<bool> EliminarProducto (FilmModel film)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, "rest/v1/filmsDB?id=eq." + film.Id);
        
        request.Headers.Add("Prefer", "return=representation");
        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("error al eliminar" + response.StatusCode.ToString());
        }
        
        var body = await response.Content.ReadAsStringAsync();

        if (String.IsNullOrWhiteSpace(body))
        {
            throw new Exception("error al eliminar" + response.StatusCode.ToString());
        }

        return true;
    }
    
    
    
    
    
    
    
}