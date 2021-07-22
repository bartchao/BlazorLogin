using BlazorLogin.Data;
using BlazorLogin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BlazorLogin.ITranslator;

namespace BlazorLogin
{
    public interface ITranslator
    {
        public enum eLocale
        {
            en_US,zh_TW,zh_CN
        }
        eLocale Locale { get; set; }
        string Company { get; set; }
        string Get(string input);
        void SetLocale(string company, eLocale locale);
        List<Dictionary> Dict { get; set; }
        void Reload();

    }
    class Translator : ITranslator
    {
        private readonly TEMPLATE20Context _context;
        private string _Company;
        private eLocale _Locale;
        //private string _Locale;
        public Translator(TEMPLATE20Context context)
        {
            _context = context;
        }
        public void SetLocale(string company,eLocale locale)
        {
            _Company = company;
            _Locale = locale;
            Reload();
        }

        
        string ITranslator.Company
        {
            get { return _Company; }
            set { _Company = value; }
        }

        eLocale ITranslator.Locale
        {
            get { return _Locale; }
            set { _Locale = value; }
        }

        public List<Dictionary> Dict { get;set; }
        

        public string Get(string Input)
        {
            string value;
            var result = Dict?.FirstOrDefault(x => x.DictionaryNo == Input);
            if (result != null)
                return result.DisplayText;
            else
                return Input;
        }

        public void Reload()
        {
            string locale = _Locale.ToString().Replace("_", "-");
            string sql = string.Format(@"select * from dbo.Dictionary as d where d.CompanyId = (select CompanyId from dbo.Company as c where c.CompanyNo = '{0}')  and d.Locale = '{1}'", _Company, locale);
            Dict = _context.Dictionary.FromSqlRaw(sql).ToList();
        }

    }
}
