using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicDemo.Options
{
    public class EmailSettings
    {
        public bool EnableSystems { get; set; }

        public double EmailTimeOutInSeconds { get; set; }

        public List<string> EmailServers { get; set; }

        public override string ToString()
        {
            var servers = new StringBuilder();
            EmailServers.ForEach(es=>servers.Append($"{es},"));
            return $"Enable: {EnableSystems}, TimeOut: {EmailTimeOutInSeconds}, " +
                   $"Servers : {servers}";
        }
    }
}