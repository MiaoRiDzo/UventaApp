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
    
    public partial class Rent
    {
        public int RentId { get; set; }
        public int RentalObjectId { get; set; }
        public int TenantId { get; set; }
        public System.DateTime ContractCreationDate { get; set; }
        public System.DateTime ContractStartDate { get; set; }
        public System.DateTime ContractEndDate { get; set; }
    
        public virtual RentalObject RentalObject { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
}
