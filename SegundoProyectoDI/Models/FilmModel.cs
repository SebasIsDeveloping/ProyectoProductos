using System;

namespace SegundoProyectoDI.Models;

public class FilmModel
{
    public string Nombre { get; set; } = "";
    public string Descripcion { get; set; } = "";
    public string Categoria { get; set; } = "";
    public DateTime Fecha { get; set; } = DateTime.Now;
    public bool Bluray { get; set; } = false;
    public int Cantidad { get; set; } = 0;
}