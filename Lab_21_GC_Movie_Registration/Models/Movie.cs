using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lab_21_GC_Movie_Registration.Models
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class ValidMovieRangeAttribute : RangeAttribute
    {
        public ValidMovieRangeAttribute():base(1880, DateTime.Now.Year)
        {

        }
    }

    public class Movie
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="All movies must have a title.")]
        [StringLength(50,ErrorMessage ="That's a long movie title! Use some abbreviations if you have to.")]
        public string Title { get; set; }
        public string Genre { get; set; }

        [ValidMovieRange(ErrorMessage ="The year must be valid, between 1880 and now.")]
        public int Year { get; set; }
        public string Actors { get; set; }
        public string Directors { get; set; }

        public Movie(/*int _ID, string title, string genre, DateTime year*/)
        {
            //ID = _ID;
            //Title = title;
            //Genre = genre;
            //Year = year;
            //Actors = new List<string>();
            //Directors = new List<string>();
        }

        //public void ActorsFromCommaSeparatedString(string input)
        //{
        //    Actors = ListFromString(input);
        //}

        //public void DirectorsFromCommaSeparatedString(string input)
        //{
        //    Directors = ListFromString(input);
        //}

        //private List<string> ListFromString(string input)
        //{
        //    var delimiters = new[] { ", ", "," };
        //    return input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
        //}
    }
}
