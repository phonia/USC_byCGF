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
    
    public partial class CustomTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomTable()
        {
            this.CustomTabDatas = new HashSet<CustomTabData>();
        }
    
        public int Id { get; set; }
        public string ColumnName { get; set; }
        public string DataType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomTabData> CustomTabDatas { get; set; }
    }
}
