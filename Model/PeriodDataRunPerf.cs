﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorLogin.Models
{
    public partial class PeriodDataRunPerf
    {
        public long PeriodDataRunPerfId { get; set; }
        public string PeriodDataRunPerfNo { get; set; }
        public long PeriodDataRunId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public int? RunSecond { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string ModifiedBy { get; set; }
        public long? TransactionId { get; set; }
        public string Description { get; set; }

        public virtual PeriodDataRun PeriodDataRun { get; set; }
    }
}