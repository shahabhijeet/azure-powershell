﻿Function Get-ActiveDirectoryApp
{
    param(
    [Parameter(Mandatory=$true, HelpMessage="Azure AD Apllication Display Name")]
    [ValidateNotNullOrEmpty()]
    [string]$ADAppDisplayName,
    
    [Parameter(Mandatory=$true, HelpMessage="Azure Subscription Id")]
    [ValidateNotNullOrEmpty()]
    [string]$SubscriptionId,
    
    [Parameter(Mandatory=$false, HelpMessage="Azure AD Apllication Display Name")]
    [string]$TenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47",

    [Parameter(Mandatory=$false, HelpMessage="True: AD App is created if does not exist")]
    [bool]$createADAppIfNotFound = $false,

    [Parameter(Mandatory=$false, HelpMessage="True: AD SPN is created if does not exist")]
    [bool]$createADSpnIfNotFound = $false
    
    )

    $displayName = $ADAppDisplayName
    $homePage = "http://www.$displayName.com"
    $identityUri = "http://$displayName"

    Select-AzureRmSubscription -SubscriptionId $SubscriptionId -TenantId $TenantId
    $azSub = Get-AzureRmSubscription -SubscriptionId $SubscriptionId

    if($azSub -ne $null)
    {
        if($azSub.SubscriptionId -ne $SubscriptionId)
        {
            throw [System.ApplicationException] "'$SubscriptionId' subscriptionId is not selected'. Exiting......"
        }
    }
    
    $azAdApp = Get-AzureRmADApplication -DisplayNameStartWith $displayName
    if($azAdApp -eq $null -and $createADAppIfNotFound -eq $true)
    {
        $azAdApp = New-AzureRmADApplication -DisplayName $displayName -HomePage $homePage -IdentifierUris $identityUri
    }

    if($azAdApp -ne $null -and $createADSpnIfNotFound -eq $true)
    {
        $adAppSpn = New-AzureRmADServicePrincipal -ApplicationId $psAutoADApp.ApplicationId
    }
    else
    {
        throw [System.ApplicationException] "Unable to create new Azure AD Applicaiton using 'New-AzureRmADApplication'. Exiting......"
    }

    Get-ADAppSpnDetails -AdApp $azAdApp -AdSpn $adAppSpn
}

[cmdletBinding]
Function Get-ADAppSpnDetails
{
    param(
        [Parameter(Mandatory=$false, HelpMessage="Azure AD Apllication")]
        [Microsoft.Azure.Commands.Resources.Models.ActiveDirectory.PSADApplication] $AdApp,

        [Parameter(Mandatory=$false, HelpMessage="Azure AD ServicePrincipal")]
        [Microsoft.Azure.Commands.Resources.Models.ActiveDirectory.PSADServicePrincipal] $AdSpn
    )

    if($AdApp -ne $null)
    {
        Write-Host "AD App Info"
        Write-Host $AdApp
    }

    if($AdSpn -ne $null)
    {
        Write-Host "AD SPN Info"
        Write-Host $AdSpn
    }
}

[cmdletBinding]
Function Get-ServicePrincipal
{
    param(
        [Parameter(Mandatory=$true, HelpMessage="Azure AD Apllication Display Name")]
        [string]$ADAppDisplayName,

        [Parameter(Mandatory=$false, HelpMessage="Please provide the role that needs to be assigned to ServicePrinciple")]
        [string]$Role,

        [Parameter(Mandatory=$false, HelpMessage="True: Spn is created if does not exist")]
        [bool]$createIfNotFound = $false
    )


}


