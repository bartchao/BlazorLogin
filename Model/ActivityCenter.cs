// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorLogin.Models
{
    public partial class ActivityCenter
    {
        public ActivityCenter()
        {
            ActivityCenterAllocateRatioFromActivityCenter = new HashSet<ActivityCenterAllocateRatio>();
            ActivityCenterAllocateRatioToActivityCenter = new HashSet<ActivityCenterAllocateRatio>();
            ActivityCenterCost = new HashSet<ActivityCenterCost>();
            ActivityCenterWorkRate = new HashSet<ActivityCenterWorkRate>();
            ActualActivityTime = new HashSet<ActualActivityTime>();
            ActualWorkHourActivityCenter = new HashSet<ActualWorkHour>();
            ActualWorkHourSupportedActivityCenter = new HashSet<ActualWorkHour>();
            DriverActivity = new HashSet<DriverActivity>();
            Employee = new HashSet<Employee>();
            InverseParentActivityCenter = new HashSet<ActivityCenter>();
            MachineGroup = new HashSet<MachineGroup>();
            ProjectCost = new HashSet<ProjectCost>();
            ResourceAdjustmentCost = new HashSet<ResourceAdjustmentCost>();
            SalesOrderItem = new HashSet<SalesOrderItem>();
            StandardActivityTime = new HashSet<StandardActivityTime>();
            StandardWorkHour = new HashSet<StandardWorkHour>();
            ValueObject = new HashSet<ValueObject>();
            ValueObjectCost = new HashSet<ValueObjectCost>();
        }

        public long ActivityCenterId { get; set; }
        public string ActivityCenterNo { get; set; }
        public string Description { get; set; }
        public long? SecurityGroupId { get; set; }
        public string SysState { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string ModifiedBy { get; set; }
        public long? TransactionId { get; set; }
        public long BusinessUnitId { get; set; }
        public bool IsImplementAbc { get; set; }
        public bool IsSalesRevenue { get; set; }
        public long? ParentActivityCenterId { get; set; }
        public long? AllocateDriverId { get; set; }
        public long ObjectClassId { get; set; }
        public string UserProperty1 { get; set; }
        public string UserProperty2 { get; set; }
        public string UserProperty3 { get; set; }
        public string UserProperty4 { get; set; }
        public string UserProperty5 { get; set; }
        public string UserProperty6 { get; set; }
        public string UserProperty7 { get; set; }
        public string UserProperty8 { get; set; }
        public string UserProperty9 { get; set; }
        public string UserProperty10 { get; set; }
        public string UserProperty11 { get; set; }
        public string UserProperty12 { get; set; }
        public string UserProperty13 { get; set; }
        public string UserProperty14 { get; set; }
        public string UserProperty15 { get; set; }
        public string UserProperty16 { get; set; }
        public string UserProperty17 { get; set; }
        public string UserProperty18 { get; set; }
        public string UserProperty19 { get; set; }
        public string UserProperty20 { get; set; }
        public long? ClassificationId1 { get; set; }
        public long? ClassificationId2 { get; set; }
        public long? ClassificationId3 { get; set; }
        public long? ClassificationId4 { get; set; }
        public long? ClassificationId5 { get; set; }
        public long? ClassificationId6 { get; set; }
        public long? ClassificationId7 { get; set; }
        public long? ClassificationId8 { get; set; }
        public long? ClassificationId9 { get; set; }
        public long? ClassificationId10 { get; set; }
        public long CompanyId { get; set; }

        public virtual Driver AllocateDriver { get; set; }
        public virtual BusinessUnit BusinessUnit { get; set; }
        public virtual Company Company { get; set; }
        public virtual ActivityCenter ParentActivityCenter { get; set; }
        public virtual ICollection<ActivityCenterAllocateRatio> ActivityCenterAllocateRatioFromActivityCenter { get; set; }
        public virtual ICollection<ActivityCenterAllocateRatio> ActivityCenterAllocateRatioToActivityCenter { get; set; }
        public virtual ICollection<ActivityCenterCost> ActivityCenterCost { get; set; }
        public virtual ICollection<ActivityCenterWorkRate> ActivityCenterWorkRate { get; set; }
        public virtual ICollection<ActualActivityTime> ActualActivityTime { get; set; }
        public virtual ICollection<ActualWorkHour> ActualWorkHourActivityCenter { get; set; }
        public virtual ICollection<ActualWorkHour> ActualWorkHourSupportedActivityCenter { get; set; }
        public virtual ICollection<DriverActivity> DriverActivity { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<ActivityCenter> InverseParentActivityCenter { get; set; }
        public virtual ICollection<MachineGroup> MachineGroup { get; set; }
        public virtual ICollection<ProjectCost> ProjectCost { get; set; }
        public virtual ICollection<ResourceAdjustmentCost> ResourceAdjustmentCost { get; set; }
        public virtual ICollection<SalesOrderItem> SalesOrderItem { get; set; }
        public virtual ICollection<StandardActivityTime> StandardActivityTime { get; set; }
        public virtual ICollection<StandardWorkHour> StandardWorkHour { get; set; }
        public virtual ICollection<ValueObject> ValueObject { get; set; }
        public virtual ICollection<ValueObjectCost> ValueObjectCost { get; set; }
    }
}