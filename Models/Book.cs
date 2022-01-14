using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deak_Levente_Ferenc_Lab9.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [DisplayName("Book Title")]
        public string Title { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele autorului trebuie sa fie de forma 'Prenume Nume'"), Required, StringLength(50, MinimumLength = 3)]
        public string Author { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        [Range(1, 300)]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }
    }
}
