﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorLogin.Models
{
    public partial class PeriodData
    {
        public PeriodData()
        {
            ActivityCenterAllocateRatio = new HashSet<ActivityCenterAllocateRatio>();
            ActivityCenterCost = new HashSet<ActivityCenterCost>();
            ActivityCenterWorkRate = new HashSet<ActivityCenterWorkRate>();
            ActualWorkHour = new HashSet<ActualWorkHour>();
            CurrencyExchange = new HashSet<CurrencyExchange>();
            CustomerServiceCost = new HashSet<CustomerServiceCost>();
            PeriodDataRun = new HashSet<PeriodDataRun>();
            ProductPeriodCost = new HashSet<ProductPeriodCost>();
            ProjectCost = new HashSet<ProjectCost>();
            ProjectCostSum = new HashSet<ProjectCostSum>();
            ResourceAdjustmentCost = new HashSet<ResourceAdjustmentCost>();
            SalesOrderItem = new HashSet<SalesOrderItem>();
            SalesOrderSum = new HashSet<SalesOrderSum>();
            StandardWorkHour = new HashSet<StandardWorkHour>();
            ValueObjectCost = new HashSet<ValueObjectCost>();
        }

        public long PeriodDataId { get; set; }
        public string PeriodDataNo { get; set; }
        public long PeriodId { get; set; }
        public long ModelId { get; set; }
        public string Comment { get; set; }
        public string Description { get; set; }
        public long? SecurityGroupId { get; set; }
        public string SysState { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string ModifiedBy { get; set; }
        public long? TransactionId { get; set; }
        public long? ExFileId { get; set; }

        public virtual Model Model { get; set; }
        public virtual Period Period { get; set; }
        public virtual ICollection<ActivityCenterAllocateRatio> ActivityCenterAllocateRatio { get; set; }
        public virtual ICollection<ActivityCenterCost> ActivityCenterCost { get; set; }
        public virtual ICollection<ActivityCenterWorkRate> ActivityCenterWorkRate { get; set; }
        public virtual ICollection<ActualWorkHour> ActualWorkHour { get; set; }
        public virtual ICollection<CurrencyExchange> CurrencyExchange { get; set; }
        public virtual ICollection<CustomerServiceCost> CustomerServiceCost { get; set; }
        public virtual ICollection<PeriodDataRun> PeriodDataRun { get; set; }
        public virtual ICollection<ProductPeriodCost> ProductPeriodCost { get; set; }
        public virtual ICollection<ProjectCost> ProjectCost { get; set; }
        public virtual ICollection<ProjectCostSum> ProjectCostSum { get; set; }
        public virtual ICollection<ResourceAdjustmentCost> ResourceAdjustmentCost { get; set; }
        public virtual ICollection<SalesOrderItem> SalesOrderItem { get; set; }
        public virtual ICollection<SalesOrderSum> SalesOrderSum { get; set; }
        public virtual ICollection<StandardWorkHour> StandardWorkHour { get; set; }
        public virtual ICollection<ValueObjectCost> ValueObjectCost { get; set; }
    }
}