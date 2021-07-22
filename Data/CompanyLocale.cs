using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLogin.Data
{
    [Keyless]
    public class CompanyLocale
    {
        public string CompanyNo { get; set; }
        public string Locale { get; set; }
    }
    
    public partial class TEMPLATE20Context
    {
        public virtual DbSet<CompanyLocale> CompanyLocale { get; set; }
    }
}
