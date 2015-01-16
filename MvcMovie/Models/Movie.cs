using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Reflection;
using System.Runtime.Versioning;

namespace MvcMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "TitleRequired")]
        [StringLength(60, MinimumLength = 3, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "TitleLong")]
        public string Title { get; set; }

        [Display(Name = "ReleaseDate", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Genre", ResourceType = typeof(Resources.Resources))]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        [Display(Name = "Price", ResourceType = typeof(Resources.Resources))]
        [Range(1,100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Rating", ResourceType = typeof(Resources.Resources))]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(5)]
        public string Rating { get; set; }
    }

    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Contact> Contacts { get; set; }
    }
}