// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorLogin.Models
{
    public partial class School
    {
        public long SchoolId { get; set; }
        public string SchoolNo { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string DomainName { get; set; }
        public bool Authorize { get; set; }
        public long MaxAccountCount { get; set; }
        public long AccountCount { get; set; }
        public DateTime Deadline { get; set; }
        public string SysState { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
    }
}