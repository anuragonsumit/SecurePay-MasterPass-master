
param (
	[string]$DODOJson,
	[string]$DODOContainer
)

#region DODO import
Write-Host "Importing DODO version ..."
$dodoExe = "$PSScriptRoot\dodo.exe"
& $dodoExe --export
Import-Module  "$PSScriptRoot\DODO\dodo.psd1"
#endregion

#Turn JSON string into Object for DODO !
$developmentJson = $DODOJson | ConvertFrom-Json

Publish-DODOIISWebApplication -ConfigurationJSONObject $developmentJson -ContainerName $DODOContainer

Write-Host "Setting IP restrictions..."

& "C:\Windows\system32\inetsrv\appcmd.exe" clear config "Default Web Site/SecurePay.Masterpass" /delete:true /section:system.webServer/security/ipSecurity /commit:apphost
& "C:\Windows\system32\inetsrv\appcmd.exe" set config "Default Web Site/SecurePay.Masterpass" -section:system.webServer/security/ipSecurity /allowUnlisted:false /commit:apphost
& "C:\Windows\system32\inetsrv\appcmd.exe" set config "Default Web Site/SecurePay.Masterpass" -section:system.webServer/security/ipSecurity /denyAction:NotFound /commit:apphost
& "C:\Windows\system32\inetsrv\appcmd.exe" set config "Default Web Site/SecurePay.Masterpass" -section:system.webServer/security/ipSecurity /enableProxyMode:true /commit:apphost

#Local
& "C:\Windows\system32\inetsrv\appcmd.exe" set config "Default Web Site/SecurePay.Masterpass" -section:system.webServer/security/ipSecurity /+"[ipAddress='127.0.0.1',allowed='True']" /commit:apphost

#Performance Test servers
& "C:\Windows\system32\inetsrv\appcmd.exe" set config "Default Web Site/SecurePay.Masterpass" -section:system.webServer/security/ipSecurity /+"[ipAddress='104.215.193.241',allowed='True']" /commit:apphost

#Melbourne network
& "C:\Windows\system32\inetsrv\appcmd.exe" set config "Default Web Site/SecurePay.Masterpass" -section:system.webServer/security/ipSecurity /+"[ipAddress='125.7.50.82',allowed='True']" /commit:apphost

#PCI Internal VNET
& "C:\Windows\system32\inetsrv\appcmd.exe" set config "Default Web Site/SecurePay.Masterpass" -section:system.webServer/security/ipSecurity /+"[ipAddress='192.168.0.0',subnetMask='255.255.0.0',allowed='True']" /commit:apphost

#Macquarie Public IP Prod-UAT
& "C:\Windows\system32\inetsrv\appcmd.exe" set config "Default Web Site/SecurePay.Masterpass" -section:system.webServer/security/ipSecurity /+"[ipAddress='210.193.137.62',allowed='True']" /commit:apphost
& "C:\Windows\system32\inetsrv\appcmd.exe" set config "Default Web Site/SecurePay.Masterpass" -section:system.webServer/security/ipSecurity /+"[ipAddress='124.47.169.62',allowed='True']" /commit:apphost

#TSA IC1
& "C:\Windows\system32\inetsrv\appcmd.exe" set config "Default Web Site/SecurePay.Masterpass" -section:system.webServer/security/ipSecurity /+"[ipAddress='210.193.137.50',allowed='True']" /commit:apphost
& "C:\Windows\system32\inetsrv\appcmd.exe" set config "Default Web Site/SecurePay.Masterpass" -section:system.webServer/security/ipSecurity /+"[ipAddress='210.193.137.55',allowed='True']" /commit:apphost
& "C:\Windows\system32\inetsrv\appcmd.exe" set config "Default Web Site/SecurePay.Masterpass" -section:system.webServer/security/ipSecurity /+"[ipAddress='210.193.137.56',allowed='True']" /commit:apphost
& "C:\Windows\system32\inetsrv\appcmd.exe" set config "Default Web Site/SecurePay.Masterpass" -section:system.webServer/security/ipSecurity /+"[ipAddress='210.193.137.57',allowed='True']" /commit:apphost
& "C:\Windows\system32\inetsrv\appcmd.exe" set config "Default Web Site/SecurePay.Masterpass" -section:system.webServer/security/ipSecurity /+"[ipAddress='210.193.137.58',allowed='True']" /commit:apphost
& "C:\Windows\system32\inetsrv\appcmd.exe" set config "Default Web Site/SecurePay.Masterpass" -section:system.webServer/security/ipSecurity /+"[ipAddress='210.193.137.59',allowed='True']" /commit:apphost

#TSA IC2
& "C:\Windows\system32\inetsrv\appcmd.exe" set config "Default Web Site/SecurePay.Masterpass" -section:system.webServer/security/ipSecurity /+"[ipAddress='124.47.169.50',allowed='True']" /commit:apphost
& "C:\Windows\system32\inetsrv\appcmd.exe" set config "Default Web Site/SecurePay.Masterpass" -section:system.webServer/security/ipSecurity /+"[ipAddress='124.47.169.55',allowed='True']" /commit:apphost
& "C:\Windows\system32\inetsrv\appcmd.exe" set config "Default Web Site/SecurePay.Masterpass" -section:system.webServer/security/ipSecurity /+"[ipAddress='124.47.169.56',allowed='True']" /commit:apphost
& "C:\Windows\system32\inetsrv\appcmd.exe" set config "Default Web Site/SecurePay.Masterpass" -section:system.webServer/security/ipSecurity /+"[ipAddress='124.47.169.57',allowed='True']" /commit:apphost
& "C:\Windows\system32\inetsrv\appcmd.exe" set config "Default Web Site/SecurePay.Masterpass" -section:system.webServer/security/ipSecurity /+"[ipAddress='124.47.169.58',allowed='True']" /commit:apphost
& "C:\Windows\system32\inetsrv\appcmd.exe" set config "Default Web Site/SecurePay.Masterpass" -section:system.webServer/security/ipSecurity /+"[ipAddress='124.47.169.59',allowed='True']" /commit:apphost

Write-Host "Setting IP Whitelisting from Octopus..."
if($WhiteListings -ne "" -and $WhiteListings -ne $null)
{
	foreach($whiteListing in $WhiteListings)
	{
		& "C:\Windows\system32\inetsrv\appcmd.exe" set config "Default Web Site/SecurePay.Masterpass" -section:system.webServer/security/ipSecurity $whiteListing.IPSecurity /commit:apphost
	}
}