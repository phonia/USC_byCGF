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
    
    public partial class IncurredExpense
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ContentDescription { get; set; }
        public string Place { get; set; }
        public string ReceiptNumber { get; set; }
        public string Amount { get; set; }
        public int TaskID { get; set; }
        public string ExpenseType { get; set; }
    
        public virtual Task Task { get; set; }
    }
}