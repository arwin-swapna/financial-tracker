using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Api.Models
{
    [JsonObject(NamingStrategyType = typeof(DefaultNamingStrategy))]
    public class Account
    {
        [Key]
        public string Id { get; set; }
        public string EnrollmentId { get; set; }
        // [JsonIgnore]
        // public Links Links { get; set; }
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
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }

    }

    // [JsonObject(NamingStrategyType = typeof(DefaultNamingStrategy))]
    // public class Links
    // {
    //     public string Balances { get; set; }
    //     public string Self { get; set; }
    //     public string Transactions { get; set; }
    // }
}