using System.ComponentModel.DataAnnotations;

namespace ParksApi.Models
{
  public class StatePark
  {
    public int StateParkId { get; set; }
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    [Required]
    public string Location { get; set; }
    [Required]
    public string Description { get; set; }
  }
}