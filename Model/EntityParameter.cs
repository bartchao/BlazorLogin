// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorLogin.Models
{
    public partial class EntityParameter
    {
        public EntityParameter()
        {
            EntityParameterValue = new HashSet<EntityParameterValue>();
        }

        public long EntityParameterId { get; set; }
        public string EntityParameterNo { get; set; }
        public string Description { get; set; }
        public long? SecurityGroupId { get; set; }
        public string SysState { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string ModifiedBy { get; set; }
        public long? TransactionId { get; set; }
        public long CompanyId { get; set; }
        public string EntityName { get; set; }
        public string Parameter { get; set; }
        public string DataType { get; set; }
        public long ObjectClassId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ObjectClass ObjectClass { get; set; }
        public virtual ICollection<EntityParameterValue> EntityParameterValue { get; set; }
    }
}