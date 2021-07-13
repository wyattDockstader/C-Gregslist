using System.ComponentModel.DataAnnotations;

namespace C_Gregslist.Models
{
  public class Car
  {
    [Required]
    public string Make { get; set; }
    [Required]
    public string Model { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    public string color { get; set; }
    [Required]
    public int Price { get; set; }

    public int Id { get; set; }
  }
}