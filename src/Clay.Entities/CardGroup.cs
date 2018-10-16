using Clay.Entities;
using System.Collections.Generic;

namespace Clay.WebApi
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.11.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CardGroup : IAuditable
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Description { get; set; }

        [Newtonsoft.Json.JsonProperty("audit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Audit Audit { get; set; }

        [Newtonsoft.Json.JsonProperty("property", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public virtual Property Property { get; set; }

        /// <summary>the cards belonging to this group</summary>
        [Newtonsoft.Json.JsonProperty("cards", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public virtual ICollection<Card> Cards { get; } = new List<Card>();
    }
}