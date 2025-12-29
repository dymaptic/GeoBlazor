<#
.SYNOPSIS
    Cross-platform dialog utility for displaying message boxes.

.DESCRIPTION
    Shows a message dialog using platform-appropriate methods:
    - Windows: WinForms-based custom dialog
    - macOS: AppleScript display alert
    - Linux: zenity, kdialog, or console fallback

.PARAMETER Message
    The message text to display in the dialog.

.PARAMETER Title
    The title of the dialog window.

.PARAMETER Buttons
    The button configuration. Valid values: None, OK, OKCancel, YesNo, YesNoCancel, RetryCancel, AbortRetryIgnore
    Use 'None' for a dialog that stays open until programmatically killed.

.PARAMETER Type
    The dialog type which determines the color scheme. Valid values: information, warning, error, success

.PARAMETER DefaultButtonIndex
    Zero-based index of the default button.

.PARAMETER ListenForInput
    When specified, the dialog will listen for standard input and append each line received to the message.
    This allows external processes to update the dialog message dynamically while it's open.
    (Windows only)

.EXAMPLE
    .\showDialog.ps1 -Message "Operation completed successfully" -Title "Success" -Type success

.EXAMPLE
    .\showDialog.ps1 -Message "Are you sure?" -Title "Confirm" -Buttons YesNo -Type warning

.EXAMPLE
    $result = .\showDialog.ps1 -Message "Continue?" -Title "Question" -Buttons YesNoCancel
    if ($result -eq "Yes") { Write-Host "User selected Yes" }

.EXAMPLE
    # Start a persistent dialog in async mode, then kill it later
    $job = Start-Job { .\showDialog.ps1 -Message "Processing..." -Title "Please Wait" -Buttons None -Type information }
    # ... do work ...
    Stop-Job $job; Remove-Job $job

.EXAMPLE
    # Use -ListenForInput to dynamically update the dialog message from stdin
    # Pipe output to the dialog to update its message in real-time
    & { Write-Output "Step 1 complete"; Start-Sleep 1; Write-Output "Step 2 complete" } | .\showDialog.ps1 -Message "Starting..." -Title "Progress" -Buttons None -ListenForInput
#>

param(
    [Parameter(Mandatory, Position = 0)]
    [string]$Message,

    [Parameter(Position = 1)]
    [string]$Title = "Message",

    [Parameter(Position = 2)]
    [ValidateSet('None', 'OK', 'OKCancel', 'YesNo', 'YesNoCancel', 'RetryCancel', 'AbortRetryIgnore')]
    [string]$Buttons = 'OK',

    [ValidateSet('information', 'warning', 'error', 'success')]
    [string]$Type = 'information',

    [ValidateSet(0, 1, 2)]
    [int]$DefaultButtonIndex = -1,

    [int]$Duration = 0,

    [switch]$Async,

    [switch]$ListenForInput
)

$buttonMap = @{
    'None'             = @{ buttonList = @(); defaultButtonIndex = -1; cancelButtonIndex = $null }
    'OK'               = @{ buttonList = @('OK'); defaultButtonIndex = 0; cancelButtonIndex = $null }
    'OKCancel'         = @{ buttonList = @('OK', 'Cancel'); defaultButtonIndex = 0; cancelButtonIndex = 1 }
    'YesNo'            = @{ buttonList = @('Yes', 'No'); defaultButtonIndex = 0; cancelButtonIndex = 1 }
    'YesNoCancel'      = @{ buttonList = @('Yes', 'No', 'Cancel'); defaultButtonIndex = 0; cancelButtonIndex = 2 }
    'RetryCancel'      = @{ buttonList = @('Retry', 'Cancel'); defaultButtonIndex = 0; cancelButtonIndex = 1 }
    'AbortRetryIgnore' = @{ buttonList = @('Abort', 'Retry', 'Ignore'); defaultButtonIndex = 2; cancelButtonIndex = 0 }
}

