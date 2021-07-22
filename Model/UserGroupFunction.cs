﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorLogin.Models
{
    public partial class UserGroupFunction
    {
        public long UserGroupFunctionId { get; set; }
        public long FromUserGroupId { get; set; }
        public string Relation { get; set; }
        public long ToFunctionId { get; set; }
        public string Description { get; set; }
        public long? SecurityGroupId { get; set; }
        public string SysState { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string ModifiedBy { get; set; }
        public long? TransactionId { get; set; }

        public virtual UserGroup FromUserGroup { get; set; }
        public virtual Function ToFunction { get; set; }
    }
}