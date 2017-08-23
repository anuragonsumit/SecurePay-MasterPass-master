
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

#get the web app name for the setparam file path!
$webappJson = $developmentJson.Containers | where { $_.Type -eq "AzureWebApp" -and $_.Name -eq $DODOContainer }
$webAppName = $webappJson[0].Attributes.Properties.Name

$PackagePath = $("$PSScriptRoot\WebApp\SecurePay.MasterPass.zip") 
$SetParametersPath = $("$PSScriptRoot\Configuration\$webAppName-SetParameters.xml")

#Log me in!
Login-DODOAzure -SubscriptionId $AzureSubscriptionID -TenantId $AzureTenantID -Credential $AzureCredential

#deploy!
Publish-DODOAzureWebApp -ConfigurationJSONObject $developmentJson -ContainerName $DODOContainer -PackagePath $PackagePath -SetParametersPath $SetParametersPath