function Show-WindowsDialog {
    param(
        [string]$Message,
        [string]$Title,
        [string]$Type,
        [string[]]$ButtonList,
        [int]$DefaultIndex,
        [int]$CancelIndex,
        [int]$Duration,
        [bool]$Async,
        [bool]$ListenForInput
    )

    # Create synchronized hashtable for cross-runspace communication
    $syncHash = [hashtable]::Synchronized(@{
        Message = $Message
        DialogClosed = $false
        Result = $null
    })

    $runspace = [runspacefactory]::CreateRunspace()
    $runspace.Open()
    $runspace.SessionStateProxy.SetVariable('syncHash', $syncHash)

    $PowerShell = [PowerShell]::Create().AddScript({
        param ($message, $title, $type, $buttonList, $defaultButtonIndex, $cancelButtonIndex, $duration, $syncHash)

        Add-Type -AssemblyName System.Windows.Forms
        Add-Type -AssemblyName System.Drawing

        # Win32 API for forcing window to foreground
        Add-Type @"
            using System;
            using System.Runtime.InteropServices;
            public class Win32 {
                [DllImport("user32.dll")]
                public static extern bool SetForegroundWindow(IntPtr hWnd);

                [DllImport("user32.dll")]
                public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

                [DllImport("user32.dll")]
                public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

                [DllImport("user32.dll")]
                public static extern IntPtr GetForegroundWindow();

                [DllImport("user32.dll")]
                public static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr lpdwProcessId);

                [DllImport("kernel32.dll")]
                public static extern uint GetCurrentThreadId();

                [DllImport("user32.dll")]
                public static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

                public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
                public static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
                public const uint SWP_NOMOVE = 0x0002;
                public const uint SWP_NOSIZE = 0x0001;
                public const int SW_SHOW = 5;
                public const int SW_RESTORE = 9;
            }
"@

        $Timer = New-Object System.Windows.Forms.Timer
        $Timer.Interval = 1000
        $script:result = $null
        $script:countdown = $duration

        # Color schemes based on type
        $colorSchemes = @{
            "success"     = @{ back = "#60A917"; fore = "#FFFFFF" }
            "warning"     = @{ back = "#FA6800"; fore = "#FFFFFF" }
            "information" = @{ back = "#693CB2"; fore = "#FFFFFF" }
            "error"       = @{ back = "#CE352C"; fore = "#FFFFFF" }
        }

        $colors = if ($colorSchemes.ContainsKey($type)) { $colorSchemes[$type] } else { @{ back = "#FFFFFF"; fore = "#000000" } }
        $back = $colors.back
        $fore = $colors.fore

        # Build Form
        $form = New-Object System.Windows.Forms.Form
        $form.ShowInTaskbar = $false
        $form.TopMost = $true
        $form.Text = $title
        $form.ForeColor = [System.Drawing.ColorTranslator]::FromHtml($fore)
        $form.BackColor = [System.Drawing.ColorTranslator]::FromHtml($back)
        $form.ControlBox = $true
        $form.MinimizeBox = $false
        $form.MaximizeBox = $false
        $form.FormBorderStyle = [System.Windows.Forms.FormBorderStyle]::FixedSingle

        # Calculate dimensions
        $buttonHeight = 35
        $buttonMargin = 10
        $hasButtons = $buttonList.Count -gt 0
        $totalButtonHeight = if ($hasButtons) { $buttonHeight + ($buttonMargin * 2) } else { 0 }
        $formWidth = 400
        $formHeight = 480 + $totalButtonHeight

        $form.Size = New-Object System.Drawing.Size($formWidth, $formHeight)

        # Center on primary screen
        $monitor = [System.Windows.Forms.Screen]::PrimaryScreen
        $monitorWidth = $monitor.WorkingArea.Width
        $monitorHeight = $monitor.WorkingArea.Height
        $form.StartPosition = "Manual"
        $form.Location = New-Object System.Drawing.Point(
            (($monitorWidth / 2) - ($form.Width / 2)),
            (($monitorHeight / 2) - ($form.Height / 2))
        )

        # Add message control - use TextBox for scrolling when listening for input
        $marginX = 30
        $marginY = 30
        $labelWidth = $formWidth - ($marginX * 2) - 16  # Account for form border
        $labelHeight = $formHeight - ($marginY * 2) - $totalButtonHeight - 40

        # Use a TextBox with scrolling capability
        $textBox = New-Object System.Windows.Forms.TextBox
        $textBox.Location = New-Object System.Drawing.Size($marginX, $marginY)
        $textBox.Size = New-Object System.Drawing.Size($labelWidth, $labelHeight)
        $textBox.Font = New-Object System.Drawing.Font("Segoe UI", 11, [System.Drawing.FontStyle]::Regular)
        $textBox.Text = $message
        $textBox.ForeColor = [System.Drawing.ColorTranslator]::FromHtml($fore)
        $textBox.BackColor = [System.Drawing.ColorTranslator]::FromHtml($back)
        $textBox.Multiline = $true
        $textBox.ReadOnly = $true
        $textBox.ScrollBars = [System.Windows.Forms.ScrollBars]::Vertical
        $textBox.BorderStyle = [System.Windows.Forms.BorderStyle]::None
        $textBox.TabStop = $false
        $form.Controls.Add($textBox)

        # Timer to check for message updates from syncHash
        $MessageTimer = New-Object System.Windows.Forms.Timer
        $MessageTimer.Interval = 100
        $MessageTimer.Add_Tick({
            if ($null -ne $syncHash -and $syncHash.Message -ne $textBox.Text) {
                $textBox.Text = $syncHash.Message
                # Auto-scroll to the bottom
                $textBox.SelectionStart = $textBox.Text.Length
                $textBox.ScrollToCaret()
            }
        }.GetNewClosure())
        $MessageTimer.Start()

        # Handle form closing via X button
        $form.Add_FormClosing({
            $MessageTimer.Stop()
            $MessageTimer.Dispose()
            $Timer.Stop()
            $Timer.Dispose()
            if ($null -ne $syncHash) {
                # Set result to Cancel or first button if closed via X
                $script:result = if ($null -ne $cancelButtonIndex -and $cancelButtonIndex -lt $buttonList.Count) {
                    $buttonList[$cancelButtonIndex]
                } elseif ($buttonList.Count -gt 0) {
                    $buttonList[0]
                } else {
                    $null
                }
                $syncHash.Result = $script:result
                $syncHash.DialogClosed = $true
            }
        }.GetNewClosure())

        # Create buttons (only if there are any)
        if ($hasButtons) {
            $buttonWidth = 90
            $buttonSpacing = 10
            $totalButtonsWidth = ($buttonList.Count * $buttonWidth) + (($buttonList.Count - 1) * $buttonSpacing)
            $startX = ($formWidth - $totalButtonsWidth) / 2
            $buttonY = $formHeight - $buttonHeight - $buttonMargin - 40

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
                $button.Font = New-Object System.Drawing.Font("Segoe UI", 9, [System.Drawing.FontStyle]::Regular)

                # Set as default button if specified
                if ($i -eq $defaultButtonIndex) {
                    $form.AcceptButton = $button
                    $button.FlatAppearance.BorderSize = 2
                }

                # Set as cancel button if specified
                if ($null -ne $cancelButtonIndex -and $i -eq $cancelButtonIndex) {
                    $form.CancelButton = $button
                }

                # Add click event
                $button.Add_Click({
                    $script:result = $this.Text
                    $Timer.Stop()
                    $Timer.Dispose()
                    $MessageTimer.Stop()
                    $MessageTimer.Dispose()
                    if ($null -ne $syncHash) {
                        $syncHash.Result = $script:result
                        $syncHash.DialogClosed = $true
                    }
                    $form.Close()
                }.GetNewClosure())

                $form.Controls.Add($button)
            }
        }

        # Timer for auto-close
        $Timer.Add_Tick({
            $script:countdown--
            if ($script:countdown -lt 0) {
                $script:result = if ($null -ne $cancelButtonIndex -and $cancelButtonIndex -lt $buttonList.Count) {
                    $buttonList[$cancelButtonIndex]
                } else {
                    $buttonList[0]
                }
                $Timer.Stop()
                $Timer.Dispose()
                $MessageTimer.Stop()
                $MessageTimer.Dispose()
                if ($null -ne $syncHash) {
                    $syncHash.Result = $script:result
                    $syncHash.DialogClosed = $true
                }
                $form.Close()
            }
        })

        if ($duration -gt 0) {
            $Timer.Start()
        }

        # Bring form to front when shown - use Win32 API for reliable foreground activation
        $form.Add_Shown({
            $hwnd = $this.Handle

            # Get the foreground window's thread
            $foregroundHwnd = [Win32]::GetForegroundWindow()
            $foregroundThread = [Win32]::GetWindowThreadProcessId($foregroundHwnd, [IntPtr]::Zero)
            $currentThread = [Win32]::GetCurrentThreadId()

            # Attach to the foreground thread to allow SetForegroundWindow to work
            if ($foregroundThread -ne $currentThread) {
                [Win32]::AttachThreadInput($currentThread, $foregroundThread, $true) | Out-Null
            }

            # Set as topmost, then remove topmost (this forces it to front)
            [Win32]::SetWindowPos($hwnd, [Win32]::HWND_TOPMOST, 0, 0, 0, 0, [Win32]::SWP_NOMOVE -bor [Win32]::SWP_NOSIZE) | Out-Null
            [Win32]::SetWindowPos($hwnd, [Win32]::HWND_NOTOPMOST, 0, 0, 0, 0, [Win32]::SWP_NOMOVE -bor [Win32]::SWP_NOSIZE) | Out-Null

            # Show and set foreground
            [Win32]::ShowWindow($hwnd, [Win32]::SW_SHOW) | Out-Null
            [Win32]::SetForegroundWindow($hwnd) | Out-Null

            # Detach from the foreground thread
            if ($foregroundThread -ne $currentThread) {
                [Win32]::AttachThreadInput($currentThread, $foregroundThread, $false) | Out-Null
            }

            # Also use .NET methods as backup
            $this.Focus()
            $this.Activate()
            $this.BringToFront()
        })

        $form.ShowDialog() | Out-Null
        
        return $script:result

    }).AddArgument($Message).
       AddArgument($Title).
       AddArgument($Type).
       AddArgument($ButtonList).
       AddArgument($DefaultIndex).
       AddArgument($CancelIndex).
       AddArgument($Duration).
       AddArgument($syncHash)

    $PowerShell.Runspace = $runspace

    if ($ListenForInput) {
        # Start dialog asynchronously and return syncHash for stdin listening
        $handle = $PowerShell.BeginInvoke()
        return @{
            SyncHash = $syncHash
            PowerShell = $PowerShell
            Handle = $handle
        }
    }
    elseif ($Async) {
        $handle = $PowerShell.BeginInvoke()

        $null = Register-ObjectEvent -InputObject $PowerShell -MessageData $handle -EventName InvocationStateChanged -Action {
            param([System.Management.Automation.PowerShell] $ps)
            if ($ps.InvocationStateInfo.State -in 'Completed', 'Failed', 'Stopped') {
                $ps.Runspace.Close()
                $ps.Runspace.Dispose()
                try { $ps.EndInvoke($Event.MessageData) } catch { }
                $ps.Dispose()
                [GC]::Collect()
            }
        }

        return $null
    }
    else {
        $result = $PowerShell.Invoke()
        $PowerShell.Runspace.Close()
        $PowerShell.Runspace.Dispose()
        $PowerShell.Dispose()
        return $result
    }
}

