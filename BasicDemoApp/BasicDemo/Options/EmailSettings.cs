using System.Collections.Generic;
using System.Text;

namespace BasicDemo.Options
{
    public class AdminInformation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    public class EmailSettings
    {
        public bool EnableSystems { get; set; }

        public double EmailTimeOutInSeconds { get; set; }

        public List<string> EmailServers { get; set; }

        public AdminInformation AdminInformation { get; set; }
        
        public override string ToString()
        {
            var servers = new StringBuilder();
            EmailServers.ForEach(es=>servers.Append($"{es},"));
            
            return $"Enable: {EnableSystems}, TimeOut: {EmailTimeOutInSeconds}, " +
                   $"Servers : {servers}" +
                   $"\n" +
                   $"AdminInformation: {AdminInformation.FirstName}, {AdminInformation.LastName}";
        }
    }
}