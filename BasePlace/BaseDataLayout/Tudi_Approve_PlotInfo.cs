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
    
    public partial class Tudi_Approve_PlotInfo
    {
        public int Id { get; set; }
        public Nullable<int> Tudi_st_approveInfoId { get; set; }
        public Nullable<int> Tudi_ApproveInfoId { get; set; }
        public Nullable<int> Tudi_stph_ApproveInfoId { get; set; }
        public int Tudi_plotInfoId { get; set; }
        public int Tudi_dikuaiyongtuId { get; set; }
    
        public virtual Tudi_st_approveInfo Tudi_st_approveInfo { get; set; }
        public virtual Tudi_ApproveInfo Tudi_ApproveInfo { get; set; }
        public virtual Tudi_stph_ApproveInfo Tudi_stph_ApproveInfo { get; set; }
        public virtual Tudi_plotInfo Tudi_plotInfo { get; set; }
        public virtual Tudi_dikuaiyongtu Tudi_dikuaiyongtu { get; set; }
    }
}