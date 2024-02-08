using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationCarRazorPages.Data
{
    public class Customer
    {
        [Required(ErrorMessage = "Obligatoriskt fält.")]
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Obligatoriskt fält.")]
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }

        [Display(Name = "KundId")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Obligatoriskt fält.")]
        [EmailAddress(ErrorMessage = "Ogiltig e-postadress.")]
        [Display(Name = "E-postadress")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Obligatoriskt fält.")]
        [MinLength(4, ErrorMessage = "Lösenordet måste vara minst 4 tecken långt.")]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }

    }
}
