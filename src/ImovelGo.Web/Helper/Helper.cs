using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ImovelGo.Web.Helper
{
    public static class Helper
    {
        public static string GetMonthName(DateTime date)
        {
            return date.ToString("MMMM", CultureInfo.CreateSpecificCulture("pt-BR"));
        }

        public static string ToQueryString(this KeyValuePair<string, string> obj)
        {
            return obj.Key + "=" + HttpUtility.UrlEncode(obj.Value);
        }

        public static string GetValue(Uri myUri, string value)
        {
            string desiredValue = String.Empty;
            foreach (string item in myUri.Query.Split('&'))
            {
                string[] parts = item.Replace("?", "").Replace("amp;", "").Split('=');
                if (parts[0] == value)
                {
                    desiredValue = parts[1];
                    break;
                }
            }

            return desiredValue;
        }

        public static string GetQueryString(object obj)
        {
            var result = new List<string>();
            var props = obj.GetType().GetProperties().Where(p => p.GetValue(obj, null) != null);
            foreach (var p in props)
            {
                var value = p.GetValue(obj, null);
                var enumerable = value as ICollection;
                if (enumerable != null)
                {
                    result.AddRange(from object v in enumerable select string.Format("{0}={1}", p.Name, HttpUtility.UrlEncode(v.ToString())));
                }
                else
                {
                    result.Add(string.Format("{0}={1}", p.Name, HttpUtility.UrlEncode(value.ToString())));
                }
            }

            return string.Join("&", result.ToArray());
        }
    }
}
