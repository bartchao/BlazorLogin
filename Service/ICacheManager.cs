using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLogin
{
    interface ICacheManager
    {
        void Register(ITranslator translator, string company, string locale);
        void Publish(string company, string locale); 
    }

    class CacheManager : ICacheManager
    {
        List<ITranslator> _receivers;

        CacheManager()
        {
            _receivers = new List<ITranslator>();
        }
        public void Register(ITranslator translator, string company, string locale)
        {
            _receivers.Add(translator);
        }

    

        public void Publish(string company, string locale)
        { 
            /*foreach(var x in _receivers)
            {
                try
                {
                    if (x.Locale)
                    x.Reload();
                }
                catch (Exception)
                {
                    //ignore
                }
            }*/
        }
    }
}
