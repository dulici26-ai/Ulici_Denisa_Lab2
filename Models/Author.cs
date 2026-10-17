using System.ComponentModel.DataAnnotations;

namespace Ulici_Denisa_Lab2.Models
{
    public class Author
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        // Proprietate calculată pentru a afișa ușor numele complet
        [Display(Name = "Author")]
        public string FullName => $"{FirstName} {LastName}";

        // Navigation property către cărți
        public ICollection<Book>? Books { get; set; }
    }
}
