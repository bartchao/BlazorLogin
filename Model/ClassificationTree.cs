﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorLogin.Models
{
    public partial class ClassificationTree
    {
        public ClassificationTree()
        {
            Classification = new HashSet<Classification>();
            EntityClassificationTree = new HashSet<EntityClassificationTree>();
            EntityProperty = new HashSet<EntityProperty>();
        }

        public long ClassificationTreeId { get; set; }
        public string ClassificationTreeNo { get; set; }
        public string Description { get; set; }
        public long? SecurityGroupId { get; set; }
        public string SysState { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string ModifiedBy { get; set; }
        public long? TransactionId { get; set; }
        public long CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<Classification> Classification { get; set; }
        public virtual ICollection<EntityClassificationTree> EntityClassificationTree { get; set; }
        public virtual ICollection<EntityProperty> EntityProperty { get; set; }
    }
}