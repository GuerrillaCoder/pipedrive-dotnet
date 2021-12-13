using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Pipedrive
{
    public class NewLead : IEntityWithCustomFields
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("owner_id")]
        public long? OwnerId { get; set; }

        [JsonProperty("label_ids")]
        public List<string> LabelIds { get; set; }

        [JsonProperty("person_id")]
        public long? PersonId { get; set; }

        [JsonProperty("organization_id")]
        public long? OrganizationId { get; set; }

        // value is acting weird
        // [JsonProperty("value")]
        // public decimal Value { get; set; }

        [JsonProperty("expected_close_date")]
        public DateTime? ExpectedCloseDate { get; set; }

        [JsonConverter(typeof(LeadVisibilityConverter))]
        [JsonProperty("visible_to")]
        public Visibility VisibleTo { get; set; } = Visibility.shared;

        [JsonProperty("was_seen")]
        public bool WasSeen { get; set; }

        [JsonIgnore]
        public IDictionary<string, ICustomField> CustomFields { get; set; } = new Dictionary<string, ICustomField>();

        public NewLead(string title)
        {
            this.Title = title;
        }
    }
    
    
}

public class LeadVisibilityConverter : JsonConverter
{

    // public LeadVisibilityConverter()
    // {
    //
    // }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        JToken t = JToken.FromObject(((int)value).ToString());

        t.WriteTo(writer);
        // if (t.Type != JTokenType.Object)
        // {
        //     t.WriteTo(writer);
        // }
        // else
        // {
        //     JObject o = (JObject)t;
        //     IList<string> propertyNames = o.Properties().Select(p => p.Name).ToList();
        //
        //     o.AddFirst(new JProperty("Keys", new JArray(propertyNames)));
        //
        //     o.WriteTo(writer);
        // }
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
    }

    public override bool CanRead
    {
        get { return false; }
    }

    public override bool CanConvert(Type objectType)
    {
        return true;
    }
}
