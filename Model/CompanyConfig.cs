﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorLogin.Models
{
    public partial class CompanyConfig
    {
        public long CompanyConfigId { get; set; }
        public string CompanyConfigNo { get; set; }
        public string Description { get; set; }
        public long? SecurityGroupId { get; set; }
        public string SysState { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string ModifiedBy { get; set; }
        public long? TransactionId { get; set; }
        public long CompanyId { get; set; }
        public string Value { get; set; }
        public bool? IsEnable { get; set; }
    }
}