namespace Hospital.Services.Models.DiagnosisServiceModels
{
    using Hospital.Common.Mapping;
    using Hospital.Data.Models;

    public class DiagnosisServiceModel : IMapFrom<Diagnosis>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
