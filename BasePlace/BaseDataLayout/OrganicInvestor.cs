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
    
    public partial class OrganicInvestor
    {
        public int ID { get; set; }
        public Nullable<int> Investor { get; set; }
        public string InvestorName { get; set; }
        public int InvestorNumber { get; set; }
        public string CentisifierType { get; set; }
        public int OrganizBasicID { get; set; }
        public decimal Amount { get; set; }
        public string Unit { get; set; }
        public string Currency { get; set; }
    
        public virtual OrganizBasic OrganizBasic { get; set; }
        public virtual OrganizBasic OrganizBasic1 { get; set; }
    }
}
