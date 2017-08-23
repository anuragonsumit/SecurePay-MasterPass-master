
#Octopus needs variable: LoadTestDeploymentPath set. Sample value looks like -> C:\DevOps\LoadTests\SecurePay.MasterPass\#{Octopus.Release.Number}

function Set-LoadTest-Path ($path){
	Write-Host "Setting environment variable for the load test location path:"$path
	[Environment]::SetEnvironmentVariable("LoadTest.SecurePayMasterPass.Location", $path, "Machine") #HAS TO BE Machine!
}

Set-LoadTest-Path $LoadTestDeploymentPath