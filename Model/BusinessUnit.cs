﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorLogin.Models
{
    public partial class BusinessUnit
    {
        public BusinessUnit()
        {
            ActivityCenter = new HashSet<ActivityCenter>();
            BusinessUnitResource = new HashSet<BusinessUnitResource>();
            CustomerServiceCost = new HashSet<CustomerServiceCost>();
            MoMaterialCost = new HashSet<MoMaterialCost>();
            MoProductCost = new HashSet<MoProductCost>();
            PartStock = new HashSet<PartStock>();
            PartStockBom = new HashSet<PartStockBom>();
            ProjectCost = new HashSet<ProjectCost>();
            SalesOrderItemBusinessUnit = new HashSet<SalesOrderItem>();
            SalesOrderItemShippingBusinessUnit = new HashSet<SalesOrderItem>();
            SalesOrderSum = new HashSet<SalesOrderSum>();
            StandardActivityTime = new HashSet<StandardActivityTime>();
            ValueObjectCost = new HashSet<ValueObjectCost>();
        }

        public long BusinessUnitId { get; set; }
        public string BusinessUnitNo { get; set; }
        public string Description { get; set; }
        public long? SecurityGroupId { get; set; }
        public string SysState { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string ModifiedBy { get; set; }
        public long? TransactionId { get; set; }
        public long CompanyId { get; set; }
        public string Currency { get; set; }
        public string Region { get; set; }
        public string Locale { get; set; }
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

        public virtual Company Company { get; set; }
        public virtual ICollection<ActivityCenter> ActivityCenter { get; set; }
        public virtual ICollection<BusinessUnitResource> BusinessUnitResource { get; set; }
        public virtual ICollection<CustomerServiceCost> CustomerServiceCost { get; set; }
        public virtual ICollection<MoMaterialCost> MoMaterialCost { get; set; }
        public virtual ICollection<MoProductCost> MoProductCost { get; set; }
        public virtual ICollection<PartStock> PartStock { get; set; }
        public virtual ICollection<PartStockBom> PartStockBom { get; set; }
        public virtual ICollection<ProjectCost> ProjectCost { get; set; }
        public virtual ICollection<SalesOrderItem> SalesOrderItemBusinessUnit { get; set; }
        public virtual ICollection<SalesOrderItem> SalesOrderItemShippingBusinessUnit { get; set; }
        public virtual ICollection<SalesOrderSum> SalesOrderSum { get; set; }
        public virtual ICollection<StandardActivityTime> StandardActivityTime { get; set; }
        public virtual ICollection<ValueObjectCost> ValueObjectCost { get; set; }
    }
}