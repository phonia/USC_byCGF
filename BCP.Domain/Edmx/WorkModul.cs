//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace BCP.Domain.Edmx
{
    using System;
    using System.Collections.Generic;
    
    public partial class WorkModul
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WorkModul()
        {
            this.WorkModuls = new HashSet<WorkModul>();
            this.WorkSpaceRoles = new HashSet<WorkSpaceRole>();
            this.ModulProperties = new HashSet<ModulProperty>();
        }
    
        public int Id { get; set; }
        public Nullable<int> FunctionGroupID { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string ActivityType { get; set; }
        public Nullable<int> WorkModulId { get; set; }
        public Nullable<int> DllFileStreamID { get; set; }
        public long EventTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkModul> WorkModuls { get; set; }
        public virtual WorkModul WorkModul1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkSpaceRole> WorkSpaceRoles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ModulProperty> ModulProperties { get; set; }
        public virtual DllFileStream DllFileStream { get; set; }
    }
}
