//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RegisterOfCatchingWorkSchedules
{
    using System;
    using System.Collections.Generic;
    
    public partial class Plans
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Plans()
        {
            this.StatusHistory = new HashSet<StatusHistory>();
            this.Records = new HashSet<Records>();
        }
    
        public int ID { get; set; }
        public int OrganisationID { get; set; }
        public int PlanStatusID { get; set; }
        public int PlanMunicipalityID { get; set; }
        public Nullable<System.DateTime> PlanDate { get; set; }
        public Nullable<System.DateTime> StatusChangeDate { get; set; }
        public string StatusComment { get; set; }
    
        public virtual Municipality Municipality { get; set; }
        public virtual Organisation Organisation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StatusHistory> StatusHistory { get; set; }
        public virtual Statuses Statuses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Records> Records { get; set; }
    }
}
