using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLogin
{
    public class InitLoginState
    {
        public string UserId { get; set; }
    }
    public class SessionStateProvider
    {
        public string UserId { get; set; }
        public ITranslator.eLocale Locale { get; set; }
        public string Company { get; set; }
        public int Times { get; set; }
    }
}
