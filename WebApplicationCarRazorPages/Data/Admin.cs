using System.ComponentModel.DataAnnotations;

namespace WebApplicationCarRazorPages.Data
{
    public class Admin
    {
        public int AdminId { get; set; }

        [Required(ErrorMessage = "Obligatoriskt fält")]
        [EmailAddress(ErrorMessage = "Ogiltig e-postadress.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obligatoriskt fält")]
        public string Password { get; set; }

    }
}
