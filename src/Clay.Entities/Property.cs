using Clay.Entities;
using Newtonsoft.Json;
using System.CodeDom.Compiler;

namespace Clay.WebApi
{
    [GeneratedCode("NJsonSchema", "9.11.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Property : IAuditable
    {
        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Name { get; set; }

        [JsonProperty("audit", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Audit Audit { get; set; }

        [JsonProperty("locks", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public virtual System.Collections.Generic.List<Lock> Locks { get; } = new System.Collections.Generic.List<Lock>();

        public string OwnerUsername { get; set; }
    }
}