using System;

namespace DoctorsOffice.Database
{
    public partial class Patientsdiagnoses
    {
        public int PatdiaId { get; set; }
        public DateTime PatdiaVisit { get; set; }
        public int? PatId { get; set; }
        public int DiaId { get; set; }

        public virtual Diagnoses Dia { get; set; }
        public virtual Patients Pat { get; set; }
    }
}
