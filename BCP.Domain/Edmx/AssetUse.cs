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
    
    public partial class AssetUse
    {
        public int Id { get; set; }
        public int physicalAssetId { get; set; }
        public string UseType { get; set; }
        public string User { get; set; }
        public string UseTime { get; set; }
        public string PlaceOfUse { get; set; }
        public long EventTime { get; set; }
    
        public virtual physicalAsset physicalAsset { get; set; }
    }
}
