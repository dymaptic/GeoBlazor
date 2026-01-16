param([string][Alias("c")]$Content, [bool]$isError=$false)

# ESBuild logger - writes build output to a rolling 2-day log file
# Usage: ./esBuildLogger.ps1 -Content "Build message" [-isError $true]

$logFile = Join-Path $PSScriptRoot "esbuild.log"

# Load existing log content and trim entries older than 2 days
$logContent = Get-Content -Path $logFile -ErrorAction SilentlyContinue
$newLogContent = @()
$twoDaysAgo = (Get-Date).AddDays(-2)

if ($logContent)
{
    $startIndex = 0
    for ($i = 0; $i -lt $logContent.Count; $i++)
    {
        $line = $logContent[$i]
        if ($line -match '^\[(\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2})\]')
        {
            $timestamp = [datetime]$matches[1]
            if ($timestamp -lt $twoDaysAgo)
            {
                $startIndex = $i + 1
            }
            else
            {
                break
            }
        }
    }
    $newLogContent = $logContent[$startIndex..($logContent.Count - 1)]
}

# Add new entry with timestamp
$timestamp = Get-Date -Format "yyyy-MM-dd HH:mm:ss"
$prefix = if ($isError) { "[ERROR]" } else { "" }
$logEntry = "[$timestamp]$prefix $Content"
$newLogContent += $logEntry

Set-Content -Path $logFile -Value $newLogContent -Force
