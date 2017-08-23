#check if the context is Octopus or ISE
$isOctopus = Test-Path variable:global:OctopusParameters

#Set erroractionpreference back to default since Octopus sets it to Stop
$ErrorActionPreference = "Continue"
if(!$isOctopus){
    Write-Host "Context: Powershell script ISE"
    
	#These below variables need to be defined in Octopus for the script to run in Octo successfully
	$OctopusInternalFeedApiKey = "API KEY"
	$OctopusInternalFeedSource = "URI to NuGet feed"
	$DeploymentAction = ""
	$OctopusDODOJson = ""
	$AzureUsername = ""
	$AzurePassword = ""
	$AzureSubscriptionID = ""
	$AzureTenantID = ""

}else{
    Write-Host "Context: Octopus" #Octopus will fill out the parameters! :)
	$OctopusDODOJson = Get-Environment-JSON #Octopus has the json stored as script module
}


function PushToNuGet($packagePath){
    
    $arguments = "push $packagePath -ApiKey $OctopusInternalFeedApiKey -Source $OctopusInternalFeedSource"
    $nuget = "$PSScriptRoot\Tools\NuGet\NuGet.exe"

    $psi = New-object System.Diagnostics.ProcessStartInfo 
    $psi.CreateNoWindow = $true 
    $psi.UseShellExecute = $false 
    $psi.RedirectStandardOutput = $true 
    $psi.RedirectStandardError = $true 
    $psi.FileName = $nuget
    $psi.Arguments = $arguments
    $process = New-Object System.Diagnostics.Process 
    $process.StartInfo = $psi 
    $process.Start() | Out-Null
    $output = $process.StandardOutput.ReadToEnd() 
    $stderr = $process.StandardError.ReadToEnd()
    $process.WaitForExit()
    $output
    $stderr
    if($process.ExitCode -ne 0 -and $stderr.Contains("(400) Bad Request..")){
	    Write-Host "Detected NuGet push Bad Request, package already exists in repository"
    }
    elseif($process.ExitCode -eq 0){
		Write-Host "Packages pushed to internal secure store!"
    }
	else{
		throw "non zero exit code detected, see logs above..."
	}
}

$action = $DeploymentAction

Write-Host "Deployment Action is $DeploymentAction"
if($action -eq "PullPackages")
{
	Write-Host "This is a pull request to pull packages from external NuGet repository into Octopus server internal repository"
    
    $path = $OctopusParameters['Octopus.Tentacle.CurrentDeployment.PackageFilePath']

    Write-Host "Packages were downloaded to $path ...pushing to internal secure store..."
	PushToNuGet $path
}

if($action -eq "DeployAzureWebApp")
{
	Write-Host "Performing deployment to Azure Web App..."
	$p = ConvertTo-SecureString -String $AzurePassword -AsPlainText -Force
	$credential = new-object -typename System.Management.Automation.PSCredential -argumentlist $AzureUsername,$p
	.\Deploy.WebApp.ps1 -DODOJson $OctopusDODOJson -DODOContainer "Payment MasterPass WebApp" -AzureCredential $credential -AzureSubscriptionID $AzureSubscriptionID -AzureTenantID $AzureTenantID	
	
	Write-Host "Temporarily swap as well..."
	.\Swap.WebApp.ps1 -DODOJson $OctopusDODOJson -DODOContainer "Payment MasterPass WebApp" -AzureCredential $credential -AzureSubscriptionID $AzureSubscriptionID -AzureTenantID $AzureTenantID
	
}
<#
if($action -eq "SwapAzureWebApp")
{
	$p = ConvertTo-SecureString -String $AzurePassword -AsPlainText -Force
	$credential = new-object -typename System.Management.Automation.PSCredential -argumentlist $AzureUsername,$p
	Write-Host "Performing Swap Azure Web App..."
	.\Swap.WebApp.ps1 -DODOJson $OctopusDODOJson -DODOContainer "Payment MasterPass WebApp" -AzureCredential $credential -AzureSubscriptionID $AzureSubscriptionID -AzureTenantID $AzureTenantID	
}
#>

if($action -eq "DeployAzureVM")
{
	Write-Host "Performing deployment to Azure VM..."
	 
    #check and provision the site
    .\Deploy.WebVM.ps1 -DODOJson $OctopusDODOJson -DODOContainer $DODOContainer
}

if($action -eq "SwapAzureVM")
{
    
}
    