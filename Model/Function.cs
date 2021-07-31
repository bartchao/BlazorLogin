﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BlazorLogin.Models
{
    public partial class Function
    {
        public Function()
        {
            UserGroupFunction = new HashSet<UserGroupFunction>();
        }
        [Editable(false)]
        public long FunctionId { get; set; }
        public string FunctionNo { get; set; }
        public string Description { get; set; }
        public long? SecurityGroupId { get; set; }
        public string SysState { get; set; }
        [Editable(false)]
        public DateTime? ModifiedTime { get; set; } = DateTime.Now;
        public string ModifiedBy { get; set; }
        public long? TransactionId { get; set; }
        public long CompanyId { get; set; } = 1;

        public virtual Company Company { get; set; }
        public virtual ICollection<UserGroupFunction> UserGroupFunction { get; set; }
    }
}