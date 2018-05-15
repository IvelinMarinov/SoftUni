using System.Collections.Generic;

namespace P01_HospitalDatabase.Data.Models
{
    public class Medicament
    {
        public int MedicamentId { get; set; }

        public string Name { get; set; }

        public IList<PatientMedicament> Prescriptions { get; set; }
    }
}
