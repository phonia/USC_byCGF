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
    
    public partial class Specialized
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Specialized()
        {
            this.Specializeds = new HashSet<Specialized>();
            this.Postbasics = new HashSet<PostRequire>();
        }
    
        public int ID { get; set; }
        public string Code { get; set; }
        public string SpecialName { get; set; }
        public string Descript { get; set; }
        public string ParentCode { get; set; }
        public Nullable<int> Parent { get; set; }
        public long EventTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Specialized> Specializeds { get; set; }
        public virtual Specialized Specialized1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostRequire> Postbasics { get; set; }
    }
}
