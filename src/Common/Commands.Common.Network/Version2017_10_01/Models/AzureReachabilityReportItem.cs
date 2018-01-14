// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Internal.Network.Version2017_10_01.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Azure reachability report details for a given provider location.
    /// </summary>
    public partial class AzureReachabilityReportItem
    {
        /// <summary>
        /// Initializes a new instance of the AzureReachabilityReportItem
        /// class.
        /// </summary>
        public AzureReachabilityReportItem()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the AzureReachabilityReportItem
        /// class.
        /// </summary>
        /// <param name="provider">The Internet service provider.</param>
        /// <param name="azureLocation">The Azure region.</param>
        /// <param name="latencies">List of latency details for each of the
        /// time series.</param>
        public AzureReachabilityReportItem(string provider = default(string), string azureLocation = default(string), IList<AzureReachabilityReportLatencyInfo> latencies = default(IList<AzureReachabilityReportLatencyInfo>))
        {
            Provider = provider;
            AzureLocation = azureLocation;
            Latencies = latencies;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the Internet service provider.
        /// </summary>
        [JsonProperty(PropertyName = "provider")]
        public string Provider { get; set; }

        /// <summary>
        /// Gets or sets the Azure region.
        /// </summary>
        [JsonProperty(PropertyName = "azureLocation")]
        public string AzureLocation { get; set; }

        /// <summary>
        /// Gets or sets list of latency details for each of the time series.
        /// </summary>
        [JsonProperty(PropertyName = "latencies")]
        public IList<AzureReachabilityReportLatencyInfo> Latencies { get; set; }

    }
}
