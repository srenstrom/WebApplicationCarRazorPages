using System.ComponentModel.DataAnnotations;

namespace WebApplicationCarRazorPages.Data
{
    public class Admin
    {
        public int AdminId { get; set; }

        [Required(ErrorMessage = "E-postadressen är obligatorisk.")]
        [EmailAddress(ErrorMessage = "Ogiltig e-postadress.")]
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
