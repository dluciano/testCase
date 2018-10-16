using Clay.Entities;
using System.Collections.Generic;

namespace Clay.WebApi
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.11.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CardGroupLock : IAuditable
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("audit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Audit Audit { get; set; }

        [Newtonsoft.Json.JsonProperty("lock", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public virtual ICollection<Lock> Locks { get; } = new List<Lock>();

        [Newtonsoft.Json.JsonProperty("cardGroup", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public virtual CardGroup CardGroup { get; set; }
    }
}