using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TokenJwt.ApiClient.Attributes
{
    public class UrlNameAttribute : Attribute
    {
        public string Name { get; set; }

        public UrlNameAttribute(string name)
        {
            Name = name;
        }
    }

    public static class UrlNameHelper
    {
        public static Dictionary<string, string> GetRequestParameter(object obj)
        {
            var result = new Dictionary<string, string>();
            foreach (var prop in obj.GetType().GetProperties())
            {
                var attrs = prop.GetCustomAttributes(true);
                var attr = (UrlNameAttribute)attrs.FirstOrDefault(x => x is UrlNameAttribute);
                if (attr != null)
                {
                    var tmp = string.Empty;
                    var propObj = prop.GetValue(obj);
                    if (propObj != null)
                    {
                        if (propObj.GetType() == typeof(double))
                        {
                            tmp = propObj.ToString();
                            tmp = tmp.Replace(',', '.');
                        }
                        else
                        {
                            tmp = propObj.ToString();
                        }
                        result.Add(attr.Name, tmp);
                    }
                }
            }
            return result;
        }
    }
}
