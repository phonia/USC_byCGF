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
    
    public partial class PostRequire
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PostRequire()
        {
            this.Positions = new HashSet<Position>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public int SpecializedID { get; set; }
        public string Description { get; set; }
        public string Ranks { get; set; }
        public string EducationRequirement { get; set; }
        public string SkillRequirement { get; set; }
        public string State { get; set; }
        public long EventTime { get; set; }
    
        public virtual Specialized Specialized { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Position> Positions { get; set; }
    }
}
