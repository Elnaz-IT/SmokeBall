using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeBall.Helpers
{
    public class ConfigurationSettings : BaseConfiguration
    {
        
        public static int MaxSearchResultItems
        {
            get {
                var maxSearchResultItems = Environment.GetEnvironmentVariable("MaxSearchResultItems");

                if (!string.IsNullOrEmpty(maxSearchResultItems))
                    return int.Parse(maxSearchResultItems);

                return (int)GetAppSetting(typeof(int), "MaxSearchResultItems"); 

            }
        }


        public static string GoogleBaseURL
        {
            get
            {
                var googleBaseURL = Environment.GetEnvironmentVariable("GoogleBaseURL");

                if (!string.IsNullOrEmpty(googleBaseURL))
                    return googleBaseURL;

                return (string)GetAppSetting(typeof(string),"GoogleBaseURL");

            }
        }

        public static string URLRegex { get => @"(http[s]?:\/\/|[a-z]*\.[a-z]{3}\.[a-z]{2})([a-z]*\.[a-z]{3})|([a-z]*\.[a-z]*\.[a-z]{3}\.[a-z]{2})|([a-z]+\.[a-z]{3})"; }

    }
}
