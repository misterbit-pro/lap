using System.Collections.Generic;

namespace DoctorsOffice.Database
{
    public partial class Diagnoses
    {
        public Diagnoses()
        {
            Patientsdiagnoses = new HashSet<Patientsdiagnoses>();
        }

        public int DiaId { get; set; }
        public string DiaDescription { get; set; }
        public int? DisId { get; set; }

        public virtual Diseaseareas Dis { get; set; }
        public virtual ICollection<Patientsdiagnoses> Patientsdiagnoses { get; set; }
    }
}
