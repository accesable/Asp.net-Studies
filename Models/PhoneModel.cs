using System.ComponentModel.DataAnnotations;

namespace MvcApp.Models;

public class PhoneModel{
    [Key]
    public int id {get;set;}

    [StringLength(128)]
    [Required]
    public string ModelName {get;set;}
}