function Show-MacOSDialog {
    param(
        [string]$Message,
        [string]$Title,
        [string]$Type,
        [string[]]$ButtonList,
        [int]$DefaultIndex,
        [int]$CancelIndex
    )

    # No buttons - use notification that stays until dismissed (or just display with minimal interaction)
    if ($ButtonList.Count -eq 0) {
        # Use osascript to display a notification - these persist until cleared
        $escapedMessage = $Message -replace '"', '\"'
        $escapedTitle = $Title -replace '"', '\"'
        $appleScript = "display notification `"$escapedMessage`" with title `"$escapedTitle`""
        $appleScript | osascript 2>$null
        # Block indefinitely - caller must kill the process
        while ($true) { Start-Sleep -Seconds 60 }
        return $null
    }

    # Map type to AppleScript icon type
    $iconClause = switch ($Type) {
        'error'   { 'as critical' }
        'warning' { 'as warning' }
        default   { '' }  # AppleScript doesn't have success/info differentiation
    }

    # Build button list for AppleScript
    $buttonClause = "buttons { $($ButtonList -replace '^', '"' -replace '$', '"' -join ', ') }"
    $defaultButtonClause = "default button $(1 + $DefaultIndex)"

    $cancelButtonClause = ""
    if ($null -ne $CancelIndex -and $CancelIndex -ne $DefaultIndex) {
        $cancelButtonClause = "cancel button $(1 + $CancelIndex)"
    }

    # Escape quotes in message and title
    $escapedMessage = $Message -replace '"', '\"'
    $escapedTitle = $Title -replace '"', '\"'

    $appleScript = "display alert `"$escapedTitle`" message `"$escapedMessage`" $iconClause $buttonClause $defaultButtonClause $cancelButtonClause"

    # Execute AppleScript
    $result = $appleScript | osascript 2>$null

    # Parse result - AppleScript returns "button:<name>" or empty on cancel
    if (-not $result) {
        if ($null -ne $CancelIndex) {
            return $ButtonList[$CancelIndex]
        }
        return $ButtonList[0]
    }

    return ($result -replace '.+:')
}

