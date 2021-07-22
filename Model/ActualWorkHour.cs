﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorLogin.Models
{
    public partial class ActualWorkHour
    {
        public long ActualWorkHourId { get; set; }
        public long PeriodDataId { get; set; }
        public long ActivityCenterId { get; set; }
        public long? MachineGroupId { get; set; }
        public long? SupportedActivityCenterId { get; set; }
        public long? SupportedMachineGroupId { get; set; }
        public long ActivityId { get; set; }
        public decimal ActWorkHour { get; set; }
        public decimal? OvertimeHour { get; set; }
        public string Reason { get; set; }
        public string Comment { get; set; }
        public long? CopyMachineGroupActivityId { get; set; }
        public string Description { get; set; }
        public long? SecurityGroupId { get; set; }
        public string SysState { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string ModifiedBy { get; set; }
        public long? TransactionId { get; set; }
        public long? ValueObjectId { get; set; }
        public long? ProductId { get; set; }
        public string Label1 { get; set; }
        public string Label2 { get; set; }
        public string Label3 { get; set; }
        public string Label4 { get; set; }
        public string Label5 { get; set; }
        public string Label6 { get; set; }
        public string Label7 { get; set; }
        public string Label8 { get; set; }
        public string Label9 { get; set; }
        public string Label10 { get; set; }
        public string Label11 { get; set; }
        public string Label12 { get; set; }
        public string Label13 { get; set; }
        public string Label14 { get; set; }
        public string Label15 { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual ActivityCenter ActivityCenter { get; set; }
        public virtual MachineGroupActivity CopyMachineGroupActivity { get; set; }
        public virtual MachineGroup MachineGroup { get; set; }
        public virtual PeriodData PeriodData { get; set; }
        public virtual ValueObject Product { get; set; }
        public virtual ActivityCenter SupportedActivityCenter { get; set; }
        public virtual MachineGroup SupportedMachineGroup { get; set; }
        public virtual ValueObject ValueObject { get; set; }
    }
}