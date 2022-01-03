﻿using Newtonsoft.Json;

namespace Pipedrive.Models.Request.LeadLabel
{
    public class NewLeadLabel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("color")]
        public string Color { get; set; }
    }
}
