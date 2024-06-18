using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace api.Models
{
    [JsonObject(NamingStrategyType = typeof(DefaultNamingStrategy))]
    public class Account
    {
        [Key]
        public string Id { get; set; }
        public string EnrollmentId { get; set; }
        public string InstitutionName { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Subtype { get; set; }
        public string Currency { get; set; }
        public string LastFour { get; set; }
        public string Status { get; set; }
        public decimal Balance { get; set; } = 0.00m;
        public decimal Available { get; set; } = 0.00m;
        public virtual AccountGroup AccountGroup { get; set; }
    }
}