function Show-LinuxDialog {
    param(
        [string]$Message,
        [string]$Title,
        [string]$Type,
        [string[]]$ButtonList,
        [int]$DefaultIndex,
        [int]$CancelIndex
    )

    # No buttons - display message and block indefinitely
    if ($ButtonList.Count -eq 0) {
        $color = switch ($Type) {
            'error'   { 'Red' }
            'warning' { 'Yellow' }
            'success' { 'Green' }
            default   { 'Cyan' }
        }
        Write-Host ""
        Write-Host "=== $Title ===" -ForegroundColor $color
        Write-Host $Message
        Write-Host "(Press Ctrl+C to dismiss)"
        Write-Host ""
        # Block indefinitely - caller must kill the process
        while ($true) { Start-Sleep -Seconds 60 }
        return $null
    }

    # Map type to zenity/kdialog icon
    $zenityType = switch ($Type) {
        'error'       { '--error' }
        'warning'     { '--warning' }
        'information' { '--info' }
        'success'     { '--info' }
        default       { '--info' }
    }

    # Try zenity first (GTK)
    $zenityPath = Get-Command zenity -ErrorAction SilentlyContinue
    if ($zenityPath) {
        if ($ButtonList.Count -eq 1) {
            # Simple message with OK
            zenity $zenityType --title="$Title" --text="$Message" 2>$null
            return $ButtonList[0]
        }
        else {
            # Question dialog for multi-button
            $zenityResult = zenity --question --title="$Title" --text="$Message" 2>$null
            if ($LASTEXITCODE -eq 0) {
                return $ButtonList[0]  # "Yes" or first button
            }
            else {
                return $ButtonList[1]  # "No" or second button
            }
        }
    }

    # Try kdialog (KDE)
    $kdialogPath = Get-Command kdialog -ErrorAction SilentlyContinue
    if ($kdialogPath) {
        $kdType = switch ($Type) {
            'error'   { '--error' }
            'warning' { '--sorry' }
            default   { '--msgbox' }
        }

        if ($ButtonList.Count -eq 1) {
            kdialog $kdType "$Message" --title "$Title" 2>$null
            return $ButtonList[0]
        }
        else {
            $kdResult = kdialog --yesno "$Message" --title "$Title" 2>$null
            if ($LASTEXITCODE -eq 0) {
                return $ButtonList[0]
            }
            else {
                return $ButtonList[1]
            }
        }
    }

    # Fallback to console
    Write-Host ""
    Write-Host "=== $Title ===" -ForegroundColor $(switch ($Type) {
        'error'   { 'Red' }
        'warning' { 'Yellow' }
        'success' { 'Green' }
        default   { 'Cyan' }
    })
    Write-Host $Message
    Write-Host ""

    if ($ButtonList.Count -eq 1) {
        Read-Host "Press Enter to continue"
        return $ButtonList[0]
    }

    # Show options for multi-button
    for ($i = 0; $i -lt $ButtonList.Count; $i++) {
        $prefix = if ($i -eq $DefaultIndex) { "*" } else { " " }
        Write-Host "$prefix[$($i + 1)] $($ButtonList[$i])"
    }

    $defaultDisplay = $DefaultIndex + 1
    $choice = Read-Host "Enter choice (1-$($ButtonList.Count)) [default: $defaultDisplay]"

    if ([string]::IsNullOrWhiteSpace($choice)) {
        return $ButtonList[$DefaultIndex]
    }

    $choiceNum = 0
    if ([int]::TryParse($choice, [ref]$choiceNum) -and $choiceNum -ge 1 -and $choiceNum -le $ButtonList.Count) {
        return $ButtonList[$choiceNum - 1]
    }

    return $ButtonList[$DefaultIndex]
}

