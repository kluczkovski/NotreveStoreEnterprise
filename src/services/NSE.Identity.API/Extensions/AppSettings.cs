using System;
namespace NSE.Identity.API.Extensions
{
    public class AppSettings
    {
        public string Secret { get; set; }

        public int ExpiredHours { get; set; }

        public string Emissor { get; set; }

        public string ValidIn { get; set; }

        public AppSettings()
        {
        }
    }
}
