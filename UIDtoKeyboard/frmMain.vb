Imports System.IO
Imports PCSC
Imports PCSC.Iso7816
Imports PCSC.Monitoring

Public Class frmMain

    Private Shared ReadOnly _contextFactory As IContextFactory = ContextFactory.Instance
    Private _hContext As ISCardContext
    Private _settingsManager As SettingsManager
    Dim readerName As String
    Dim readingMode As String
    Dim isStart As Boolean = False
    Dim monitor
    Dim isRunAtStartupEnabled As Boolean = True

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeSettings()
        SetControlsFromSettings()
        LoadReaderList()
        AutoStartMonitor()
    End Sub

    Private Sub InitializeSettings()
        Dim settingsFilePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json")
        _settingsManager = New SettingsManager(settingsFilePath)
        ManageStartupShortcut(_settingsManager.Settings.IsRunAtStartupEnabled)
    End Sub

    Private Sub AutoStartMonitor()
        If _settingsManager.Settings.IsAutoStartMonitorEnabled Then
            isStart = StartMonitor()
            If isStart Then
                btnStartMonitor.Text = "Stop Monitor"
            End If
        End If
    End Sub

    Private Sub SetControlsFromSettings()
        SetStartupCheckboxes(_settingsManager.Settings.IsRunAtStartupEnabled)
        rbReversed.Checked = _settingsManager.Settings.IsReversedByteOrder
        rbOriginal.Checked = Not _settingsManager.Settings.IsReversedByteOrder
        chkSendEnter.Checked = _settingsManager.Settings.IsSendEnterEnabled
        AutostartMonitorToolStripMenuItem.Checked = _settingsManager.Settings.IsAutoStartMonitorEnabled
        MinimizeToTrayToolStripMenuItem.Checked = _settingsManager.Settings.IsMinimizeToTrayEnabled
        ManageMinimizeToTrayOption()
    End Sub

    Private Sub BtnRefreshReader_Click(sender As Object, e As EventArgs) Handles btnRefreshReader.Click
        LoadReaderList()
    End Sub

    Private Sub BtnStartMonitor_Click(sender As Object, e As EventArgs) Handles btnStartMonitor.Click
        ToggleMonitor()
    End Sub

    Private Sub ToggleMonitor()
        If isStart Then
            If StopMonitor() Then
                btnStartMonitor.Text = "Start Monitor"
                isStart = False
            End If
        Else
            isStart = StartMonitor()
            If isStart Then
                btnStartMonitor.Text = "Stop Monitor"
            End If
        End If
    End Sub

    Function LoadReaderList()
        Dim readerList As String()
        Try
            cbxReaderList.DataSource = Nothing

            _hContext = _contextFactory.Establish(SCardScope.System)
            readerList = _hContext.GetReaders()
            _hContext.Release()

            If readerList.Length > 0 Then
                cbxReaderList.DataSource = readerList
            Else
                MessageBox.Show("No card reader detected!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            Return True
        Catch ex As Exceptions.PCSCException
            MessageBox.Show("Error: getReaderList() : " & ex.Message & " (" & ex.SCardError.ToString() & ")")
            Return False
        End Try
    End Function

    Private Function StartMonitor()
        readerName = cbxReaderList.SelectedItem
        If String.IsNullOrEmpty(readerName) Then
            MessageBox.Show("No card reader detected!" + vbCrLf + "Please try refreshing the reader list.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        Else
            Dim monitorFactory As MonitorFactory = MonitorFactory.Instance
            monitor = monitorFactory.Create(SCardScope.System)
            AttachToAllEvents(monitor)
            monitor.Start(readerName)
            Return True
        End If
    End Function

    Private Function StopMonitor()
        If monitor IsNot Nothing Then
            monitor.Cancel()
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub AttachToAllEvents(monitor As ISCardMonitor)
        AddHandler monitor.CardInserted, AddressOf CardInit
    End Sub

    Sub CardInit(eventName As SCardMonitor, unknown As CardStatusEventArgs)
        TypeOutUID()
    End Sub

    Function TypeOutUID()
        Try
            Using context = _contextFactory.Establish(SCardScope.System)
                Using rfidReader = context.ConnectReader(readerName, SCardShareMode.Shared, SCardProtocol.Any)
                    Using rfidReader.Transaction(SCardReaderDisposition.Leave)

                        Dim apdu As Byte() = {&HFF, &HCA, &H0, &H0, &H0}
                        Dim sendPci = SCardPCI.GetPci(rfidReader.Protocol)
                        Dim receivePci = New SCardPCI()

                        Dim receiveBuffer = New Byte(255) {}
                        Dim command = apdu.ToArray()
                        Dim bytesReceived = rfidReader.Transmit(sendPci, command, command.Length, receivePci, receiveBuffer, receiveBuffer.Length)
                        Dim responseApdu = New ResponseApdu(receiveBuffer, bytesReceived, IsoCase.Case2Short, rfidReader.Protocol)

                        Dim uidLength = responseApdu.GetData().Length

                        If uidLength <= 0 Then
                            ' Handle case where no UID or unexpected response is received
                            Return False
                        End If

                        Dim uid As Byte() = responseApdu.GetData()

                        If IsReversed() Then
                            Array.Reverse(uid)
                        End If

                        Dim uidString As String = BitConverter.ToString(uid)
                        uidString = uidString.Replace("-", "")

                        If IsSendEnterOptionChecked() Then
                            uidString += "{ENTER}"
                        End If

                        SendKeys.SendWait(uidString)
                    End Using
                End Using
            End Using
        Catch
            'Error Handling should be developed
        End Try

        Return True
    End Function

    Private Function IsReversed()
        Return rbReversed.Checked
    End Function

    Private Function IsSendEnterOptionChecked()
        Return chkSendEnter.Checked
    End Function

    Private Function IsMinimizeToTrayEnabled()
        Return MinimizeToTrayToolStripMenuItem.Checked
    End Function

    Sub ManageStartupShortcut(runAtStartupEnabled As Boolean)
        Dim shortcutManager As New ShortcutManager()
        If runAtStartupEnabled Then
            shortcutManager.EnsureStartupShortcut()
            shortcutManager.RemoveObsoleteShortcuts()
        Else
            shortcutManager.RemoveStartupShortcut()
        End If
    End Sub

    Private Sub ToggleRunAtStartup()
        _settingsManager.Settings.IsRunAtStartupEnabled = Not _settingsManager.Settings.IsRunAtStartupEnabled
        ManageStartupShortcut(_settingsManager.Settings.IsRunAtStartupEnabled)
        SetStartupCheckboxes(_settingsManager.Settings.IsRunAtStartupEnabled)
    End Sub

    Private Sub SetStartupCheckboxes(checked As Boolean)
        StartupToolStripMenuItem.Checked = checked
        StartupTrayToolStripMenuItem.Checked = checked
    End Sub

    Sub ManageMinimizeToTrayOption()
        If IsMinimizeToTrayEnabled() Then
            NotifyIcon1.Visible = True
            Me.WindowState = FormWindowState.Normal
        Else
            NotifyIcon1.Visible = False
        End If
    End Sub

    Private Function RestartMonitor()
        If isStart = True Then
            StopMonitor()
            StartMonitor()
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub CbxReaderList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxReaderList.SelectedIndexChanged
        ' Prevent monitor restart when DataSource is being refreshed.
        If cbxReaderList.DataSource Is Nothing Then
            Return
        End If

        RestartMonitor()
    End Sub

    Private Sub StartupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartupToolStripMenuItem.Click
        ToggleRunAtStartup()
    End Sub

    ' Handle form resize event to detect minimization
    Private Sub MainForm_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If IsMinimizeToTrayEnabled() AndAlso Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
        End If
    End Sub

    ' Restore the form when NotifyIcon is double-clicked
    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub

    ' Context menu item to show the form
    Private Sub ShowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowToolStripMenuItem.Click
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub

    ' Context menu item to exit the application
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub MinimizeToTrayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MinimizeToTrayToolStripMenuItem.Click
        _settingsManager.Settings.IsMinimizeToTrayEnabled = MinimizeToTrayToolStripMenuItem.Checked
        ManageMinimizeToTrayOption()
    End Sub

    Private Sub StartupTrayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartupTrayToolStripMenuItem.Click
        ToggleRunAtStartup()
    End Sub

    Private Sub rbOriginal_CheckedChanged(sender As Object, e As EventArgs) Handles rbOriginal.CheckedChanged
        _settingsManager.Settings.IsReversedByteOrder = Not rbOriginal.Checked
    End Sub

    Private Sub chkSendEnter_CheckedChanged(sender As Object, e As EventArgs) Handles chkSendEnter.CheckedChanged
        _settingsManager.Settings.IsSendEnterEnabled = chkSendEnter.Checked
    End Sub

    Private Sub AutostartMonitorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutostartMonitorToolStripMenuItem.Click
        AutostartMonitorToolStripMenuItem.Checked = Not AutostartMonitorToolStripMenuItem.Checked
        _settingsManager.Settings.IsAutoStartMonitorEnabled = AutostartMonitorToolStripMenuItem.Checked
    End Sub
End Class
