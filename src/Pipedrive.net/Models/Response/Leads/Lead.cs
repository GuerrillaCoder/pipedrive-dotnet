using System.Collections.Generic;
using Newtonsoft.Json;
using Pipedrive.Internal;

namespace Pipedrive
{
    [JsonConverter(typeof(CustomFieldConverter))]
    public class Lead : AbstractLead, IEntityWithCustomFields
    {
        [JsonIgnore]
        public IDictionary<string, ICustomField> CustomFields { get; set; }

        public LeadUpdate ToUpdate()
        {
            return new LeadUpdate()
            {
                Title = Title,
                CustomFields = CustomFields,
                LabelIds = LabelIds,
                OrganizationId = OrganizationId,
                OwnerId = OwnerId,
                PersonId = PersonId,
                VisibleTo = VisibleTo,
                WasSeen = WasSeen,
                ExpectedCloseDate = ExpectedCloseDate
            };
        }
    }
}
