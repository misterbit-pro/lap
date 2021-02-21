using System.Collections.Generic;

namespace DoctorsOffice.Database
{
    public partial class Diseaseareas
    {
        public Diseaseareas()
        {
            Diagnoses = new HashSet<Diagnoses>();
        }

        public int DisId { get; set; }
        public string DisName { get; set; }

        public virtual ICollection<Diagnoses> Diagnoses { get; set; }
    }
}