[CmdletBinding]
Function Set-TestEnvironment
{
<#
.SYNOPSIS
This cmdlet helps you to setup Test Environment for running tests
In order to successfully run a test, you will need SubscriptionId, TenantId
This cmdlet will only prompt you for Subscription and Tenant information, rest all other parameters are optional

#>
    [CmdletBinding(DefaultParameterSetName='UserIdParamSet')]
    param(
        [Parameter(ParameterSetName='UserIdParamSet', Mandatory=$true, HelpMessage = "UserId (OrgId) you would like to use")]
        [ValidateNotNullOrEmpty()]
        [string]$UserId,

        [Parameter(ParameterSetName='UserIdParamSet', Mandatory=$true, HelpMessage = "UserId (OrgId) you would like to use")]
        [ValidateNotNullOrEmpty()]
        [string]$Password,

        [Parameter(ParameterSetName='SpnParamSet', Mandatory=$true, HelpMessage='ServicePrincipal/ClientId you would like to use')]   
        [ValidateNotNullOrEmpty()]
        [string]$ServicePrincipal,

        [Parameter(ParameterSetName='SpnParamSet', Mandatory=$true, HelpMessage='ServicePrincipal Secret/ClientId Secret you would like to use')]
        [ValidateNotNullOrEmpty()]
        [string]$ServicePrincipalSecret,

        [Parameter(ParameterSetName='SpnParamSet', Mandatory=$true)]
        [Parameter(ParameterSetName='UserIdParamSet', Mandatory=$true, HelpMessage = "SubscriptionId you would like to use")]
        [ValidateNotNullOrEmpty()]
        [string]$SubscriptionId,

        [Parameter(ParameterSetName='SpnParamSet', Mandatory=$true, HelpMessage='AADTenant/TenantId you would like to use')]
        [ValidateNotNullOrEmpty()]
        [string]$TenantId,

        [ValidateSet("Playback", "Record", "None")]
        [string]$RecordMode='Playback',

        [ValidateSet("Prod", "Dogfood", "Current", "Next")]
        [string]$TargetEnvironment='Prod'
    )

    [string]$uris="https://management.azure.com/"

    $formattedConnStr = [string]::Format("SubscriptionId={0};HttpRecorderMode={1};Environment={2}", $SubscriptionId, $RecordMode, $TargetEnvironment)

    if([string]::IsNullOrEmpty($UserId) -eq $false)
    {
        $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";UserId={0}"), $UserId)
    }

    if([string]::IsNullOrEmpty($Password) -eq $false)
    {
        $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";Password={0}"), $Password)
    }

    if([string]::IsNullOrEmpty($TenantId) -eq $false)
    {
        $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";AADTenant={0}"), $TenantId)
    }

    if([string]::IsNullOrEmpty($ServicePrincipal) -eq $false)
    {
        $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";ServicePrincipal={0}"), $ServicePrincipal)
    }

    if([string]::IsNullOrEmpty($ServicePrincipalSecret) -eq $false)
    {
        $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";ServicePrincipalSecret={0}"), $ServicePrincipalSecret)
    }
    
    $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";BaseUri={0}"), $uris)

    Write-Host "Below connection string is ready to be set"
    Print-ConnectionString $UserId $Password $SubscriptionId $TenantId $ServicePrincipal $ServicePrincipalSecret $RecordMode $TargetEnvironment $uris

    #Set connection string to Environment variable
    $env:TEST_CSM_ORGID_AUTHENTICATION=$formattedConnStr
    Write-Host ""

    # Retrieve the environment variable
    Write-Host ""
    Write-Host "Below connection string was set. Start Visual Studio by typing devenv" -ForegroundColor Green
    [Environment]::GetEnvironmentVariable($envVariableName)
    Write-Host ""
    
    Write-Host "If your needs demand you to set connection string differently, for all the supported Key/Value pairs in connection string"
    Write-Host "Please visit https://github.com/Azure/azure-powershell/blob/dev/documentation/Using-Azure-TestFramework.md" -ForegroundColor Yellow
}

Function Print-ConnectionString([string]$uid, [string]$pwd, [string]$subId, [string]$aadTenant, [string]$spn, [string]$spnSecret, [string]$recordMode, [string]$targetEnvironment, [string]$uris)
{

    if([string]::IsNullOrEmpty($uid) -eq $false)
    {
        Write-Host "UserId=" -ForegroundColor Green -NoNewline
        Write-Host $uid";" -NoNewline 
    }

    if([string]::IsNullOrEmpty($pwd) -eq $false)
    {
        Write-Host "Password=" -ForegroundColor Green -NoNewline
        Write-Host $pwd";" -NoNewline 
    }

    if([string]::IsNullOrEmpty($subId) -eq $false)
    {
        Write-Host "SubscriptionId=" -ForegroundColor Green -NoNewline
        Write-Host $subId";" -NoNewline 
    }

    if([string]::IsNullOrEmpty($aadTenant) -eq $false)
    {
        Write-Host "AADTenant=" -ForegroundColor Green -NoNewline
        Write-Host $aadTenant";" -NoNewline
    }

    if([string]::IsNullOrEmpty($spn) -eq $false)
    {
        Write-Host "ServicePrincipal=" -ForegroundColor Green -NoNewline
        Write-Host $spn";" -NoNewline
    }

    if([string]::IsNullOrEmpty($spnSecret) -eq $false)
    {
        Write-Host "ServicePrincipalSecret=" -ForegroundColor Green -NoNewline
        Write-Host $spnSecret";" -NoNewline
    }

    if([string]::IsNullOrEmpty($recordMode) -eq $false)
    {
        Write-Host "HttpRecorderMode=" -ForegroundColor Green -NoNewline
        Write-Host $recordMode";" -NoNewline
    }

    if([string]::IsNullOrEmpty($targetEnvironment) -eq $false)
    {
        Write-Host "Environment=" -ForegroundColor Green -NoNewline
        Write-Host $targetEnvironment";" -NoNewline
    }

    if([string]::IsNullOrEmpty($uris) -eq $false)
    {
        Write-Host "BaseUri=" -ForegroundColor Green -NoNewline
        Write-Host $uris -NoNewline
    }

    Write-Host ""
}





export-modulemember -Function Set-TestEnvironment
export-modulemember -Function Create-Spn