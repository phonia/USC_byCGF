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
    
    public partial class OrgaRegisterDocment
    {
        public int ID { get; set; }
        public int OrganizBasicID { get; set; }
        public string DocumentName { get; set; }
        public int RegisterDocumentTypeID { get; set; }
        public byte[] DocmentContent { get; set; }
        public string DocumentFormat { get; set; }
        public System.DateTime RecordeTime { get; set; }
        public long EventTime { get; set; }
        public long EventTime1 { get; set; }
    
        public virtual OrganizBasic OrganizBasic { get; set; }
        public virtual RegisterDocumentType RegisterDocumentType { get; set; }
    }
}
