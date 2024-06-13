Imports System.Text.Json
Imports System.IO
Imports System.ComponentModel

Public Class SettingsManager

    Private _settings As AppSettings
    Private _settingsFilePath As String

    Public Sub New(settingsFilePath As String)
        _settingsFilePath = settingsFilePath
        _settings = LoadSettings()
        AddHandler _settings.PropertyChanged, AddressOf OnSettingsChanged
    End Sub

    Public ReadOnly Property Settings As AppSettings
        Get
            Return _settings
        End Get
    End Property

    Private Sub OnSettingsChanged(sender As Object, e As PropertyChangedEventArgs)
        SaveSettings()
    End Sub

    Public Sub SaveSettings()
        Dim options As New JsonSerializerOptions() With {
        .WriteIndented = True ' For a readable JSON format
        }
        Dim json As String = JsonSerializer.Serialize(_settings, options)
        File.WriteAllText(_settingsFilePath, json)
    End Sub

    Public Function LoadSettings() As AppSettings
        If File.Exists(_settingsFilePath) Then
            Dim json As String = File.ReadAllText(_settingsFilePath)
            Return JsonSerializer.Deserialize(Of AppSettings)(json)
        Else
            ' Return default settings if the file does not exist
            Return New AppSettings()
        End If
    End Function

    Public Function GetSettingsFilePath() As String
        Return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json")
    End Function

End Class
