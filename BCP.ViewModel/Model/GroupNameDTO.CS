using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// GroupName DTO
    /// </summary>
    public partial class GroupNameDTO
    {
        public System.Int32 ID { get; set; }
        public System.String Name { get; set; }
        public System.String CreatTime { get; set; }
        public System.Int32 UserID { get; set; }
        public System.String GroupNumber { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}

