param([string][Alias("c")]$Content, [bool]$isError=$false)


# We have some generic implementations of message boxes borrowed here, and then adapted.
# So there is some code that isn't being used.

#usage
#Alkane-Popup [message] [title] [type] [buttons] [position] [duration] [asynchronous]
#Alkane-Popup "This is a message." "My Title" "success" "OKCancel" "center" 0 $false
#[message] a string of text
#[title] a string for the window title bar
#[type] options are "success" "warning" "error" "information".  A blank string will be default black text on a white background.
#[buttons] options are "OK" "OKCancel" "AbortRetryIgnore" "YesNoCancel" "YesNo" "RetryCancel"
#[position] options are "topLeft" "topRight" "topCenter" "center" "centerLeft" "centerRight" "bottomLeft" "bottomCenter" "bottomRight"
#[duration] 0 will keep the popup open until clicked.  Any other integer will close after that period in seconds.
#[asynchronous] $true or $false.  $true will pop the message up and continue script execution (asynchronous).  $false will pop the message up and wait for it to timeout or be manually closed on click.


# https://www.alkanesolutions.co.uk/2023/03/23/powershell-gui-message-box-popup/
function Alkane-Popup() {

    param(
        [string]$message,
        [string]$title,
        [string]$type,
        [ValidateSet('OK', 'OKClear', 'OKShowLogsClear', 'OKCancel', 'AbortRetryIgnore', 'YesNoCancel', 'YesNo', 'RetryCancel')]
        [string]$buttons = 'OK',
        [string]$position,
        [int]$duration,
        [bool]$async,
        [string]$logFile = (Join-Path $PSScriptRoot "esbuild.log")
    )

    $buttonMap = @{
        'OK'               = @{ buttonList = @('OK'); defaultButtonIndex = 0 }
        'OKClear'         = @{ buttonList = @('OK', 'Clear'); defaultButtonIndex = 0; cancelButtonIndex = 1 }
        'OKShowLogsClear' = @{ buttonList = @('OK', 'Show Logs', 'Clear'); defaultButtonIndex = 0; cancelButtonIndex = 2 }
        'OKCancel'         = @{ buttonList = @('OK', 'Cancel'); defaultButtonIndex = 0; cancelButtonIndex = 1 }
        'AbortRetryIgnore' = @{ buttonList = @('Abort', 'Retry', 'Ignore'); defaultButtonIndex = 2; cancelButtonIndex = 0 }
        'YesNoCancel'      = @{ buttonList = @('Yes', 'No', 'Cancel'); defaultButtonIndex = 2; cancelButtonIndex = 2 }
        'YesNo'            = @{ buttonList = @('Yes', 'No'); defaultButtonIndex = 0; cancelButtonIndex = 1 }
        'RetryCancel'      = @{ buttonList = @('Retry', 'Cancel'); defaultButtonIndex = 0; cancelButtonIndex = 1 }
    }

    $runspace = [runspacefactory]::CreateRunspace()
    $runspace.Open()
    $PowerShell = [PowerShell]::Create().AddScript({
        param ($message, $title, $type, $position, $duration, $buttonList, $defaultButtonIndex, $cancelButtonIndex, $logFile)
        Add-Type -AssemblyName System.Windows.Forms

        $Timer = New-Object System.Windows.Forms.Timer
        $Timer.Interval = 1000
        $back = "#FFFFFF"
        $fore = "#000000"
        $script:result = $null

        switch ($type) {
            "success"  { $back = "#60A917"; $fore = "#FFFFFF"; break; }
            "warning"   { $back = "#FA6800"; $fore = "#FFFFFF"; break; }
            "information" { $back = "#1BA1E2"; $fore = "#FFFFFF"; break; }
            "error"  { $back = "#CE352C"; $fore = "#FFFFFF"; break; }
        }

        #Build Form
        $objForm = New-Object System.Windows.Forms.Form
        $objForm.ShowInTaskbar = $false
        $objForm.TopMost = $true
        $objForm.Text = $title
        $objForm.ForeColor =  [System.Drawing.ColorTranslator]::FromHtml($fore);
        $objForm.BackColor =  [System.Drawing.ColorTranslator]::FromHtml($back);
        $objForm.ControlBox = $false
        $objForm.FormBorderStyle = [System.Windows.Forms.FormBorderStyle]::FixedSingle
        
        # Calculate button area height
        $buttonHeight = 35
        $buttonMargin = 10
        $totalButtonHeight = $buttonHeight + ($buttonMargin * 2)
        
        $objForm.Size = New-Object System.Drawing.Size(400, 200 + $totalButtonHeight)
        $marginx = 30
        $marginy = 30
        $tbWidth = ($objForm.Width) - ($marginx*2)
        $tbHeight = ($objForm.Height) - ($marginy*2) - $totalButtonHeight
        
        #Add Rich text box
        $objTB = New-Object System.Windows.Forms.Label
        $objTB.Location = New-Object System.Drawing.Size($marginx,$marginy)

        #get primary screen width/height
        $monitor = [System.Windows.Forms.Screen]::PrimaryScreen
        $monitorWidth = $monitor.WorkingArea.Width
        $monitorHeight = $monitor.WorkingArea.Height
        $objForm.StartPosition = "Manual"

        #default center
        $objForm.Location = New-Object System.Drawing.Point((($monitorWidth/2) - ($objForm.Width/2)), (($monitorHeight/2) - ($objForm.Height/2)));

        switch ($position) {
            "topLeft"  { $objForm.Location = New-Object System.Drawing.Point(0,0); break; }
            "topRight"  { $objForm.Location =  New-Object System.Drawing.Point(($monitorWidth - $objForm.Width),0); break; }
            "topCenter"  { $objForm.Location = New-Object System.Drawing.Point((($monitorWidth/2) - ($objForm.Width/2)), 0); break; }
            "center"  { $objForm.Location = New-Object System.Drawing.Point((($monitorWidth/2) - ($objForm.Width/2)), (($monitorHeight/2) - ($objForm.Height/2))); break; }
            "centerLeft"  { $objForm.Location = New-Object System.Drawing.Point(0, (($monitorHeight/2) - ($objForm.Height/2))); break; }
            "centerRight"  { $objForm.Location = New-Object System.Drawing.Point(($monitorWidth - $objForm.Width), (($monitorHeight/2) - ($objForm.Height/2))); break; }
            "bottomLeft"  { $objForm.Location = New-Object System.Drawing.Point(0, ($monitorHeight - $objForm.Height)); break; }
            "bottomCenter"  { $objForm.Location = New-Object System.Drawing.Point((($monitorWidth/2) - ($objForm.Width/2)), ($monitorHeight - $objForm.Height)); break; }
            "bottomRight"  { $objForm.Location = New-Object System.Drawing.Point(($monitorWidth - $objForm.Width), ($monitorHeight - $objForm.Height)); break; }
        }

        $objTB.Size = New-Object System.Drawing.Size($tbWidth,$tbHeight)
        $objTB.Font = "Arial,14px,style=Regular"
        $objTB.Text = $message
        $objTB.ForeColor =  [System.Drawing.ColorTranslator]::FromHtml($fore);
        $objTB.BackColor =  [System.Drawing.ColorTranslator]::FromHtml($back);
        $objTB.BorderStyle = 'None'
        $objTB.DetectUrls = $false
        $objTB.SelectAll()
        $objTB.SelectionAlignment = 'Center'
        $objForm.Controls.Add($objTB)
        #deselect text after centralising it
        $objTB.Select(0, 0)

        #add some padding near scrollbar if visible
        $scrollCalc =  ($objTB.Width - $objTB.ClientSize.Width) #if 0 no scrollbar
        if ($scrollCalc -ne 0) {
            $objTB.RightMargin = ($objTB.Width-35)
        }

        # Create buttons
        $buttonWidth = 80
        $buttonSpacing = 10
        $totalButtonsWidth = ($buttonList.Count * $buttonWidth) + (($buttonList.Count - 1) * $buttonSpacing)
        $startX = ($objForm.Width - $totalButtonsWidth) / 2
        $buttonY = $objForm.Height - $buttonHeight - $buttonMargin - 30

        for ($i = 0; $i -lt $buttonList.Count; $i++) {
            $button = New-Object System.Windows.Forms.Button
            $button.Text = $buttonList[$i]
            $button.Size = New-Object System.Drawing.Size($buttonWidth, $buttonHeight)
            $button.Location = New-Object System.Drawing.Point(($startX + ($i * ($buttonWidth + $buttonSpacing))), $buttonY)
            $button.BackColor = [System.Drawing.ColorTranslator]::FromHtml($back)
            $button.ForeColor = [System.Drawing.ColorTranslator]::FromHtml($fore)
            $button.FlatStyle = [System.Windows.Forms.FlatStyle]::Flat
            $button.FlatAppearance.BorderSize = 1
            $button.FlatAppearance.BorderColor = [System.Drawing.ColorTranslator]::FromHtml($fore)
            
            # Set as default button if specified
            if ($i -eq $defaultButtonIndex) {
                $objForm.AcceptButton = $button
                $button.FlatAppearance.BorderSize = 2
            }
            
            # Add click event
            $buttonText = $buttonList[$i]
            $button.Add_Click({
                # Special handling for Clear button - delete lock files
                if ($this.Text -eq "Clear") {
                    try {
                        # Get current directory (where esBuild*.lock files would be)
                        $currentDir = Get-Location
                        
                        # Delete esBuild*.lock files from current directory
                        $esBuildLocks = Get-ChildItem -Path $currentDir -Name "esBuild*.lock" -ErrorAction SilentlyContinue
                        foreach ($lockFile in $esBuildLocks) {
                            $fullPath = Join-Path $currentDir $lockFile
                            Remove-Item -Path $fullPath -Force -ErrorAction SilentlyContinue
                            Write-Host "Deleted: $fullPath"
                        }
                        
                        # Find Pro project directory - navigate up to find GeoBlazor.Pro folder
                        $proDir = $currentDir
                        while ($proDir -and -not (Test-Path (Join-Path $proDir "GeoBlazor.Pro"))) {
                            $proDir = Split-Path $proDir -Parent
                        }
                        
                        if ($proDir) {
                            $proProjectDir = Join-Path $proDir "GeoBlazor.Pro"
                            
                            # Delete esProBuild*.lock files from Pro project directory
                            $esProBuildLocks = Get-ChildItem -Path $proProjectDir -Name "esProBuild*.lock" -ErrorAction SilentlyContinue
                            foreach ($lockFile in $esProBuildLocks) {
                                $fullPath = Join-Path $proProjectDir $lockFile
                                Remove-Item -Path $fullPath -Force -ErrorAction SilentlyContinue
                                Write-Host "Deleted: $fullPath"
                            }
                        }
                    }
                    catch {
                        Write-Warning "Error deleting lock files: $($_.Exception.Message)"
                    }
                } elseif ($this.Text -eq "Show Logs") {
                    # Open log file in default text editor
                    if (Test-Path $logFile) {
                        Start-Process -FilePath $logFile
                    } else {
                        [System.Windows.Forms.MessageBox]::Show("Log file not found: $logFile", "Error", [System.Windows.Forms.MessageBoxButtons]::OK, [System.Windows.Forms.MessageBoxIcon]::Error) | Out-Null
                    }
                }
                
                $script:result = $this.Text
                $Timer.Dispose()
                $objForm.Dispose()
            }.GetNewClosure())
            
            $objForm.Controls.Add($button)
        }

        # Remove click handlers from textbox and form since we have buttons now
        $script:countdown = $duration

        $Timer.Add_Tick({
            --$script:countdown
            if ($script:countdown -lt 0)
            {
                $script:result = if ($null -ne $cancelButtonIndex) { $buttonList[$cancelButtonIndex] } else { $buttonList[0] }
                $Timer.Dispose();
                $objForm.Dispose();
            }
        })

        if ($duration -gt 0) {
            $Timer.Start()
        }

        #bring form to front when shown
        $objForm.Add_Shown({
            $this.focus()
            $this.Activate();
            $this.BringToFront();
        })
        
        $objForm.ShowDialog() | Out-Null
        return $script:result

    }).AddArgument($message).`
            AddArgument($title).`
            AddArgument($type).`
            AddArgument($position).`
            AddArgument($duration).`
            AddArgument($buttonMap[$buttons].buttonList).`
            AddArgument($buttonMap[$buttons].defaultButtonIndex).`
            AddArgument($buttonMap[$buttons].cancelButtonIndex).`
            AddArgument($logFile)

    $state = @{
        Instance = $PowerShell
        Handle   = if ($async) { $PowerShell.BeginInvoke() } else {  $PowerShell.Invoke() }
    }

    $null = Register-ObjectEvent -InputObject $state.Instance -MessageData $state.Handle -EventName InvocationStateChanged -Action {
        param([System.Management.Automation.PowerShell] $ps)
        if($ps.InvocationStateInfo.State -in 'Completed', 'Failed', 'Stopped') {
            $ps.Runspace.Close()
            $ps.Runspace.Dispose()
            $ps.EndInvoke($Event.MessageData)
            $ps.Dispose()
            [GC]::Collect()
        }
    }
}

