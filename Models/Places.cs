using System.ComponentModel.DataAnnotations;

namespace MvcFirst.Models;

public class Places
{
    public int Id { get; set; }
    public string? Name { get; set; }
    // [DataType(DataType.Date)]
    // public DateTime ReleaseDate { get; set; }
    public string? Cordinates { get; set; }
    public long Stars { get; set; }
}