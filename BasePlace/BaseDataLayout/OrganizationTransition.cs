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
    
    public partial class OrganizationTransition
    {
        public int ID { get; set; }
        public string Cause { get; set; }
        public string FundAlteration { get; set; }
        public string PropertyAlteration { get; set; }
        public System.DateTime Time { get; set; }
        public string Others { get; set; }
        public string Description { get; set; }
        public Nullable<int> OldOrgan { get; set; }
        public Nullable<int> NewOrgan { get; set; }
    
        public virtual Organization Organization { get; set; }
        public virtual Organization Organization1 { get; set; }
    }
}
