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
    
    public partial class CustomTabData
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public int CustomTableId { get; set; }
        public Nullable<int> DocumentManageID { get; set; }
    
        public virtual CustomTable CustomTable { get; set; }
        public virtual DocumentManage DocumentManage { get; set; }
    }
}
