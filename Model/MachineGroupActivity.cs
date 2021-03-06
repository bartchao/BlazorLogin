// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorLogin.Models
{
    public partial class MachineGroupActivity
    {
        public MachineGroupActivity()
        {
            ActualWorkHour = new HashSet<ActualWorkHour>();
            StandardWorkHour = new HashSet<StandardWorkHour>();
        }

        public long MachineGroupActivityId { get; set; }
        public long FromMachineGroupId { get; set; }
        public string Relation { get; set; }
        public long ToActivityId { get; set; }
        public long? MainMachineGroupId { get; set; }
        public string Description { get; set; }
        public long? SecurityGroupId { get; set; }
        public string SysState { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string ModifiedBy { get; set; }
        public long? TransactionId { get; set; }

        public virtual MachineGroup FromMachineGroup { get; set; }
        public virtual MachineGroup MainMachineGroup { get; set; }
        public virtual Activity ToActivity { get; set; }
        public virtual ICollection<ActualWorkHour> ActualWorkHour { get; set; }
        public virtual ICollection<StandardWorkHour> StandardWorkHour { get; set; }
    }
}