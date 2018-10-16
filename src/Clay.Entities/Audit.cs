using Newtonsoft.Json;
using System;
using System.CodeDom.Compiler;

namespace Clay.WebApi
{
    [GeneratedCode("NJsonSchema", "9.11.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public class Audit
    {
        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("createdBy", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Required]
        public virtual string CreatedBy { get; set; }

        [JsonProperty("lastUpdatedBy", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public virtual string LastUpdatedBy { get; set; }

        [JsonProperty("createdAt", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("lastUpdatedAt", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime LastUpdatedAt { get; set; }
    }
}