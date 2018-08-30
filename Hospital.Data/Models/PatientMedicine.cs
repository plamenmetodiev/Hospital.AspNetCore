namespace Hospital.Data.Models
{
    public class PatientMedicine
    {
        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        public int MedicineId { get; set; }

        public Medicine Medicine { get; set; }
    }
}
