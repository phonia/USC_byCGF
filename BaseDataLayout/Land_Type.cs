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
    
    public partial class Land_Type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Land_Type()
        {
            this.Children = new HashSet<Land_Type>();
            this.Land_manager = new HashSet<Land_manager>();
            this.Land_Items = new HashSet<Land_manager>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int Level { get; set; }
        public string Keys { get; set; }
        public Nullable<int> ParentID { get; set; }
        public string Type_Code { get; set; }
        public string ParentCode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Land_Type> Children { get; set; }
        public virtual Land_Type Parent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Land_manager> Land_manager { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Land_manager> Land_Items { get; set; }
    }
}
