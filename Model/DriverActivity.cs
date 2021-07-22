﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorLogin.Models
{
    public partial class DriverActivity
    {
        public long DriverActivityId { get; set; }
        public string DriverActivityNo { get; set; }
        public string Description { get; set; }
        public long? SecurityGroupId { get; set; }
        public string SysState { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string ModifiedBy { get; set; }
        public long? TransactionId { get; set; }
        public long DriverId { get; set; }
        public long ActivityId { get; set; }
        public long? ActivityCenterId { get; set; }
        public long? MachineGroupId { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual ActivityCenter ActivityCenter { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual MachineGroup MachineGroup { get; set; }
    }
}