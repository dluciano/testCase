using Clay.Entities;
using Newtonsoft.Json;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clay.WebApi
{
    [GeneratedCode("NJsonSchema", "9.11.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public class Card : IAuditable
    {
        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("identitfier", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Identitfier { get; set; }

        [JsonProperty("audit", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Audit Audit { get; set; }

        /// <summary>the locks that can be opened with this card</summary>
        [JsonProperty("locks", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public virtual ICollection<LockCard> Locks { get; } = new List<LockCard>();

        /// <summary>the properties that this card belongs to</summary>
        [JsonProperty("properties", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public virtual ICollection<Property> Properties { get; } = new List<Property>();

        /// <summary>the groups that this card belong to</summary>
        [JsonProperty("groups", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public virtual ICollection<CardGroup> Groups { get; } = new List<CardGroup>();

        [JsonProperty("personData", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public virtual PersonData PersonData { get; set; }
    }
}