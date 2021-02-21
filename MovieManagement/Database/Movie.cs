using System;
using System.Collections.Generic;

namespace MovieManagement.Database
{
    public partial class Movie
    {
        public Movie()
        {
            MovieActor = new HashSet<MovieActor>();
        }

        public int MovId { get; set; }
        public int PrcId { get; set; }
        public string MovTitle { get; set; }
        public DateTime? MovReleased { get; set; }

        public virtual ProductionCompany Prc { get; set; }
        public virtual ICollection<MovieActor> MovieActor { get; set; }
    }
}
