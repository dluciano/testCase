using System.Collections.Generic;

namespace Clay.WebApi
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.11.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Card
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("identitfier", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Identitfier { get; set; }

        [Newtonsoft.Json.JsonProperty("audit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Audit Audit { get; set; }

        /// <summary>the locks that can be opened with this card</summary>
        [Newtonsoft.Json.JsonProperty("locks", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public virtual ICollection<Lock> Locks { get; } = new List<Lock>();

        /// <summary>the properties that this card belongs to</summary>
        [Newtonsoft.Json.JsonProperty("properties", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public virtual ICollection<Property> Properties { get; } = new List<Property>();

        /// <summary>the groups that this card belong to</summary>
        [Newtonsoft.Json.JsonProperty("groups", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public virtual ICollection<CardGroup> Groups { get; } = new List<CardGroup>();

        //[Newtonsoft.Json.JsonProperty("owner", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        //public virtual CardOwner Owner { get; set; }

        /// <summary>the owners of the card</summary>
        [Newtonsoft.Json.JsonProperty("owners", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public virtual ICollection<CardOwner> Owners { get; } = new List<CardOwner>();
    }
}