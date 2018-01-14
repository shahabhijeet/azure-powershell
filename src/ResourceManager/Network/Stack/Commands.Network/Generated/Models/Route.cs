// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.13.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Network.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Route resource
    /// </summary>
    public partial class Route : SubResource
    {
        /// <summary>
        /// Initializes a new instance of the Route class.
        /// </summary>
        public Route() { }

        /// <summary>
        /// Initializes a new instance of the Route class.
        /// </summary>
        public Route(string nextHopType, string name = default(string), string etag = default(string), string addressPrefix = default(string), string nextHopIpAddress = default(string), string provisioningState = default(string))
        {
            Name = name;
            Etag = etag;
            AddressPrefix = addressPrefix;
            NextHopType = nextHopType;
            NextHopIpAddress = nextHopIpAddress;
            ProvisioningState = provisioningState;
        }

        /// <summary>
        /// Gets name of the resource that is unique within a resource group.
        /// This name can be used to access the resource
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// A unique read-only string that changes whenever the resource is
        /// updated
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; set; }

        /// <summary>
        /// Gets or sets the destination CIDR to which the route applies.
        /// </summary>
        [JsonProperty(PropertyName = "properties.addressPrefix")]
        public string AddressPrefix { get; set; }

        /// <summary>
        /// Gets or sets the type of Azure hop the packet should be sent to.
        /// Possible values for this property include:
        /// 'VirtualNetworkGateway', 'VnetLocal', 'Internet',
        /// 'VirtualAppliance', 'None'.
        /// </summary>
        [JsonProperty(PropertyName = "properties.nextHopType")]
        public string NextHopType { get; set; }

        /// <summary>
        /// Gets or sets the IP address packets should be forwarded to. Next
        /// hop values are only allowed in routes where the next hop type is
        /// VirtualAppliance.
        /// </summary>
        [JsonProperty(PropertyName = "properties.nextHopIpAddress")]
        public string NextHopIpAddress { get; set; }

        /// <summary>
        /// Gets or sets Provisioning state of the resource
        /// Updating/Deleting/Failed
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (NextHopType == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "NextHopType");
            }
        }
    }
}
