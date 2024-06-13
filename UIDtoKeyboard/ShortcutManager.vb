Imports IWshRuntimeLibrary
Imports System.IO

Public Class ShortcutManager
    Private Const ShortcutDescription As String = "RFID/NFC UID Keyboard Emulator - Reads RFID/NFC Tag UID and emulates as keyboard input."
    Private Const ShortcutExtension As String = ".lnk"

    Public Sub EnsureStartupShortcut()
        Try
            Dim startupPath As String = GetStartupFolderPath()
            Dim shortcutPath As String = GetShortcutFilePath(startupPath)

            If System.IO.File.Exists(shortcutPath) Then
                UpdateShortcutIfRequired(shortcutPath)
            Else
                CreateShortcut(shortcutPath)
            End If

        Catch ex As UnauthorizedAccessException
            ShowErrorMessage("Insufficient permissions to create or modify the startup shortcut.")
        Catch ex As IOException
            ShowErrorMessage($"File system error: {ex.Message}")
        Catch ex As Exception
            ShowErrorMessage($"Unexpected error ensuring startup shortcut: {ex.Message}")
        End Try
    End Sub

    Public Sub RemoveObsoleteShortcuts()
        Try
            Dim startupPath As String = GetStartupFolderPath()

            For Each shortcutFile In Directory.GetFiles(startupPath, $"*{ShortcutExtension}")
                RemoveShortcutIfInvalid(shortcutFile)
            Next

        Catch ex As UnauthorizedAccessException
            ShowErrorMessage("Insufficient permissions to remove obsolete shortcuts.")
        Catch ex As IOException
            ShowErrorMessage($"File system error: {ex.Message}")
        Catch ex As Exception
            ShowErrorMessage($"Unexpected error removing obsolete shortcuts: {ex.Message}")
        End Try
    End Sub

    Public Sub RemoveStartupShortcut()
        Try
            Dim startupPath As String = GetStartupFolderPath()
            Dim shortcutPath As String = GetShortcutFilePath(startupPath)

            If System.IO.File.Exists(shortcutPath) Then
                System.IO.File.Delete(shortcutPath)
            End If

        Catch ex As UnauthorizedAccessException
            ShowErrorMessage("Insufficient permissions to remove the startup shortcut.")
        Catch ex As IOException
            ShowErrorMessage($"File system error: {ex.Message}")
        Catch ex As Exception
            ShowErrorMessage($"Unexpected error removing startup shortcut: {ex.Message}")
        End Try
    End Sub

    Private Function GetStartupFolderPath() As String
        Return Environment.GetFolderPath(Environment.SpecialFolder.Startup)
    End Function

    Private Function GetShortcutFilePath(startupPath As String) As String
        Dim shortcutName As String = $"{Path.GetFileNameWithoutExtension(Application.ExecutablePath)}{ShortcutExtension}"
        Return Path.Combine(startupPath, shortcutName)
    End Function

    Private Sub CreateShortcut(shortcutPath As String)
        Dim shortcut As IWshShortcut = CType(New WshShell().CreateShortcut(shortcutPath), IWshShortcut)
        ConfigureShortcut(shortcut)
        shortcut.Save()
    End Sub

    Private Sub UpdateShortcutIfRequired(shortcutPath As String)
        Dim shortcut As IWshShortcut = CType(New WshShell().CreateShortcut(shortcutPath), IWshShortcut)
        If shortcut.TargetPath <> Application.ExecutablePath Then
            ConfigureShortcut(shortcut)
            shortcut.Save()
        End If
    End Sub

    Private Sub ConfigureShortcut(shortcut As IWshShortcut)
        shortcut.TargetPath = Application.ExecutablePath
        shortcut.WorkingDirectory = Path.GetDirectoryName(Application.ExecutablePath)
        shortcut.Description = ShortcutDescription
    End Sub

    Private Sub RemoveShortcutIfInvalid(shortcutFile As String)
        Dim shortcut As IWshShortcut = CType(New WshShell().CreateShortcut(shortcutFile), IWshShortcut)
        If Not System.IO.File.Exists(shortcut.TargetPath) Then
            System.IO.File.Delete(shortcutFile)
        End If
    End Sub

    Private Sub ShowErrorMessage(message As String)
        MessageBox.Show(message, "Shortcut Manager", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
End Class