# https://stackoverflow.com/questions/58718191/is-there-a-way-to-display-a-pop-up-message-box-in-powershell-that-is-compatible
function Show-MessageBox {
    [CmdletBinding(PositionalBinding=$false)]
    param(
        [Parameter(Mandatory, Position=0)]
        [string] $Message,
        [Parameter(Position=1)]
        [string] $Title,
        [Parameter(Position=2)]
        [ValidateSet('OK', 'OKClear', 'OKShowLogsClear', 'OKCancel', 'AbortRetryIgnore', 'YesNoCancel', 'YesNo', 'RetryCancel')]
        [string] $Buttons = 'OK',
        [ValidateSet('information', 'warning', 'error', 'success')]
        [string] $Type = 'information',
        [ValidateSet(0, 1, 2)]
        [int] $DefaultButtonIndex
    )

    # So that the $IsLinux and $IsMacOS PS Core-only
    # variables can safely be accessed in WinPS.
    Set-StrictMode -Off

    $buttonMap = @{
        'OK'               = @{ buttonList = 'OK'; defaultButtonIndex = 0 }
        'OKClear'         = @{ buttonList = 'OK', 'Clear'; defaultButtonIndex = 0; cancelButtonIndex = 1 }
        'OKShowLogsClear' = @{ buttonList = 'OK', 'Show Logs', 'Clear'; defaultButtonIndex = 0; cancelButtonIndex = 2 }
        'OKCancel'         = @{ buttonList = 'OK', 'Cancel'; defaultButtonIndex = 0; cancelButtonIndex = 1 }
        'AbortRetryIgnore' = @{ buttonList = 'Abort', 'Retry', 'Ignore'; defaultButtonIndex = 2; ; cancelButtonIndex = 0 };
        'YesNoCancel'      = @{ buttonList = 'Yes', 'No', 'Cancel'; defaultButtonIndex = 2; cancelButtonIndex = 2 };
        'YesNo'            = @{ buttonList = 'Yes', 'No'; defaultButtonIndex = 0; cancelButtonIndex = 1 }
        'RetryCancel'      = @{ buttonList = 'Retry', 'Cancel'; defaultButtonIndex = 0; cancelButtonIndex = 1 }
    }

    $numButtons = $buttonMap[$Buttons].buttonList.Count
    $defaultIndex = [math]::Min($numButtons - 1, ($buttonMap[$Buttons].defaultButtonIndex, $DefaultButtonIndex)[$PSBoundParameters.ContainsKey('DefaultButtonIndex')])
    $cancelIndex = $buttonMap[$Buttons].cancelButtonIndex

    if ($IsLinux) {
        Throw "Not supported on Linux."
    }
    elseif ($IsMacOS) {

        $iconClause = if ($Type -ne 'information') { 'as ' + $Type -replace 'error', 'critical' }
        $buttonClause = "buttons { $($buttonMap[$Buttons].buttonList -replace '^', '"' -replace '$', '"' -join ',') }"

        $defaultButtonClause = 'default button ' + (1 + $defaultIndex)
        if ($null -ne $cancelIndex -and $cancelIndex -ne $defaultIndex) {
            $cancelButtonClause = 'cancel button ' + (1 + $cancelIndex)
        }

        $appleScript = "display alert `"$Title`" message `"$Message`" $iconClause $buttonClause $defaultButtonClause $cancelButtonClause"            #"

        Write-Verbose "AppleScript command: $appleScript"

        # Show the dialog.
        # Note that if a cancel button is assigned, pressing Esc results in an
        # error message indicating that the user canceled.
        $result = $appleScript | osascript 2>$null

        # Output the name of the button chosen (string):
        # The name of the cancel button, if the dialog was canceled with ESC, or the
        # name of the clicked button, which is reported as "button:<name>"
        if (-not $result) { $buttonMap[$Buttons].buttonList[$buttonMap[$Buttons].cancelButtonIndex] } else { $result -replace '.+:' }
    }
    else { # Windows
        Alkane-Popup -message $Message -title $Title -type $Type -buttons $Buttons -position 'center' -duration 0 -async $false
    }
}

