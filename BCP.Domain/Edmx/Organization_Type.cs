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
    
    public partial class Organization_Type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Organization_Type()
        {
            this.Organization_Type1 = new HashSet<Organization_Type>();
            this.OrganizBasics = new HashSet<OrganizBasic>();
        }
    
        public int ID { get; set; }
        public string Ocode { get; set; }
        public string OName { get; set; }
        public string Descript { get; set; }
        public string ParentCode { get; set; }
        public Nullable<int> Parent { get; set; }
        public long EventTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Organization_Type> Organization_Type1 { get; set; }
        public virtual Organization_Type Organization_Type2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrganizBasic> OrganizBasics { get; set; }
    }
}
