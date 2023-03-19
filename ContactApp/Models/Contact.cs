using System.ComponentModel.DataAnnotations;

namespace ContactApp.Models;

public class Contact
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "El nombre es requerido")]
    public String Name { get; set; }
    public String? Email { get; set; }
    [Required(ErrorMessage = "El Teléwfono es requerido")]
    public String Phone { get; set; }
    public String?  ResidencialPhone { get; set; }
    public String?  WorkPhone { get; set; }
}