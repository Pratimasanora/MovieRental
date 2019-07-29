using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRental.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Movie Name is Mandatory")]

        [StringLength(50)]

        [Display(Name = "Movie Name")]
        public string MovieName { get; set; }

        [Display(Name = "No In Stock")]
        public int NoInStocks { get; set; }

        [Display(Name = "Release Date ")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Added Date")]
        public DateTime AddedDate { get; set; }
        
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
    }
}