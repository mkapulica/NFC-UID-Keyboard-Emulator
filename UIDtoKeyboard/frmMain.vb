Imports PCSC
Imports PCSC.Iso7816
Imports PCSC.Monitoring

Public Class frmMain

    Private Shared ReadOnly _contextFactory As IContextFactory = ContextFactory.Instance
    Private _hContext As ISCardContext
    Dim readerName As String
    Dim readingMode As String
    Dim isStart As Boolean = False
    Dim monitor

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
        If readerName = "" Or readerName Is Nothing Then
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

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ManageStartupShortcut()
        LoadReaderList()
    End Sub

    Private Sub BtnRefreshReader_Click(sender As Object, e As EventArgs) Handles btnRefreshReader.Click
        LoadReaderList()
    End Sub

    Private Sub BtnStartMonitor_Click(sender As Object, e As EventArgs) Handles btnStartMonitor.Click
        If isStart = True Then
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
        If rbReversed.Checked Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function IsSendEnterOptionChecked()
        If chkSendEnter.Checked Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function IsRunAtStartupEnabled()
        If StartupToolStripMenuItem.Checked Then
            Return True
        Else
            Return False
        End If
    End Function

    Sub ManageStartupShortcut()
        Dim shortcutManager As New ShortcutManager()
        If IsRunAtStartupEnabled() Then
            shortcutManager.EnsureStartupShortcut()
            shortcutManager.RemoveObsoleteShortcuts()
        Else
            shortcutManager.RemoveStartupShortcut()
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
        ManageStartupShortcut()
    End Sub
End Class
