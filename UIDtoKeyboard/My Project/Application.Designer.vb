﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Ce code a été généré par un outil.
'     Version du runtime :4.0.30319.42000
'
'     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
'     le code est régénéré.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On
Imports System.Reflection

Namespace My

    'REMARQUE : Ce fichier étant généré automatiquement, ne le modifiez pas directement.  Pour apporter des modifications,
    ' ou si vous rencontrez des erreurs de build dans ce fichier, accédez au Concepteur de projets
    ' (allez dans les propriétés du projet ou double-cliquez sur le nœud My Project dans
    ' l'Explorateur de solutions), puis apportez vos modifications sous l'onglet Application.
    '
    Partial Friend Class MyApplication

        <Global.System.Diagnostics.DebuggerStepThroughAttribute()>
        Public Sub New()
            MyBase.New(Global.Microsoft.VisualBasic.ApplicationServices.AuthenticationMode.Windows)
            AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf CurrentDomain_AssemblyResolve
            Me.IsSingleInstance = False
            Me.EnableVisualStyles = True
            Me.SaveMySettingsOnExit = True
            Me.ShutdownStyle = Global.Microsoft.VisualBasic.ApplicationServices.ShutdownMode.AfterMainFormCloses
        End Sub

        Private Shared Function CurrentDomain_AssemblyResolve(sender As Object, args As ResolveEventArgs) As Assembly
            Dim resourceName As String = New AssemblyName(args.Name).Name + ".dll"
            Dim resource As String = Array.Find(Assembly.GetExecutingAssembly().GetManifestResourceNames(), Function(s) s.EndsWith(resourceName))

            Using stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource)
                If stream Is Nothing Then Return Nothing
                Dim assemblyData(CInt(stream.Length) - 1) As Byte
                stream.Read(assemblyData, 0, assemblyData.Length)
                Return Assembly.Load(assemblyData)
            End Using
        End Function

        <Global.System.Diagnostics.DebuggerStepThroughAttribute()>
        Protected Overrides Sub OnCreateMainForm()
            Me.MainForm = Global.UIDtoKeyboard.frmMain
        End Sub
    End Class
End Namespace
