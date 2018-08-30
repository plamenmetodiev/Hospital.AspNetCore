namespace Hospital.Web.Models.Patients
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AddMedicinesFormModel
    {
        public string Name { get; set; }

        public string Diagnosis { get; set; }

        [MinLength(1)]
        [Display(Name = "Medicines")]
        public int[] MedicinesIds { get; set; }

        public IEnumerable<SelectListItem> Medicines { get; set; }
    }
}
