//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UventaApp.Resources.Dictionarys
{
    using System;
    using System.Collections.Generic;
    
    public partial class RentalObject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RentalObject()
        {
            this.Rent = new HashSet<Rent>();
        }
    
        public int RentalObjectId { get; set; }
        public int BuildingId { get; set; }
        public int ObjectNumber { get; set; }
        public double Area { get; set; }
        public decimal RentalPrice { get; set; }
    
        public virtual Building Building { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rent> Rent { get; set; }
    }
}
