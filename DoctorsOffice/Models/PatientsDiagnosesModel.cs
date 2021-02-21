using System;

namespace DoctorsOffice.Models
{
    public class PatientsDiagnosesModel
    {
        public string Patient { get; set; }
        public string DiseaseAreas { get; set; }
        public string DiagnoseDescription { get; set; }
        public DateTime VisitTime { get; set; }

        public PatientsDiagnosesModel(string patient, string diseaseAreas, string diagnoseDescription, DateTime visitTime)
        {
            Patient = patient;
            DiseaseAreas = diseaseAreas;
            DiagnoseDescription = diagnoseDescription;
            VisitTime = visitTime;
        }
    }
}
