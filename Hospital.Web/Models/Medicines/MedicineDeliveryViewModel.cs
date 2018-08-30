using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Web.Models.Medicines
{
    public class MedicineDeliveryViewModel : MedicineDeliverFormModel
    {
        public string Name { get; set; }

        public string Supplier { get; set; }
    }
}
