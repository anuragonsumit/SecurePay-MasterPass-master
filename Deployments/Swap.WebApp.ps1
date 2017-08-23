
param (
	[string]$DODOJson,
	[string]$DODOContainer,
	[PSCredential]$AzureCredential,
	[string]$AzureSubscriptionID,
	[string]$AzureTenantID
)

#region DODO import
$module = Get-Module dodo
$moduleVersion = "2.0.3"
if($module -eq $null)
{
    Write-Host "DODO is not imported"

}else
{
    Write-Host "DODO is imported, removing for reimport..."
    Remove-Module dodo
    Write-Host "DODO removed"
}

Write-Host "Importing DODO version $moduleVersion ..."
$env:PSModulePath = [System.Environment]::GetEnvironmentVariable("PSModulePath","Machine")
Import-Module -Name dodo -RequiredVersion $moduleVersion
Write-Host "DODO version : $moduleVersion is now applied"
#endregion

#Turn JSON string into Object for DODO !
$developmentJson = $DODOJson | ConvertFrom-Json

Login-DODOAzure -SubscriptionId $AzureSubscriptionID -TenantId $AzureTenantID -Credential $AzureCredential

Switch-DODOAzureWebApp -ConfigurationJSONObject $developmentJson -ContainerName $DODOContainer