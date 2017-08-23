
Framework "4.6.1"


properties {
    $baseDir = resolve-path $PSScriptRoot
	$baseParent = "$((Get-Item $baseDir).Parent.FullName)"
	$buildConfiguration = 'Release'
    $buildPlatform = 'Any CPU'
    $buildRevision = ($env:build_revision, '0' -ne $null)[0] 
    $buildPackageTag = ($env:build_package_tag, 'local' -ne $null)[0]
	$outPath = "$baseParent\Output"
	$outDir = "$baseParent\Binaries"
	$nugetPublishFolder = "$outPath\NuGet-Output"
	$nugetPackageVersion = [string]::Format("{0:yyyy}.{0:MM}.{0:dd}.{1}-{2}", [DateTime]::Today, $buildRevision, $buildPackageTag)
	$nugetPackageName = $nugetPackageVersion + ".nupkg"
	$visualStudioVersion = '12.0' # Set this to the version of Visual Studio you have (12.0 = 2013, 11.0 = 2012, 10.0 = 2010)
	$nugetExe = "$baseDir\Tools\NuGet\NuGet.exe"
	$nugetExeConfig = "$baseDir\Tools\NuGet\NuGet.config"
}

task default -description "Default Build Task" -depends Clean,CompileApp,TestApp,PackageApp

#Cleans the output folders and creates output structure
task Clean {
		if ((Test-Path $outPath)) {
			Remove-Item -Recurse "$outPath\**" | Where { ! $_.PSIsContainer }
        }
		
		if ((Test-Path $outDir)) {
			Remove-Item -Recurse "$outDir\**" | Where { ! $_.PSIsContainer }
        }
		
		Write-Host "Nuget output folder: " + $nugetPublishFolder
        if (!(Test-Path $nugetPublishFolder)) {
             md $nugetPublishFolder 
        }
}


task CompileApp -depends Clean {
     
	$solution = "$baseParent\SecurePay.MasterPass.sln"
 
	Write-Host "Restoring packages..."
	.$nugetExe restore $solution -ConfigFile $nugetExeConfig
	Write-Host "Packages restored!"
	
	Write-Host "Starting build!"
	msbuild $solution /p:Configuration=$buildConfiguration /p:Platform=$buildPlatform /p:OutDir="$outDir\" /p:OutputPath="$outPath\" /p:VisualStudioVersion=$visualStudioVersion /p:SkipInvalidConfigurations=true
	
    ValidateExitCode(0)

    Write-Host "Build done!"
}


task TestApp -depends CompileApp {
    
	Write-Host "Starting Tesing!"
    
    $unitTestRunner = "`"$baseParent\packages\NUnit.ConsoleRunner.3.2.1\tools\nunit3-console.exe`""
    #$testAssembly = "`"$outDir\SecurePay.MasterPass.IntegrationTests.dll`" `"$outDir\SecurePay.MasterPass.UnitTests.dll`""
	$testAssembly = "`"$outDir\SecurePay.MasterPass.UnitTests.dll`""
    $openCover = "$baseParent\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe"
    
    $coverOut = "$outPath\Test-Output"    
    $coverOutPath = "`"$coverOut\projectCoverageReport.xml`""
    $coverReportOut = "`"$coverOut\cover`""

    $reportGen = "$baseParent\packages\ReportGenerator.2.4.5.0\tools\ReportGenerator.exe"
    $filters = "`"+[SecurePay*]*`" `"-[*]*.Test.*`" `"-[*]*.Bootstrapper.*`"  "

    if (!(Test-Path $coverOut)) {
            md $coverOut 
    }

    Write-Host $openCover

    .$openCover -register:user -mergebyhash -skipautoprops -filter:$filters -target:$unitTestRunner -targetargs:"$testAssembly" -output:$coverOutPath
	
    .$reportGen -reports:$coverOutPath -targetdir:$coverReportOut

    ValidateExitCode(0)

    Write-Host "Tesing Done!"
}


task PackageApp -depends TestApp {
	
	Write-Host "Starting packaging!"
	.$nugetExe pack "..\Build\SecurePay.MasterPass.LoadTests.nuspec" -NoPackageAnalysis -OutputDirectory $nugetPublishFolder -Version $nugetPackageVersion
    .$nugetExe pack "..\Build\SecurePay.MasterPass.nuspec" -NoPackageAnalysis -OutputDirectory $nugetPublishFolder -Version $nugetPackageVersion
	Write-Host "Packaging Done!"
}


function ValidateExitCode($expectedExitCode)
{

	Write-Host "Last exit code $LASTEXITCODE"
    if (-not ($LASTEXITCODE -eq $expectedExitCode)) 
    {
        throw [System.ArgumentOutOfRangeException] "Exit code should not be $LASTEXITCODE, expected value $expectedExitCode."
    }
}

task PerfTest -depends Clean {

    $projectPath = "$baseParent\SecurePay.MasterPass.PerformanceTest\SecurePay.MasterPass.PerformanceTest.csproj"
 
	Write-Host "Starting performance test build!"
	msbuild $projectPath /p:Configuration=$buildConfiguration /p:Platform=$buildPlatform /p:OutDir="$outDir\" /p:OutputPath="$outPath\" /p:VisualStudioVersion=$visualStudioVersion /p:SkipInvalidConfigurations=true
	
    ValidateExitCode(0)

    Write-Host "Build done!"

    Write-Host "Starting performance test!"

    $SiteVersion = $([System.DateTime]::Now.ToString("dd-MM-yyyy-HHmmss"))
    $RunSetting = "DEV"
    $LoadTest = "ConstantLoad.loadtest"
    $description = "SecurePay Masterpass Service Development"
    Copy-Item -Path "$baseParent\Local.testsettings" -Destination "$outDir" -Force
    cd $outDir
    .\RunLoadTest.ps1 -LoadTestRunSetting $RunSetting -LoadTestToRun $LoadTest -SiteVersion $SiteVersion -LoadTestType "ConstantLoad" -SiteDescription $description -NotifySlack $true
    Write-Host "Performance test done!"
}
