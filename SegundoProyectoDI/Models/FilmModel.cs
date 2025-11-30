using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SegundoProyectoDI.Models;

public class FilmModel
{
    [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [JsonProperty("nombre")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "La descripción es obligatoria.")]
    [JsonProperty("descripcion")]
    public string Descripcion { get; set; } = string.Empty;

    [Required(ErrorMessage = "La categoría es obligatoria.")]
    [JsonProperty("categoria")]
    public string Categoria { get; set; } = string.Empty;

    [Required(ErrorMessage = "La fecha es obligatoria.")]
    [JsonProperty("fecha")]
    public DateTime Fecha { get; set; }

    [JsonProperty("bluray")]
    public bool Bluray { get; set; }

    [JsonProperty("cantidad")]
    public int Cantidad { get; set; }    
    
    [Required(ErrorMessage = "La categoría es obligatoria.")]
    [JsonProperty("codBarras")]
    public string CodBarras { get; set; }
}
