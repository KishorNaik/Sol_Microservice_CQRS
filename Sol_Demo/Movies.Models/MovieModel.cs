using System;

namespace Movies.Models
{
    public class MovieModel
    {
        public Guid MovieIdentity { get; set; }

        public String Title { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public bool? IsDelete { get; set; }

        // Miss

        public DateTime? ReleaseStartDate { get; set; }

        public DateTime? ReleaseEndDate { get; set; }
    }
}