using System.Collections.Generic;

namespace MovieManagement.Database
{
    public partial class ProductionCompany
    {
        public ProductionCompany()
        {
            Movie = new HashSet<Movie>();
        }

        public int PrcId { get; set; }
        public string PrcName { get; set; }

        public virtual ICollection<Movie> Movie { get; set; }
    }
}
