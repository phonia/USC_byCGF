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
    
    public partial class Tudi_stph_ApproveInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tudi_stph_ApproveInfo()
        {
            this.Tudi_stph_ApproveInfo2 = new HashSet<Tudi_stph_ApproveInfo>();
            this.Tudi_Approve_PlotInfo = new HashSet<Tudi_Approve_PlotInfo>();
        }
    
        public int Id { get; set; }
        public string Proj_no { get; set; }
        public string Approve_notion { get; set; }
        public string Appr_no { get; set; }
        public string App_date { get; set; }
        public string Appr_date { get; set; }
        public string Appr_area { get; set; }
        public string Farm_tot { get; set; }
        public string Grp_farm_area { get; set; }
        public string State_farm_area { get; set; }
        public string Grp_tilth_area { get; set; }
        public string State_tilth_area { get; set; }
        public string Bf_group { get; set; }
        public string Build_tot { get; set; }
        public string Grp_bld_area { get; set; }
        public string State_bld_area { get; set; }
        public string Unused_tot { get; set; }
        public string Grp_unused_area { get; set; }
        public string State_unused_area { get; set; }
        public string Check_area { get; set; }
        public string Chk_tilth_area { get; set; }
        public string Supply_tilth_area { get; set; }
        public string Plan_tilth_area { get; set; }
        public string Plan_tlth_Area { get; set; }
        public string Posit_tilth_pop { get; set; }
        public string Posit_labour { get; set; }
        public string Put_way { get; set; }
        public string Transfer_area { get; set; }
        public string Remise_area { get; set; }
        public string Remise_money { get; set; }
        public string Lease_area { get; set; }
        public string Year_money { get; set; }
        public string Stock_area { get; set; }
        public string Stock_money { get; set; }
        public string Approve_state { get; set; }
        public string Approve_type { get; set; }
        public int Tudi_projInfoId { get; set; }
        public Nullable<int> Tudi_stph_ApproveInfoId { get; set; }
    
        public virtual Tudi_projInfo Tudi_projInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tudi_stph_ApproveInfo> Tudi_stph_ApproveInfo2 { get; set; }
        public virtual Tudi_stph_ApproveInfo Tudi_stph_ApproveInfo1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tudi_Approve_PlotInfo> Tudi_Approve_PlotInfo { get; set; }
    }
}
