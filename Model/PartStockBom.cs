// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorLogin.Models
{
    public partial class PartStockBom
    {
        public long BusinessUnitId { get; set; }
        public string ProductNo { get; set; }
        public string MaterialNo { get; set; }
        public string Description { get; set; }
        public long? SecurityGroupId { get; set; }
        public string SysState { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string ModifiedBy { get; set; }
        public long? TransactionId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public string Version { get; set; }

        public virtual BusinessUnit BusinessUnit { get; set; }
    }
}