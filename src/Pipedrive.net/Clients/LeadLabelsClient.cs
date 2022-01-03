﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Pipedrive.Helpers;
using Pipedrive.Models.Request.LeadLabel;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Lead Label API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/LeadLabels">Lead Label API documentation</a> for more information.
    public class LeadLabelsClient : ApiClient, ILeadLabelsClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeadLabelsClient"/> class.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public LeadLabelsClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public Task<IReadOnlyList<LeadLabel>> GetAll()
        {
            return ApiConnection.GetAll<LeadLabel>(ApiUrls.LeadLabels());
        }
        
        public Task<LeadLabel> Create(NewLeadLabel data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Post<LeadLabel>(ApiUrls.LeadLabels(), data);
        }
    }
}
