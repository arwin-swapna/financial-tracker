using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace api.DTOs
{
    [JsonObject(NamingStrategyType = typeof(DefaultNamingStrategy))]
    public class AccountDto
    {
        public string Id { get; set; }
        public string EnrollmentId { get; set; }
        public string InstitutionId { get; set; }
        public Institution Institution { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Subtype { get; set; }
        public string Currency { get; set; }
        public string LastFour { get; set; }
        public string Status { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(DefaultNamingStrategy))]
    public class Institution
    {
        public string Id { get; set; }
        public string Name { get; set; }

    }
    
}