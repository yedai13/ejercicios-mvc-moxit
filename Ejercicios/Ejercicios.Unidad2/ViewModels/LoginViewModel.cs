using System.ComponentModel.DataAnnotations;

namespace Ejercicios.Unidad2.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }
    }
}