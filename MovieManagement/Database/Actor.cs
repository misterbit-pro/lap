using System.Collections.Generic;

namespace MovieManagement.Database
{
    public partial class Actor
    {
        public Actor()
        {
            MovieActor = new HashSet<MovieActor>();
        }

        public int ActId { get; set; }
        public string ActFirstName { get; set; }
        public string ActLastName { get; set; }
        public string ActOriginCountry { get; set; }

        public virtual ICollection<MovieActor> MovieActor { get; set; }
    }
}
