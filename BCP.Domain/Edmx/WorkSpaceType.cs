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
    
    public partial class WorkSpaceType
    {
        public int Id { get; set; }
        public string ByProperty { get; set; }
        public Nullable<int> WorkSpaceID { get; set; }
        public Nullable<int> WorkSpaceBaseTypeId { get; set; }
        public long EventTime { get; set; }
    
        public virtual WorkSpace WorkSpace { get; set; }
        public virtual WorkSpaceBaseType WorkSpaceBaseType { get; set; }
    }
}
