using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RazorPagesAnime.Models;

public class Anime
{
    public int Id { get; set; }
    public string? Title { get; set; }

    [Display(Name = "Release Date")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
   

    public string? Genre { get; set; }
    [Display(Name = "Sub-Genre")]
    public string? SubGenre { get; set;}
    public decimal Rating { get; set; }
}