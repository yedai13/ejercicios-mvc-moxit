using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Ejercicios.Unidad2.Models;

namespace Ejercicios.Unidad2.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        [Required(ErrorMessage = "Number in Stock field is required")]
        public byte? NumberInStock { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Select genre")]
        public byte? GenreId { get; set; }

        public string Title => Id != 0 ? "Edit Movie" : "New Movie";

        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
            
        }
    }
}
