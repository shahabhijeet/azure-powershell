// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Internal.Network.Version2017_10_01
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for InboundNatRulesOperations.
    /// </summary>
    public static partial class InboundNatRulesOperationsExtensions
    {
            /// <summary>
            /// Gets all the inbound nat rules in a load balancer.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='loadBalancerName'>
            /// The name of the load balancer.
            /// </param>
            public static IPage<InboundNatRule> List(this IInboundNatRulesOperations operations, string resourceGroupName, string loadBalancerName)
            {
                return operations.ListAsync(resourceGroupName, loadBalancerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets all the inbound nat rules in a load balancer.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='loadBalancerName'>
            /// The name of the load balancer.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<InboundNatRule>> ListAsync(this IInboundNatRulesOperations operations, string resourceGroupName, string loadBalancerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListWithHttpMessagesAsync(resourceGroupName, loadBalancerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes the specified load balancer inbound nat rule.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='loadBalancerName'>
            /// The name of the load balancer.
            /// </param>
            /// <param name='inboundNatRuleName'>
            /// The name of the inbound nat rule.
            /// </param>
            public static void Delete(this IInboundNatRulesOperations operations, string resourceGroupName, string loadBalancerName, string inboundNatRuleName)
            {
                operations.DeleteAsync(resourceGroupName, loadBalancerName, inboundNatRuleName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes the specified load balancer inbound nat rule.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='loadBalancerName'>
            /// The name of the load balancer.
            /// </param>
            /// <param name='inboundNatRuleName'>
            /// The name of the inbound nat rule.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAsync(this IInboundNatRulesOperations operations, string resourceGroupName, string loadBalancerName, string inboundNatRuleName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.DeleteWithHttpMessagesAsync(resourceGroupName, loadBalancerName, inboundNatRuleName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Gets the specified load balancer inbound nat rule.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='loadBalancerName'>
            /// The name of the load balancer.
            /// </param>
            /// <param name='inboundNatRuleName'>
            /// The name of the inbound nat rule.
            /// </param>
            /// <param name='expand'>
            /// Expands referenced resources.
            /// </param>
            public static InboundNatRule Get(this IInboundNatRulesOperations operations, string resourceGroupName, string loadBalancerName, string inboundNatRuleName, string expand = default(string))
            {
                return operations.GetAsync(resourceGroupName, loadBalancerName, inboundNatRuleName, expand).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets the specified load balancer inbound nat rule.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='loadBalancerName'>
            /// The name of the load balancer.
            /// </param>
            /// <param name='inboundNatRuleName'>
            /// The name of the inbound nat rule.
            /// </param>
            /// <param name='expand'>
            /// Expands referenced resources.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<InboundNatRule> GetAsync(this IInboundNatRulesOperations operations, string resourceGroupName, string loadBalancerName, string inboundNatRuleName, string expand = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, loadBalancerName, inboundNatRuleName, expand, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates or updates a load balancer inbound nat rule.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='loadBalancerName'>
            /// The name of the load balancer.
            /// </param>
            /// <param name='inboundNatRuleName'>
            /// The name of the inbound nat rule.
            /// </param>
            /// <param name='inboundNatRuleParameters'>
            /// Parameters supplied to the create or update inbound nat rule operation.
            /// </param>
            public static InboundNatRule CreateOrUpdate(this IInboundNatRulesOperations operations, string resourceGroupName, string loadBalancerName, string inboundNatRuleName, InboundNatRule inboundNatRuleParameters)
            {
                return operations.CreateOrUpdateAsync(resourceGroupName, loadBalancerName, inboundNatRuleName, inboundNatRuleParameters).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or updates a load balancer inbound nat rule.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='loadBalancerName'>
            /// The name of the load balancer.
            /// </param>
            /// <param name='inboundNatRuleName'>
            /// The name of the inbound nat rule.
            /// </param>
            /// <param name='inboundNatRuleParameters'>
            /// Parameters supplied to the create or update inbound nat rule operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<InboundNatRule> CreateOrUpdateAsync(this IInboundNatRulesOperations operations, string resourceGroupName, string loadBalancerName, string inboundNatRuleName, InboundNatRule inboundNatRuleParameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, loadBalancerName, inboundNatRuleName, inboundNatRuleParameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes the specified load balancer inbound nat rule.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='loadBalancerName'>
            /// The name of the load balancer.
            /// </param>
            /// <param name='inboundNatRuleName'>
            /// The name of the inbound nat rule.
            /// </param>
            public static void BeginDelete(this IInboundNatRulesOperations operations, string resourceGroupName, string loadBalancerName, string inboundNatRuleName)
            {
                operations.BeginDeleteAsync(resourceGroupName, loadBalancerName, inboundNatRuleName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes the specified load balancer inbound nat rule.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='loadBalancerName'>
            /// The name of the load balancer.
            /// </param>
            /// <param name='inboundNatRuleName'>
            /// The name of the inbound nat rule.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task BeginDeleteAsync(this IInboundNatRulesOperations operations, string resourceGroupName, string loadBalancerName, string inboundNatRuleName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.BeginDeleteWithHttpMessagesAsync(resourceGroupName, loadBalancerName, inboundNatRuleName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Creates or updates a load balancer inbound nat rule.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='loadBalancerName'>
            /// The name of the load balancer.
            /// </param>
            /// <param name='inboundNatRuleName'>
            /// The name of the inbound nat rule.
            /// </param>
            /// <param name='inboundNatRuleParameters'>
            /// Parameters supplied to the create or update inbound nat rule operation.
            /// </param>
            public static InboundNatRule BeginCreateOrUpdate(this IInboundNatRulesOperations operations, string resourceGroupName, string loadBalancerName, string inboundNatRuleName, InboundNatRule inboundNatRuleParameters)
            {
                return operations.BeginCreateOrUpdateAsync(resourceGroupName, loadBalancerName, inboundNatRuleName, inboundNatRuleParameters).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or updates a load balancer inbound nat rule.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='loadBalancerName'>
            /// The name of the load balancer.
            /// </param>
            /// <param name='inboundNatRuleName'>
            /// The name of the inbound nat rule.
            /// </param>
            /// <param name='inboundNatRuleParameters'>
            /// Parameters supplied to the create or update inbound nat rule operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<InboundNatRule> BeginCreateOrUpdateAsync(this IInboundNatRulesOperations operations, string resourceGroupName, string loadBalancerName, string inboundNatRuleName, InboundNatRule inboundNatRuleParameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginCreateOrUpdateWithHttpMessagesAsync(resourceGroupName, loadBalancerName, inboundNatRuleName, inboundNatRuleParameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets all the inbound nat rules in a load balancer.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<InboundNatRule> ListNext(this IInboundNatRulesOperations operations, string nextPageLink)
            {
                return operations.ListNextAsync(nextPageLink).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets all the inbound nat rules in a load balancer.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<InboundNatRule>> ListNextAsync(this IInboundNatRulesOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
