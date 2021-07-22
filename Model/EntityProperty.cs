﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorLogin.Models
{
    public partial class EntityProperty
    {
        public EntityProperty()
        {
            EntityParameterValue = new HashSet<EntityParameterValue>();
        }

        public long EntityPropertyId { get; set; }
        public string EntityPropertyNo { get; set; }
        public string Description { get; set; }
        public long? SecurityGroupId { get; set; }
        public string SysState { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string ModifiedBy { get; set; }
        public long? TransactionId { get; set; }
        public long CompanyId { get; set; }
        public string EntityName { get; set; }
        public long? ObjectClassId { get; set; }
        public string Property { get; set; }
        public string UserProperty { get; set; }
        public long? PickListId { get; set; }
        public long? ClassificationTreeId { get; set; }
        public bool AllowFreeText { get; set; }
        public bool AllowNull { get; set; }
        public string DefaultValue { get; set; }
        public int ParameterUsagePriority { get; set; }

        public virtual ClassificationTree ClassificationTree { get; set; }
        public virtual Company Company { get; set; }
        public virtual ObjectClass ObjectClass { get; set; }
        public virtual PickList PickList { get; set; }
        public virtual ICollection<EntityParameterValue> EntityParameterValue { get; set; }
    }
}