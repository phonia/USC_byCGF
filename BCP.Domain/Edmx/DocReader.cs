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
    
    public partial class DocReader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DocReader()
        {
            this.DocLocations = new HashSet<DocLocation>();
        }
    
        public int Id { get; set; }
        public Nullable<int> WorkSpaceID { get; set; }
        public Nullable<int> OrganizationID { get; set; }
        public Nullable<int> PostID { get; set; }
        public Nullable<int> UserID { get; set; }
        public long EventTime { get; set; }
    
        public virtual Organization Organization { get; set; }
        public virtual WorkSpace WorkSpace { get; set; }
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocLocation> DocLocations { get; set; }
    }
}
