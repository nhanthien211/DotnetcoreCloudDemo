using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceSample.Entity
{
    
    public class Movie
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }

        
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "In stock")]
        public int NumberInStock { get; set; }

        public Genre Genre { get; set; }
    }
}
