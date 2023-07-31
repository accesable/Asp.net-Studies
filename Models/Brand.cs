using System.ComponentModel.DataAnnotations;

namespace MvcApp.Models;
public class Brand{
    [Key]
    public int id {get;set;}
    [StringLength(50)]
    [Required]
    public string ? BrandName {get;set;}
}