# Main execution
# Allow $IsLinux and $IsMacOS to be accessed safely in Windows PowerShell
Set-StrictMode -Off

$config = $buttonMap[$Buttons]
$buttonList = $config.buttonList
$defaultIndex = if ($DefaultButtonIndex -ge 0) { $DefaultButtonIndex } else { $config.defaultButtonIndex }
$cancelIndex = $config.cancelButtonIndex

# Ensure default index is within bounds
$defaultIndex = [math]::Min($buttonList.Count - 1, $defaultIndex)

if ($IsLinux) {
    $result = Show-LinuxDialog -Message $Message -Title $Title -Type $Type -ButtonList $buttonList -DefaultIndex $defaultIndex -CancelIndex $cancelIndex
}
elseif ($IsMacOS) {
    $result = Show-MacOSDialog -Message $Message -Title $Title -Type $Type -ButtonList $buttonList -DefaultIndex $defaultIndex -CancelIndex $cancelIndex
}
else {
    # Windows
    if ($ListenForInput) {
        # Start dialog and listen for stdin input to append to message
        $dialogInfo = Show-WindowsDialog -Message $Message -Title $Title -Type $Type -ButtonList $buttonList -DefaultIndex $defaultIndex -CancelIndex $cancelIndex -Duration $Duration -Async $false -ListenForInput $true

        $syncHash = $dialogInfo.SyncHash
        $ps = $dialogInfo.PowerShell
        $handle = $dialogInfo.Handle

        try {
            # Read from stdin and append to message until dialog closes or EOF
            # Use a background runspace to read stdin without blocking the main thread
            $stdinRunspace = [runspacefactory]::CreateRunspace()
            $stdinRunspace.Open()
            $stdinRunspace.SessionStateProxy.SetVariable('syncHash', $syncHash)

            $stdinPS = [PowerShell]::Create().AddScript({
                param($syncHash)
                $stdinStream = [System.Console]::OpenStandardInput()
                $reader = New-Object System.IO.StreamReader($stdinStream)

                try {
                    while (-not $syncHash.DialogClosed) {
                        $line = $reader.ReadLine()
                        if ($null -eq $line) {
                            # EOF reached
                            break
                        }
                        # Append line to message (use CRLF for Windows TextBox)
                        $syncHash.Message = $syncHash.Message + "`r`n" + $line
                    }
                }
                finally {
                    $reader.Dispose()
                    $stdinStream.Dispose()
                }
            }).AddArgument($syncHash)

            $stdinPS.Runspace = $stdinRunspace
            $stdinHandle = $stdinPS.BeginInvoke()

            # Wait for dialog to close
            while (-not $syncHash.DialogClosed) {
                Start-Sleep -Milliseconds 100
            }

            # Clean up stdin reader
            if (-not $stdinHandle.IsCompleted) {
                $stdinPS.Stop()
            }
            $stdinRunspace.Close()
            $stdinRunspace.Dispose()
            $stdinPS.Dispose()
        }
        finally {
            # Wait for dialog to complete if still running
            if (-not $handle.IsCompleted) {
                $null = $ps.EndInvoke($handle)
            }
            $ps.Runspace.Close()
            $ps.Runspace.Dispose()
            $ps.Dispose()
        }

        $result = $syncHash.Result
    }
    else {
        $result = Show-WindowsDialog -Message $Message -Title $Title -Type $Type -ButtonList $buttonList -DefaultIndex $defaultIndex -CancelIndex $cancelIndex -Duration $Duration -Async $Async -ListenForInput $false
    }
}

return $result
