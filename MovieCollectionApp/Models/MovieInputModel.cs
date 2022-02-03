using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollectionApp.Models
{
    public class MovieInputModel
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Enter a movie title.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Enter a movie year.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Enter the movie director.")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Enter the movie rating.")]
        public string Rating { get; set; }

        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [StringLength(25)]
        public string Notes { get; set; }

        // Build Foreign Key Relationship
        [Required]
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
    }
}
