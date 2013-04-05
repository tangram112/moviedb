using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace moviedb.Models
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext()
            : base("moviedb_cs")
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }

    public class Movie
    {
        public int ID { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }

        [Display(Name = "Tytuł")]
        public string Title { get; set; }

        [Display(Name = "Data prod.")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Gatunek")]
        public string Genre { get; set; }
        [Display(Name = "Wypożyczył")]
        public string WhoBorrowed { get; set; }
    }
}