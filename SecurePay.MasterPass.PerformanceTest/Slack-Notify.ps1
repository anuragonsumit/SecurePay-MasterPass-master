
function Get-SlackHookConfig {
    $hook_config = @{
        channel = "#performancetesting";
        username = "PerformanceBOT";
        icon_url = "https://cdn2.iconfinder.com/data/icons/windows-8-metro-style/512/test_tube.png";
    };
    return $hook_config;
}

function Notify-Slack ($hook_config, $notification)
{
    #Write-Host "hook_config is $hook_config"
    #Write-Host "notification is $notification"
    $payload = @{
        channel = $hook_config["channel"];
        username = $hook_config["username"];
        icon_url = $hook_config["icon_url"];
        attachments = @(
            @{
            fallback = $notification["fallback"];
            color = $notification["color"];
            fields = @(
                @{
                title = $notification["title"];
                value = $notification["value"];
                });
            };
        );
    }

    $hook = "https://hooks.slack.com/services/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"
    
    #"POSTING to Slack: \n" + ($payload | ConvertTo-Json -Depth 4)
    
    Invoke-Restmethod -Method POST -Body ($payload | ConvertTo-Json -Depth 4) -Uri $hook
}

function New-StartingNotification ($testDescription) {
    $pre_deployment_notification = @{
        title = "Starting Performance Test...";
        value = "Performance Test: $testDescription is starting...";
        fallback = "I'm about to start performance test : $testDescription";
        color = "warning";
    };
    return $pre_deployment_notification;
}

function New-SuccessNotification ($testDescription) {
    $success_notification = @{
        title = "Success";
        value = "Performance Test: $testDescription is complete";
        fallback = "Completed Performance Test: $testDescription successfully";
        color = "good";
    };
    return $success_notification;
}

<#
#usage sample:
$testDescription = ""
$config = Get-SlackHookConfig
$notificationStarting = New-StartingNotification $testDescription
$notificationSuccess = New-SuccessNotification $testDescription
 
Notify-Slack $config $notification
#>
