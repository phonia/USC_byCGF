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
    
    public partial class Administrativecode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Administrativecode()
        {
            this.Land_managers = new HashSet<Land_manager>();
            this.ZipCodes = new HashSet<ZipCode>();
            this.IPCodes = new HashSet<IPCode>();
            this.Administrativecodes = new HashSet<Administrativecode>();
            this.OrganizBasics = new HashSet<OrganizBasic>();
            this.Tudi_gtgl_TaskCode = new HashSet<Tudi_gtgl_TaskCode>();
        }
    
        public int SacID { get; set; }
        public string DivisionCode { get; set; }
        public string RegionName { get; set; }
        public string ParentCode { get; set; }
        public Nullable<int> Parent { get; set; }
        public System.Data.Entity.Spatial.DbGeography Geometry { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Land_manager> Land_managers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ZipCode> ZipCodes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IPCode> IPCodes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Administrativecode> Administrativecodes { get; set; }
        public virtual Administrativecode Administrativecode1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrganizBasic> OrganizBasics { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tudi_gtgl_TaskCode> Tudi_gtgl_TaskCode { get; set; }
    }
}