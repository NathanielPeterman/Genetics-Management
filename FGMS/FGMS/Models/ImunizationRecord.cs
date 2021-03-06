//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FGMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ImunizationRecord
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ImunizationRecord()
        {
            this.Healths = new HashSet<Health>();
        }
    
        public int ImunizationId { get; set; }
        public int animalId { get; set; }
        public int medicineId { get; set; }
        public string ImunizationType { get; set; }
        public bool booster { get; set; }
        public string reasonAdministered { get; set; }
        public double dosageGiven { get; set; }
        public string MethodOfDelivery { get; set; }
    
        public virtual Animal Animal { get; set; }
        public virtual Medicine Medicine { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Health> Healths { get; set; }
    }
}
