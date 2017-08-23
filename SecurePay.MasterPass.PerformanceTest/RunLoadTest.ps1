
param(
    [string]$LoadTestRunSetting,	#sample:WebjetAUDEVCIWCS
    [string]$LoadTestToRun,			#sample:Webjet\Basic.loadtest 
	[string]$SiteVersion, 			#sample: R15.02.01
	[string]$LoadTestType,			#sample: SingleStack or MultiStack
	[string]$SiteDescription, 		#sample: "Webjet AU Beta"
	[string]$NotifySlack
)

#load the slack notification modules
$baseDirectory = resolve-path $PSScriptRoot

function SetRunSetting ($runSetting, $siteVersion, $testType){
	Write-Host "Setting environment variable for run setting:"$runSetting
	[Environment]::SetEnvironmentVariable("Test.UseRunSetting", $runSetting, "Process") #MUST BE PROCESS FOR LOADTEST TO PICKUP!!
	
	Write-Host "Setting environment variable for site version:"$siteVersion
	[Environment]::SetEnvironmentVariable("Test.SiteVersion", $siteVersion, "Machine")
	
	Write-Host "Setting environment variable for test type:"$testType
	[Environment]::SetEnvironmentVariable("Test.TestType", $testType, "Machine")
}

function RunMSTest ($loadTest, $testSettings){

	$baseDirectory = resolve-path $PSScriptRoot
	cd $baseDirectory
	Write-Host "Running in "$baseDirectory
	
	$MSTestExe = "C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\MSTest.exe"

	$loadTest = "$baseDirectory\$loadTest"
	$testSettings = "$baseDirectory\$testSettings"
	$resultsDir = "$baseDirectory\TestResults"

	if (!(Test-Path $resultsDir)) {
		#create results folder if it doesnt exist
		md $resultsDir 
	}

	$resultFile = [String]::Format("{0}\loadTestResult-{1}.trx",$resultsDir,[DateTime]::Now.ToString("MMddyyyyHHmmssfff"))

	#prepare to call MSTest
	$arguments = [string[]]@(
		"-testcontainer:$loadTest",
		"-resultsFile:$resultFile",
		"-testsettings:$testSettings")
		
	Write-Host $arguments

	$psi = New-object System.Diagnostics.ProcessStartInfo 
	$psi.CreateNoWindow = $true 
	$psi.UseShellExecute = $false 
	$psi.RedirectStandardOutput = $true 
	$psi.RedirectStandardError = $true 
	$psi.FileName = $MSTestExe
	$psi.Arguments = $arguments
	$process = New-Object System.Diagnostics.Process 
	$process.StartInfo = $psi 
	$process.Start() | Out-Null
	$output = $process.StandardOutput.ReadToEnd() 
	$stderr = $process.StandardError.ReadToEnd()
	$process.WaitForExit() 
	$output
	$stderr
	if($process.ExitCode -ne 0){
		throw "MSTest threw an error, check the above output log for details"
	}
}

$config = $NULL

$NotifySlack = [boolean]::Parse($NotifySlack)
if($NotifySlack -eq $true){
	."$baseDirectory\Slack-Notify.ps1"
	#initialise slack
	$config = Get-SlackHookConfig
	$notificationStarting = New-StartingNotification $SiteDescription
	$notificationSuccess = New-SuccessNotification $SiteDescription

	#notify start!
	Notify-Slack $config $notificationStarting
}

SetRunSetting -runSetting $LoadTestRunSetting -siteVersion $SiteVersion -testType $LoadTestType
RunMSTest $LoadTestToRun "Local.testsettings"

if($NotifySlack -eq $true){
	#notify complete
	Notify-Slack $config $notificationSuccess
}
