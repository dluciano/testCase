using Clay.Entities;

namespace Clay.WebApi
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.11.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class LockEvent : IAuditable
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("lock", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Required]
        public virtual Lock Lock { get; set; }

        [Newtonsoft.Json.JsonProperty("card", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public virtual Card Card { get; set; }

        [Newtonsoft.Json.JsonProperty("cardOwnerWhenEventTrigger", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public virtual CardOwner CardOwnerWhenEventTrigger { get; set; }

        [Newtonsoft.Json.JsonProperty("details", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Details { get; set; }

        /// <summary>Type of event generated</summary>
        [Newtonsoft.Json.JsonProperty("event_type", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public EventType EventType { get; set; }

        [Newtonsoft.Json.JsonProperty("audit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Audit Audit { get; set; }
    }
}