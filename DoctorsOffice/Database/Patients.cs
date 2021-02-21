using System;
using System.Collections.Generic;

namespace DoctorsOffice.Database
{
    public partial class Patients
    {
        public Patients()
        {
            Patientsdiagnoses = new HashSet<Patientsdiagnoses>();
        }

        public int PatId { get; set; }
        public string PatFirstName { get; set; }
        public string PatLastName { get; set; }
        public DateTime PatBirthday { get; set; }
        public long? PatSvnr { get; set; }

        public virtual ICollection<Patientsdiagnoses> Patientsdiagnoses { get; set; }
    }
}