# save the content to a log file for reference
$logFile = Join-Path $PSScriptRoot "esbuild.log"

$logContent = Get-Content -Path $logFile -ErrorAction SilentlyContinue
$newLogContent = $logContent
if ($logContent) 
{
    for ($i = 0; $i -lt $logContent.Count; $i++)
    {
        $line = $logContent[$i]
        # check the timestamp starting the line
        if ($line -match '^\[(\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2})\]') 
        {
            $timestamp = [datetime]$matches[1]
            # if the timestamp is older than 2 days, remove the line
            if ($timestamp -lt (Get-Date).AddDays(-2)) 
            {
                $newLogContent = $logContent[($i + 1)..$logContent.Count - 1]
            }
            else
            {
                break
            }
        }
    }
    
    Set-Content -Path $logFile -Value $newLogContent -Force
}

$timestamp = Get-Date -Format "yyyy-MM-dd HH:mm:ss"
$logEntry = "[$timestamp] $Content"
Add-Content -Path $logFile -Value $logEntry

# if there is content in the $logFile older than 2 days, delete it


if ($isError)
{
    Show-MessageBox -Message "An error occurred during the esBuild step. Please check the log file for details." `
        -Title "esBuild Step Failed" `
        -Buttons "OKShowLogsClear" `
        -Type error
}