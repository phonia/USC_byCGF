//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaseDataLayout
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.JobChanges = new HashSet<JobChange>();
        }
    
        public int Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string EmpCode { get; set; }
        public int UserID { get; set; }
        public string Isvalid { get; set; }
        public Nullable<int> PositionID { get; set; }
        public Nullable<int> OrganizationID { get; set; }
    
        public virtual User User { get; set; }
        public virtual Position Position { get; set; }
        public virtual Organization Organization { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobChange> JobChanges { get; set; }
    }
}
