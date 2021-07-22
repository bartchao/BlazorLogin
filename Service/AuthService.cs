using BlazorLogin.Data;
using BlazorLogin.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace BlazorLogin
{
    public static class MD5Password
    {
        public static bool NewMD5Password(string verify, string answer)
        {
            MD5 md5 = MD5.Create();
            string resultMd5 = Convert.ToBase64String(md5.ComputeHash(Encoding.Default.GetBytes(verify)));
            return (resultMd5 == answer);
        }
    }
    public class AuthService
    {
        private readonly TEMPLATE20Context _context;
        public AuthService(TEMPLATE20Context context)
        {
            _context = context;
        }
        public User loginUser { get; private set; }
        public User Login(string username, string password)
        {
            var result = from user in _context.User where user.UserNo == username select user;
            if (result.Count() != 0)
            {
                var user = result.First();
                bool verify = MD5Password.NewMD5Password(password, user.Password);
                if (verify)
                {
                    loginUser = user;
                    
                    return user;
                }
                else
                {
                    throw new Exception("Password Error");
                }
            }
            else if (result.Count() == 0)
            {
                throw new Exception("User not found.");
            }
            else
            {
                throw new Exception("ERROR");
            }
            
        }
        public Dictionary<string,List<string>> GetCompanyLocales(string userid)
        {
            string sql = string.Format(@"
                SELECT distinct * FROM (
                select distinct  d.CompanyId,d.CompanyNo, f.PickListValueNo as 'Locale' 
                from [User] a 
                inner join UserUserGroup b on a.UserId = b.FromUserId 
                inner join UserGroup c on b.ToUserGroupId = c.UserGroupId
                inner join Company d on c.CompanyId = d.CompanyId and d.SysState!='T'
                left join PickList e on d.CompanyId = e.CompanyId
                inner join PickListValue f on e.PickListId = f.PickListId
                where a.UserId = {0} and e.PickListNo ='Locale' 
                UNION ALL
                SELECT distinct C.CompanyID,C.CompanyNo, PLV.PickListValueNo as 'Locale' 
                FROM 
                 Company C LEFT JOIN
                 PickList PL on C.CompanyId = PL.CompanyId INNER JOIN
                 PickListValue PLV on PLV.PickListId = PL.PickListId ,
                 UserUserGroup UUG INNER JOIN
                 UserGroup UG ON UUG.ToUserGroupId = UG.UserGroupId AND UG.UserGroupNo = 'Infofab'
 
                WHERE
                 PL.PickListNo = 'Locale' AND UUG.FromUserId = {0}
                ) CL
                ORDER BY 1,2", userid);
            var result = _context.CompanyLocale.FromSqlRaw(sql).ToList();
            var company = (from p in result select p.CompanyNo).Distinct().ToList();
            Dictionary<string, List<string>> pairs = new Dictionary<string, List<string>>();
            foreach(var c in company)
            {
                var locales = (from loc in result where loc.CompanyNo==c select loc.Locale).ToList();
                if (locales.Count == 0)
                {
                    locales = new List<string>(new string[] { "en-US" });
                }
                pairs.Add(c, locales);
            }
            return pairs;

            /*var queryc = (from p in table.AsEnumerable() select p["CompanyNo"]).Distinct();
            foreach (string c in queryc)
            {
                CompanyLocale compLoc = new CompanyLocale();
                compLoc.Company = c;
                compLoc.Locales = (from p in table.AsEnumerable()
                                   where p["CompanyNo"].ToString() == c
                                   select p["Locale"].ToString()).ToList<string>();
                if (compLoc.Locales.Count == 0)
                {
                    compLoc.Locales = new List<string>(new string[] { "en-US" });
                }
                reply.CompanyLocales.Add(compLoc);
            }

            if (reply.CompanyLocales.Count == 0)
            {
                throw new NoAuthorizedCompanyException(user.UserNo);
            }

            SessionHelper.UserId = user.UserId;
            SessionHelper.UserName = user.UserNo;

            reply.SetMessage(ReplyMsgType.None);
            return reply;*/

        }
        public void AddCompanyClaim()
        {

        }
        public void AddLocaleClaim()
        {

        }

    }
}
